using FindRestOfItemsWindows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FindRestOfItemsWindows.ClassHelper
{
    public class JDE_PROD_GetDataProcedure : DbContext
    {
        public JDE_PROD_GetDataProcedure() : base("name=JDE_PRODEntities") { }

        //get data
        public Task<pr_GetItemLedger_Result[]> pr_GetItemLedgerAsync(int? iTM, string mCU, string lOCN, string lOTN)
        {
            return Task.Factory.StartNew(() =>
            {
                var iTMParameter = iTM.HasValue ?
                    new ObjectParameter("ITM", iTM) :
                    new ObjectParameter("ITM", typeof(int));

                var mCUParameter = mCU != null ?
                    new ObjectParameter("MCU", mCU) :
                    new ObjectParameter("MCU", typeof(string));

                var lOCNParameter = lOCN != null ?
                    new ObjectParameter("LOCN", lOCN) :
                    new ObjectParameter("LOCN", typeof(string));

                var lOTNParameter = lOTN != null ?
                    new ObjectParameter("LOTN", lOTN) :
                    new ObjectParameter("LOTN", typeof(string));

                var result = ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pr_GetItemLedger_Result>("pr_GetItemLedger", iTMParameter, mCUParameter, lOCNParameter, lOTNParameter);
                return result.ToArray();
            });
        }

        //filtr get data
        public static Expression<Func<T, bool>> FilterKey<T>(T castData)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            List<Expression> propertyExpressions = new List<Expression>();

            // Перебираем свойства в castData и добавляем их в запрос
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object propertyValue = propertyInfo.GetValue(castData);
                if (propertyValue != null)
                {
                    Expression propertyExpression = Expression.Property(parameter, propertyInfo);

                    // Если свойство является строкой, то выполняем фильтрацию строковым образом
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        Expression propertyToLower = Expression.Call(propertyExpression, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                        Expression propertyContains = Expression.Call(propertyToLower, typeof(string).GetMethod("Contains"), Expression.Constant(propertyValue.ToString().ToLower()));
                        propertyExpressions.Add(propertyContains);
                    }
                    else if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        // Если свойство является nullable типом, то выполняем фильтрацию на равенство, учитывая null
                        var propertyValueExpression = Expression.Constant(propertyValue, propertyInfo.PropertyType);
                        propertyExpressions.Add(Expression.Equal(propertyExpression, propertyValueExpression));
                    }
                    else
                    {
                        // Если свойство не является строкой и не nullable, то выполняем фильтрацию на равенство
                        propertyExpressions.Add(Expression.Equal(propertyExpression, Expression.Constant(propertyValue)));
                    }
                }
            }
            // Составляем выражение для фильтрации
            Expression filterExpression = propertyExpressions.Any()
                ? propertyExpressions.Aggregate((expr1, expr2) => Expression.AndAlso(expr1, expr2))
                : Expression.Constant(true);

            return Expression.Lambda<Func<T, bool>>(filterExpression, parameter);
        }

    }
}

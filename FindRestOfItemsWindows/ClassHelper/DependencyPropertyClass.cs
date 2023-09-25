using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace FindRestOfItemsWindows.ClassHelper
{
    public class DependencyPropertyClass : DependencyObject, IEnumerable<KeyValuePair<object, object>>
    {
        public static readonly DependencyProperty Document_NumberProperty;
        public static readonly DependencyProperty Doc_TypeProperty;
        public static readonly DependencyProperty Doc_CoProperty;
        public static readonly DependencyProperty Transaction_DateProperty;
        public static readonly DependencyProperty Branch_PlantProperty;
        public static readonly DependencyProperty QuantityProperty;
        public static readonly DependencyProperty Trans_UoMProperty;
        public static readonly DependencyProperty Unit_CostProperty;
        public static readonly DependencyProperty Extended_CostProperty;
        public static readonly DependencyProperty Lot_SerialProperty;
        public static readonly DependencyProperty LocationProperty;
        public static readonly DependencyProperty Lot_Status_CodeProperty;
        public static readonly DependencyProperty Order_NumberProperty;
        public static readonly DependencyProperty Order_TyProperty;
        public static readonly DependencyProperty Order_CoProperty;
        public static readonly DependencyProperty LineNumProperty;
        public static readonly DependencyProperty Class_CodeProperty;
        public static readonly DependencyProperty GL_DateProperty;
        public static readonly DependencyProperty Supplier_Lot_NumberProperty;
        public static readonly DependencyProperty TrexProperty;
        public static readonly DependencyProperty FTProperty;

        static DependencyPropertyClass()
        {
            Document_NumberProperty = DependencyProperty.Register("Document_Number", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata());
            Doc_TypeProperty = DependencyProperty.Register("Doc_Type", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Doc_CoProperty = DependencyProperty.Register("Doc_Co", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Transaction_DateProperty = DependencyProperty.Register("Transaction_Date", typeof(DateTime?), typeof(DependencyPropertyClass), new PropertyMetadata());
            Branch_PlantProperty = DependencyProperty.Register("Branch_Plant", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            QuantityProperty = DependencyProperty.Register("Quantity", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata());
            Trans_UoMProperty = DependencyProperty.Register("Trans_UoM", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Unit_CostProperty = DependencyProperty.Register("Unit_Cost", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata());
            Extended_CostProperty = DependencyProperty.Register("Extended_Cost", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata(null));
            Lot_SerialProperty = DependencyProperty.Register("Lot_Serial", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            LocationProperty = DependencyProperty.Register("Location", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Lot_Status_CodeProperty = DependencyProperty.Register("Lot_Status_Code", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Order_NumberProperty = DependencyProperty.Register("Order_Number", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata(null));
            Order_TyProperty = DependencyProperty.Register("Order_Ty", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            Order_CoProperty = DependencyProperty.Register("Order_Co", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            LineNumProperty = DependencyProperty.Register("LineNum", typeof(double?), typeof(DependencyPropertyClass), new PropertyMetadata(null));
            Class_CodeProperty = DependencyProperty.Register("Class_Code", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            GL_DateProperty = DependencyProperty.Register("GL_Date", typeof(DateTime?), typeof(DependencyPropertyClass), new PropertyMetadata());
            Supplier_Lot_NumberProperty = DependencyProperty.Register("Supplier_Lot_Number", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            TrexProperty = DependencyProperty.Register("Trex", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
            FTProperty = DependencyProperty.Register("FT", typeof(string), typeof(DependencyPropertyClass), new PropertyMetadata());
        }


        #region access_method
        public double? Document_Number
        {
            get { return (double?)GetValue(Document_NumberProperty); }
            set {SetValue(Document_NumberProperty, value);}

        }
        public string Doc_Type
        {
            get { return (string)GetValue(Doc_TypeProperty); }
            set{ SetValue(Doc_TypeProperty, value);}
        }
        public string Doc_Co
        {
            get { return (string)GetValue(Doc_CoProperty); }
            set{SetValue(Doc_CoProperty, value);}
        }
        public DateTime? Transaction_Date
        {
            get { return (DateTime?)GetValue(Transaction_DateProperty); }
            set{SetValue(Transaction_DateProperty, value);}
        }
        public string Branch_Plant
        {
            get { return (string)GetValue(Branch_PlantProperty); }
            set{SetValue(Branch_PlantProperty, value);}
        }
        public double? Quantity
        {
            get { return (double?)GetValue(QuantityProperty); }
            set{SetValue(QuantityProperty, value);}
        }
        public string Trans_UoM
        {
            get { return (string)GetValue(Trans_UoMProperty); }
            set{SetValue(Trans_UoMProperty, value);}
        }
        public double? Unit_Cost
        {
            get { return (double?)GetValue(Unit_CostProperty); }
            set{SetValue(Unit_CostProperty, value);}
        }
        public double? Extended_Cost
        {
            get { return (double?)GetValue(Extended_CostProperty); }
            set{SetValue(Extended_CostProperty, value);}
        }
        public string Lot_Serial
        {
            get { return (string)GetValue(Lot_SerialProperty); }
            set{ SetValue(Lot_SerialProperty, value);}
        }
        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set{SetValue(LocationProperty, value);}
        }
        public string Lot_Status_Code
        {
            get { return (string)GetValue(Lot_Status_CodeProperty); }
            set{SetValue(Lot_Status_CodeProperty, value);}
        }
        public double? Order_Number
        {
            get { return (double?)GetValue(Order_NumberProperty); }
            set{SetValue(Order_NumberProperty, value);}
        }
        public string Order_Ty
        {
            get { return (string)GetValue(Order_TyProperty); }
            set{ SetValue(Order_TyProperty, value);}
        }
        public string Order_Co
        {
            get { return (string)GetValue(Order_CoProperty); }
            set{SetValue(Order_CoProperty, value);}
        }
        public double? LineNum
        {
            get { return (double?)GetValue(LineNumProperty); }
            set{SetValue(LineNumProperty, value);}
        }
        public string Class_Code
        {
            get { return (string)GetValue(Class_CodeProperty); }
            set{SetValue(Class_CodeProperty, value);}
        }
        public DateTime? GL_Date
        {
            get { return (DateTime?)GetValue(GL_DateProperty); }
            set{SetValue(GL_DateProperty, value);}
        }
        public string Supplier_Lot_Number
        {
            get { return (string)GetValue(Supplier_Lot_NumberProperty); }
            set{SetValue(Supplier_Lot_NumberProperty, value);}
        }
        public string Trex
        {
            get { return (string)GetValue(TrexProperty); }
            set{SetValue(TrexProperty, value);}
        }
        public string FT
        {
            get { return (string)GetValue(FTProperty); }
            set{SetValue(FTProperty, value);}
        }

        #endregion

    

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
        {
            Type viewModelType = GetType();
            foreach (PropertyInfo propertyInfo in viewModelType.GetProperties())
            {
                var propertyName = propertyInfo.Name;
                var propertyValue = propertyInfo.GetValue(this);
                yield return new KeyValuePair<object, object>(propertyName, propertyValue);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}

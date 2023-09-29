using DevExpress.Xpf.Editors;
using FindRestOfItemsWindows.ClassHelper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;

namespace FindRestOfItemsWindows.Dictionarys
{

    public partial class MyResourceDictionary: ResourceDictionary
    {

        public void ButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //чтобы получить все открытые окна в приложении, затем с помощью метода OfType<MainWindow>() фильтруем их по типу MainWindow и выбираем первый найденный экземпляр
                var mainWindowsFiltr = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 

                var main = Application.Current.MainWindow as MainWindow;
                main.CheckFieldAndSeedData();
          
            }
        }


        private void Sort_MouseDownClick(object sender, MouseButtonEventArgs e)
        {

            var Xname = sender as TextBlock;
            var main1 = Application.Current.MainWindow as MainWindow;
            main1.HandleSearchResult(SortClassHelper.SortHelper((main1.FoundResltFiltrProcedureDetails != null && main1.FoundResltFiltrProcedureDetails.Any()) ?
                                              main1.FoundResltFiltrProcedureDetails : main1.GetItemsOfProcedureAll,
                                          Xname.Name));
           
        }

    }
}

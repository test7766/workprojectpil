using DevExpress.Xpf.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FindRestOfItemsWindows.ClassHelper
{
   public class ExcelHelpers
    {



        //public static void Export(List<DataTable> _dataSources, string _fileName)
        //{
        //    try
        //    {
        //        List<TemplatedLink> links = new List<TemplatedLink>();

        //        foreach (DataTable dt in _dataSources)
        //        {
        //            GridControl printGrid = new GridControl();
        //            TableView printView = new TableView();
        //            printView.Name = dt.TableName;
        //            printGrid.View = printView;
        //            printGrid.AutoPopulateColumns = true;
        //            printGrid.ItemsSource = dt;

        //            printView.AllowBestFit = true;
        //            printView.BestFitMode = DevExpress.Xpf.Core.BestFitMode.AllRows;
        //            printView.BestFitColumns();

        //            PrintableControlLink pcl = new PrintableControlLink(printGrid.View, dt.TableName);
        //            // -- pcl.CustomPaperSize = new System.Drawing.Size(800, 600);
        //            pcl.MinMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        //            pcl.Landscape = true;
        //            pcl.CreateDocument();
        //            pcl.PageHeaderData = pcl.DocumentName;
        //            links.Add(pcl);
        //        }

        //        CompositeLink compositeLink = new CompositeLink(links);
        //        // -- compositeLink.Landscape = true;
        //        compositeLink.CreatePageForEachLink();
        //        compositeLink.ShowPrintPreviewDialog(Application.Current.Windows[0]);

        //        DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions()
        //        {
        //            ExportMode = DevExpress.XtraPrinting.XlsExportMode.SingleFilePageByPage,
        //            ShowGridLines = true
        //        };
        //        compositeLink.ExportToXls(_fileName, options);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static void Export(DataTable _dataSource, string fileName, string _NamePage = null)
        {
            DevExpress.Xpf.Grid.GridControl expGrid = new DevExpress.Xpf.Grid.GridControl();
            expGrid.AutoGenerateColumns = AutoGenerateColumnsMode.AddNew;
            expGrid.View = new TableView();

            try
            {
                if (String.IsNullOrWhiteSpace(fileName))
                    throw new Exception("Сохранение невозможно!\nНеобходимо указать имя файла!");

                expGrid.ItemsSource = _dataSource;

                if (!String.IsNullOrWhiteSpace(_NamePage))
                    expGrid.View.Name = _NamePage;

                expGrid.View.ExportToXlsx(fileName);

                if (MessageBox.Show(String.Format("Экспорт успешно завершен.{0}Открыть сохраненный файл?", Environment.NewLine), "Експорт", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    Process.Start(fileName);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Експорт", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                expGrid.ItemsSource = null;
                expGrid = null;
            }
        }

        public static void Export(IList _dataSource, string fileName)
        {
            DevExpress.Xpf.Grid.GridControl expGrid = new DevExpress.Xpf.Grid.GridControl();
            expGrid.AutoGenerateColumns = AutoGenerateColumnsMode.AddNew;
            expGrid.View = new TableView();

            try
            {
                if (String.IsNullOrWhiteSpace(fileName))
                    throw new Exception("Сохранение невозможно!\nНеобходимо указать имя файла!");

                expGrid.ItemsSource = _dataSource;

                expGrid.View.ExportToXlsx(fileName);

                if (MessageBox.Show(String.Format("Экспорт успешно завершен.{0}Открыть сохраненный файл?", Environment.NewLine), "Експорт", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    Process.Start(fileName);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Експорт", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                expGrid.ItemsSource = null;
                expGrid = null;
            }
        }


        public static bool Export(DataViewBase dataViewBase, string fileName, bool ViewFile = true)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(fileName))
                    throw new Exception("Збереження не можливе!\nНеобхідно вказати найменування файлу!");

                if (dataViewBase == null) throw new Exception("Джерело даних не вказане!");

                dataViewBase.ExportToXlsx(fileName);

                if (ViewFile && MessageBox.Show(String.Format("Експорт успішно завершено.{0}Відкрити збережений файл?", Environment.NewLine), "Експорт", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    Process.Start(fileName);

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Експорт", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}

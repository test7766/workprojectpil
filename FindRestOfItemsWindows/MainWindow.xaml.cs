using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using FindRestOfItemsWindows.ClassHelper;
using FindRestOfItemsWindows.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FindRestOfItemsWindows
{

    public partial class MainWindow : Window
    {

        pr_GetItemLedger_Result[] FoundResltFiltrProcedureDetails;
        private int pageSize = 5;
        private int currentPage = 1;

        public static pr_GetItemLedger_Result[] GetItemsOfProcedureAll = DataSeed.pr_GetItemLedger_Results_procedure.ToArray();
        public static pr_GetItemLedger_Result[] SerachItemMoveDeatail = null;



        public MainWindow()
        {
            InitializeComponent();
            ItemsMoveRest.IsEnabled = false;

            txtEditLOTN.Text = "Test";
            txteditLOCN.Text = "Test";
        }

        public MainWindow(string ITM, string _mcu="tet", string _LOCN ="test", string _LOTN="tets")
        {
            InitializeComponent();
            ItemsMoveRest.IsEnabled = false;
            txtEditITM.Text = ITM;                           //id товара
            txtEditMCU.Text = _mcu;                          //id склада         char(12)
            txtEditLOTN.Text = _LOTN.Trim();                  //партия            char(30)
            txteditLOCN.Text = _LOCN.Trim();                   // Место склада     char(20)


        }



        private void UpdateGridData(pr_GetItemLedger_Result[] currntData)
        {
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, currntData.Length);
            var pageData = currntData.Skip(startIndex).Take(endIndex - startIndex).ToList();
            ItemsMoveRest.ItemsSource = pageData;
            pageInfoText.Text = $"Сторінка {currentPage} iз {Math.Ceiling((double)currntData.Length / pageSize)}";
        }



        //EXPORT Exel
        private void ExportSelectFindRestOfItems_Executed(object sender, ItemClickEventArgs e)
        {
            ExportExelDialog exportExelDialog;


            if (CheckMax.IsChecked != true)
            {
                exportExelDialog = new ExportExelDialog();



                if (exportExelDialog.ShowDialog() == true)
                {

                    var result = exportExelDialog.CurrentClick;

                    if (exportExelDialog.CurrentClick)
                    {
                        HandlerExportExel();//DEFAULT  filter or not filter
                    }
                    else
                    {

                        HandlerExportExel((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ? 
                            FoundResltFiltrProcedureDetails :
                            GetItemsOfProcedureAll);

                    }
                }
                else{MessageBox.Show("Експорт відміненно!!!");}
            }
            else { HandlerExportExel();}

        }




        void HandlerExportExel(pr_GetItemLedger_Result[] Spitdata =null)
        {
            try
            {
                List<GridColumn> col_prev_state = new List<GridColumn>();
                var openWinwow = new SaveFileDialog
                {
                    FileName = $"Переміщення  складу_{txtEditMCU.Text.Trim()}" +
                    $"Товару_{txtEditMCU.Text.Trim()}" +
                    $"Місце_{txtEditLOTN.Text.Trim()}" +
                    $"Партія_{txteditLOCN.Text.Trim()} - ",
                    Filter = "Excel файл|*.xlsx"
                };

                if (!(openWinwow.ShowDialog() ?? false))
                    return;

                if (Spitdata != null)
                {
                    ExcelHelpers.Export(Spitdata, openWinwow.FileName);
                    if ((col_prev_state?.Count ?? 0) > 0)
                        foreach (var col in col_prev_state)
                        {
                            col.Visible = false;
                        }
                }
                else
                {                
                    foreach (var col in ItemsMoveRest?.Columns.Where(p => !p.Visible))
                    {
                        col_prev_state.Add(col);
                        col.Visible = true;
                    }

                    ExcelHelpers.Export(ItemsMoveRest.View, openWinwow.FileName);
                    if ((col_prev_state?.Count ?? 0) > 0)
                        foreach (var col in col_prev_state)
                        {
                            col.Visible = false;
                        }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }



        #region EXEL_Export_Standart_CurrentPage
        private void ExportSelectFindRestOfItems_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            try
            {
                var openWinwow = new SaveFileDialog
                {
                    FileName = $"Переміщення  складу_{txtEditMCU.Text.Trim()}" +
                    $"Товару_{txtEditMCU.Text.Trim()}" +
                    $"Місце_{txtEditLOTN.Text.Trim()}" +
                    $"Партія_{txteditLOCN.Text.Trim()} - ",
                    Filter = "Excel файл|*.xlsx"
                };

                if (!(openWinwow.ShowDialog() ?? false))
                    return;


                List<GridColumn> col_prev_state = new List<GridColumn>();
                foreach (var col in ItemsMoveRest?.Columns.Where(p => !p.Visible))
                {
                    col_prev_state.Add(col);
                    col.Visible = true;
                }


                ExcelHelpers.Export(ItemsMoveRest.View, openWinwow.FileName);
                if ((col_prev_state?.Count ?? 0) > 0)
                    foreach (var col in col_prev_state)
                    {
                        col.Visible = false;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        #endregion

        //search btn click
        private void BTN_Search_History_Of_Remnants_Click(object sender, ItemClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txtEditLOTN.Text) && string.IsNullOrEmpty(txtEditLOTN.Text))
            {
                MessageBox.Show("Або місце або партія повинні бути вказані!");
                return;
            }



            int.TryParse(txtEditITM.Text.ToString(), out int ITM);      //id товара         int
            string MCU = txtEditMCU.Text.ToString();                //id склада         char(12)
            string LOTN = txtEditLOTN.Text.ToString();              //партия            char(30)
            string LOCN = txteditLOCN.Text.ToString();              // Место склада     char(20)


            FindRestOfItemLoadingDecorator.IsSplashScreenShown = true;
            //  RestitemMoveData = GetItemDetails(ITM, MCU, LOTN, LOCN).ToList();
            GetItemsOfProcedureAll = DataSeed.pr_GetItemLedger_Results_procedure.ToArray();
            FindRestOfItemLoadingDecorator.IsSplashScreenShown = false;

            if (!GetItemsOfProcedureAll.Any())
                MessageBox.Show($"Історії переміщень не знайденно!", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                ItemsMoveRest.IsEnabled = true;
                PanelFiltrPagination.IsEnabled = true;
                ItemsMoveRest.ItemsSource = GetItemsOfProcedureAll;
                (ItemsMoveRest.View as TableView).BestFitColumns();
            }

            UpdateGridData(GetItemsOfProcedureAll);


        }

        private void BTN_Clear_TableeResult_Click(object sender, ItemClickEventArgs e)
        {
            ItemsMoveRest.ItemsSource = null;
            PanelFiltrPagination.IsEnabled = false;
            ItemsMoveRest.IsEnabled = false;
        }
        //clearGrid
        private void Refresh_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;





        //export
        private void ExportSelectFindRestOfItems_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = ItemsMoveRest.ItemsSource != null;


        // GET Data 
        public static pr_GetItemLedger_Result[] GetItemDetails(int? ITM, string mCU, string lOTN, string lOCN)
        {
            try
            {

                //    using (var entity = new JDE_PRODEntities())
                //    {
                //        ((IObjectContextAdapter)entity).ObjectContext.CommandTimeout = 200;
                //        SerachItemMoveDeatail = entity.pr_GetItemLedger(ITM, mCU, lOCN: lOCN, lOTN: lOTN)?.ToArray();

                //    }
                //    if (SerachItemMoveDeatail == null) return null;
                //    return SerachItemMoveDeatail;
            }
            catch (Exception ex) { throw ex; }

            return SerachItemMoveDeatail;
        }





        #region PAGInaTION
       
        #region HomeBTN_PAGING <<--
        private void BTN_Home_Click(object sender, ItemClickEventArgs e)
        {
            BTN_Next_Name.IsEnabled = true;
            BTN_End_Name.IsEnabled = true;
            BTN_Previous_Name.IsEnabled = false;
            BTN_Home_Name.IsEnabled = false;
            currentPage = 1;
            UpdateGridData(FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any() ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);
        }
        #endregion
        #region PREVIOUS BTN <--
        private void BTN_Previous_Click(object sender, ItemClickEventArgs e)
        {
            BTN_Next_Name.IsEnabled = true;
            BTN_End_Name.IsEnabled = true;
            if (currentPage > 1)
            {
                currentPage--;
                UpdateGridData(FoundResltFiltrProcedureDetails?.Any() == true ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);
            }
            else
            {
                BTN_Home_Name.IsEnabled = false;
                BTN_Previous_Name.IsEnabled = false;
            }
        }
        #endregion
        #region Next BTN -->
        private void BTN_Next_Click(object sender, ItemClickEventArgs e)
        {
            //if FoundResltProcedure = FoundResltProcedure or GetItemsOfProcedureAll
            if (currentPage < Math.Ceiling((double)((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll).Length / pageSize))
            {
                BTN_Previous_Name.IsEnabled = true;
                BTN_Home_Name.IsEnabled = true;
                currentPage++;
                UpdateGridData(FoundResltFiltrProcedureDetails?.Any() == true ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);
            }
            else
            {
                BTN_Previous_Name.IsEnabled = true;
                BTN_Home_Name.IsEnabled = true;
                BTN_Next_Name.IsEnabled = false;
                BTN_End_Name.IsEnabled = false;
            }
        }
        #endregion
        #region End BTN -->>
        private void BTN_End_Click(object sender, ItemClickEventArgs e)
        {
            BTN_Next_Name.IsEnabled = false;
            BTN_End_Name.IsEnabled = false;
            BTN_Home_Name.IsEnabled = true; //<<
            BTN_Previous_Name.IsEnabled = true;//<
            currentPage = (int)Math.Ceiling((double)GetItemsOfProcedureAll.Length / pageSize);
            UpdateGridData(FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any() ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);
        }
        #endregion
        #endregion














        ///user click (if found item)--->HandleSearchResult
        private void ShowUsercount_ItemClick(object sender, ItemClickEventArgs e) =>
            HandleSearchResult((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);

        //Resetsearch
        private void ResetUserSearch_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            BTN_Home_Name.IsEnabled = false;
            BTN_Previous_Name.IsEnabled = false;
            BTN_Next_Name.IsEnabled = false;
            BTN_End_Name.IsEnabled = false;
            SplitEdita.IsEnabled = false;
            pageSize = 5;
            currentPage = 1;
            SplitEdita.MinValue = 5;
            SplitEdita.EditValue = 5;
            FoundResltFiltrProcedureDetails = null;
            CheckMax.IsChecked = false;
            DependencyPropertyClass DPObjects = (DependencyPropertyClass)Resources["KeyDependency"];
            SetPropertiesToNull(DPObjects);
            UpdateGridData(GetItemsOfProcedureAll);
        }

        ////DependencyObjects_SET_NuLL
        public void SetPropertiesToNull(DependencyObject obj)
        {
            Type objectType = obj.GetType();

            PropertyInfo[] properties = objectType.GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    property.SetValue(obj, null);
                }
            }
        }



        private void CheckMax_EditValueChanged_1(object sender, EditValueChangedEventArgs e) => SplitEdita.IsEnabled = CheckMax.IsChecked == false ? true : false;



        private void HandleSearchResult(pr_GetItemLedger_Result[] _getTemplateDataFullOrEmpty)
        {

            if (CheckMax.IsChecked != true)
            {
                int.TryParse(SplitEdita.Text, out pageSize);
                currentPage = 1;
                UpdateGridData(_getTemplateDataFullOrEmpty);
                tolbarArrow.IsEnabled = true;
            }
            else
            {
                currentPage = 1;
                pageSize = _getTemplateDataFullOrEmpty.Length;
                UpdateGridData(_getTemplateDataFullOrEmpty);
                tolbarArrow.IsEnabled = false;
            }
        }




        pr_GetItemLedger_Result _pr_GetItemLedgerFoundField;
        public void ButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { CheckFieldAndSeedData(); }
        }


        void CheckFieldAndSeedData()
        {
            _pr_GetItemLedgerFoundField = new pr_GetItemLedger_Result();
            DependencyPropertyClass dpSample = (DependencyPropertyClass)Resources["KeyDependency"];

            foreach (var item in dpSample)
            {

                if (item.Value != null && item.Value.ToString() != string.Empty)

                {
                    switch (item.Key)
                    {
                        case "Document_Number":
                            _pr_GetItemLedgerFoundField.Document_Number = (double)item.Value;
                            break;
                        case "Doc_Type":
                            _pr_GetItemLedgerFoundField.Doc_Type = (string)item.Value;
                            break;
                        case "Doc_Co":
                            _pr_GetItemLedgerFoundField.Doc_Co = (string)item.Value;
                            break;
                        case "Transaction_Date":
                            _pr_GetItemLedgerFoundField.Transaction_Date = (DateTime)item.Value;
                            break;
                        case "Branch_Plant":
                            _pr_GetItemLedgerFoundField.Branch_Plant = (string)item.Value;
                            break;
                        case "Quantity":
                            _pr_GetItemLedgerFoundField.Quantity = (double)item.Value;
                            break;
                        case "Trans_UoM":
                            _pr_GetItemLedgerFoundField.Trans_UoM = (string)item.Value;
                            break;
                        case "Unit_Cost":
                            _pr_GetItemLedgerFoundField.Unit_Cost = (double)item.Value;
                            break;
                        case "Extended_Cost":
                            _pr_GetItemLedgerFoundField.Extended_Cost = (double)item.Value;
                            break;
                        case "Lot_Serial":
                            _pr_GetItemLedgerFoundField.Lot_Serial = (string)item.Value;
                            break;
                        case "Location":
                            _pr_GetItemLedgerFoundField.Location = (string)item.Value;
                            break;
                        case "Lot_Status_Code":
                            _pr_GetItemLedgerFoundField.Lot_Status_Code = (string)item.Value;
                            break;
                        case "Order_Number":
                            _pr_GetItemLedgerFoundField.Order_Number = (double)item.Value;
                            break;
                        case "Order_Ty":
                            _pr_GetItemLedgerFoundField.Order_Ty = (string)item.Value;
                            break;
                        case "Order_Co":
                            _pr_GetItemLedgerFoundField.Order_Co = (string)item.Value;
                            break;
                        case "LineNum":
                            _pr_GetItemLedgerFoundField.LineNum = (double)item.Value;
                            break;
                        case "Class_Code":
                            _pr_GetItemLedgerFoundField.Class_Code = (string)item.Value;
                            break;
                        case "GL_Date":
                            _pr_GetItemLedgerFoundField.GL_Date = (DateTime)item.Value;
                            break;
                        case "Supplier_Lot_Number":
                            _pr_GetItemLedgerFoundField.Supplier_Lot_Number = (string)item.Value;
                            break;
                        case "Trex":
                            _pr_GetItemLedgerFoundField.Trex = (string)item.Value;
                            break;
                        case "FT":
                            _pr_GetItemLedgerFoundField.FT = (string)item.Value;
                            break;
                        default:
                            break;
                    }
                }
            }
            FoundResltFiltrProcedureDetails = GetItemsOfProcedureAll.AsQueryable().Where(QueryableExtensions.FilterKey(_pr_GetItemLedgerFoundField)).ToArray();
            if (FoundResltFiltrProcedureDetails.Any())
            {
                HandleSearchResult(FoundResltFiltrProcedureDetails);
            }
            else
            {
                MessageBox.Show("За вашим запитом результатів не знайдено");
                ItemsMoveRest.ItemsSource = null;
            }
        }

        private void SortClick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Xname = sender as TextBlock;
            HandleSearchResult(SortHelper((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ?
                                               FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll,
                                           Xname.Name));
        }




        //Direct way create DependencyProperty
        //для TextEdit
        public DateTime? NecessaryField
        {
            get { return (DateTime?)GetValue(RecepitTimeDP); }
            set { SetValue(RecepitTimeDP, value); }
        }
        public static readonly DependencyProperty RecepitTimeDP = DependencyProperty.Register("NecessaryField", typeof(DateTime?), typeof(MainWindow));

    }

}

using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using FindRestOfItemsWindows.ClassHelper;
using FindRestOfItemsWindows.Dictionarys;
using FindRestOfItemsWindows.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FindRestOfItemsWindows
{

    public partial class MainWindow : Window , INotifyPropertyChanged
    {

        private pr_GetItemLedger_Result _pr_GetItemLedgerFoundField; //switch
        private int pageSize = 25;
        private int currentPage = 1;
        private ObservableCollection<pr_GetItemLedger_Result> PartDataGrid = new ObservableCollection<pr_GetItemLedger_Result>();
        private int CurrentIndexData = 0;
        private int BuferSizeData = 25;

     

        public pr_GetItemLedger_Result[] FoundResltFiltrProcedureDetails { get; private set; }
        public pr_GetItemLedger_Result[] GetItemsOfProcedureAll { get; private set; } //  first result from procedure




        public MainWindow()
        {
            InitializeComponent();
            ItemsMoveRest.IsEnabled = false;

            txtEditLOTN.Text = "Test";
            txteditLOCN.Text = "Test";

         

        }

        public MainWindow(string ITM,  string _LOCN, string _LOTN, string _mcu = "tet")
        {
            InitializeComponent();
            ItemsMoveRest.IsEnabled = false;
            txtEditITM.Text = ITM;                           //id товара
            txtEditMCU.Text = _mcu;                          //id склада         char(12)
            txtEditLOTN.Text = _LOTN.Trim();                  //партия            char(30)
            txteditLOCN.Text = _LOCN;

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




      











        // GET Data 
        public  pr_GetItemLedger_Result[] GetItemDetails(int? ITM, string mCU, string lOTN, string lOCN)
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

            return GetItemsOfProcedureAll;
        }





        #region SearchRestOfItems search BTN

        private async void BTN_Search_REST_ItemClick(object sender, ItemClickEventArgs e)
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
            await LoadDataAsync(ITM, MCU, LOTN, LOCN);
            testDatastatic = "initializeData";
            HandleSearchResult(GetItemsOfProcedureAll);

        }
        #endregion

        public  string testDatastatic;



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






        #region GetDataFromProcedure
        public async Task LoadDataAsync(int ITM, string MCU, string LOTN, string LOCN)
        {
            try
            {
                FindRestOfItemLoadingDecorator1.DeferedVisibility = true;

                //var ResultItemsFromProcedureMethodTemp = await Task.Run(async () =>
                //{
                //    using (var entity = new JDE_PROD_GetDataProcedure())
                //    {
                //        ((IObjectContextAdapter)entity).ObjectContext.CommandTimeout = 200;
                //        return await entity.pr_GetItemLedgerAsync(ITM, MCU, lOCN: LOCN, lOTN: LOTN);

                //    }
                //});

              //  GetItemsOfProcedureAll = ResultItemsFromProcedureMethodTemp.ToArray();
                GetItemsOfProcedureAll = DataSeed.pr_GetItemLedger_Results_procedure.ToArray();
                if (!GetItemsOfProcedureAll.Any())
                {
                    MessageBox.Show($"Історії переміщень не знайденно!", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    FindRestOfItemLoadingDecorator1.DeferedVisibility = false;
                    LoadNextBatch();
                    ItemsMoveRest.IsEnabled = true;
                    PanelFiltrPagination.IsEnabled = true;
                    ItemsMoveRest.ItemsSource = PartDataGrid;
                    (ItemsMoveRest.View as TableView).BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion






        #region TakePartDataFromProcedureAndLoadDataGrid
        private void LoadNextBatch()
        {
            PartDataGrid.Clear();
            var batch = GetItemsOfProcedureAll.Skip(CurrentIndexData).Take(BuferSizeData);
            foreach (var item in batch)
                PartDataGrid.Add(item);
        }
        #endregion










        #region PAGInaTION
        #region PagingSTART|UPDATE_DATA
        private void UpdateGridData(pr_GetItemLedger_Result[] currntData)
        {

            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, currntData.Length);
            var pageData = currntData.Skip(startIndex).Take(endIndex - startIndex);
            ItemsMoveRest.ItemsSource = pageData;
            ItemsMoveRest.RefreshData();
            pageInfoText.Text = $"Сторінка {currentPage} iз {Math.Ceiling((double)currntData.Length / pageSize)}";
        }
        #endregion
        #region Chekbox_checking_elements_on_the_page
        public void HandleSearchResult(pr_GetItemLedger_Result[] _getTemplateDataFullOrEmpty)
        {
            currentPage = 1;
            if (CheckMax.IsChecked != true)
            {
                pageSize = _getTemplateDataFullOrEmpty.Length;
                UpdateGridData(_getTemplateDataFullOrEmpty);
                tolbarArrow.IsEnabled = false;
            }
            else
            {
                int.TryParse(SplitEdita.Text, out pageSize);
                UpdateGridData(_getTemplateDataFullOrEmpty);
                tolbarArrow.IsEnabled = true;
            }
        }




        #endregion
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
            //if FoundResltProcedure = FoundResltProcedure or SerachItemMoveDeatail
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


        #region BTN_OK 
        ///user click counts of elements (if found item)--->HandleSearchResult

        private void ShowUsercount_ItemClick(object sender, ItemClickEventArgs e) =>
            HandleSearchResult((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);

        private void SplitEdita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                HandleSearchResult((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ? FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll);
        }
        #endregion







        #region ReseT_And_Clear_Filter
        private void ResetUserSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplitEdita.IsEnabled = false;
            pageSize = GetItemsOfProcedureAll.Length;
            currentPage = 1;
            SplitEdita.MinValue = 5;
            SplitEdita.EditValue = 25;
            FoundResltFiltrProcedureDetails = null;
            CheckMax.IsChecked = false;
            DependencyPropertyClass DPObjects = (DependencyPropertyClass)Resources["KeyDependency"];
            SetPropertiesToNull(DPObjects);
            tolbarArrow.IsEnabled = false;
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


        #endregion







        //comboBox check/uncheck
        private void CheckMax_EditValueChanged_1(object sender, EditValueChangedEventArgs e) => SplitEdita.IsEnabled = CheckMax.IsChecked == false ? false : true;

        #region ClickFiltrAndChekEnptyFieldsAndSearch
        public void ButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { CheckFieldAndSeedData(); }
        }

      

      public  void CheckFieldAndSeedData()
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
            FoundResltFiltrProcedureDetails = GetItemsOfProcedureAll.AsQueryable().Where(JDE_PROD_GetDataProcedure.FilterKey(_pr_GetItemLedgerFoundField)).ToArray();
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
        #endregion 





        //Direct way create DependencyProperty
        //для TextEdit
        public string NecessaryField
        {
            get { return (string)GetValue(RecepitTimeDP); }
            set { SetValue(RecepitTimeDP, value); }
        }
        public static readonly DependencyProperty RecepitTimeDP = DependencyProperty.Register("NecessaryField", typeof(string), typeof(MainWindow));
      


        #region Sort_MouseDownClick
        private void Sort_MouseDownClick(object sender, MouseButtonEventArgs e)
        {
            var Xname = sender as TextBlock;
            HandleSearchResult(SortClassHelper.SortHelper((FoundResltFiltrProcedureDetails != null && FoundResltFiltrProcedureDetails.Any()) ?
                                                FoundResltFiltrProcedureDetails : GetItemsOfProcedureAll,
                                            Xname.Name));



            var user = new { Name = "Tom", Age = 34 };

        }
        #endregion





        //Direct way INotifyPropertyChanged


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string customerNameValue = String.Empty;
        public string CustomerName
        {
            get{return customerNameValue; }
            set
            {
                if (value != customerNameValue)
                {
                    customerNameValue = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }




     

      
    }


}

using FindRestOfItemsWindows.Model;
using System;
using System.Linq;

namespace FindRestOfItemsWindows
{
    public partial class MainWindow
    {
        //private static pr_GetItemLedger_Result ForSortTempLabel = new pr_GetItemLedger_Result();
        //private pr_GetItemLedger_Result[] TempSortItems = null;
        //public pr_GetItemLedger_Result[] SortHelper(pr_GetItemLedger_Result[] DataSort, string Xnametxt)
        //{
        //    switch (Xnametxt)
        //    {
        //        case "_Document_Number":
        //            if (ForSortTempLabel.Document_Number != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Document_Number).ToArray();
        //                ForSortTempLabel.Document_Number = null;
                     
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Document_Number).ToArray();
        //                ForSortTempLabel.Document_Number = 0;
                     
        //            }
        //            break;
        //        case "_Doc_Type":
        //            if (ForSortTempLabel.Doc_Type != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Doc_Type).ToArray();
        //                ForSortTempLabel.Doc_Type = null;
                       
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Doc_Type).ToArray();
        //                ForSortTempLabel.Doc_Type = string.Empty;
                    
        //            }

        //            break;
        //        case "_Doc_Co":
        //            if (ForSortTempLabel.Doc_Co != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Doc_Co).ToArray();
        //                ForSortTempLabel.Doc_Co = null;
                      
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Doc_Co).ToArray();
        //                ForSortTempLabel.Doc_Co = string.Empty;
                      
        //            }


        //            break;
        //        case "_Transaction_Date":
        //            if (ForSortTempLabel.Transaction_Date != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Transaction_Date).ToArray();
        //                ForSortTempLabel.Transaction_Date = null;
              
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Transaction_Date).ToArray();
        //                ForSortTempLabel.Transaction_Date = new DateTime();
                
        //            }

        //            break;
        //        case "_Branch_Plant":
        //            if (ForSortTempLabel.Branch_Plant != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Branch_Plant).ToArray();
        //                ForSortTempLabel.Branch_Plant = null;
          
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Branch_Plant).ToArray();
        //                ForSortTempLabel.Branch_Plant = string.Empty;
          
        //            }

        //            break;
        //        case "_Quantity":
        //            if (ForSortTempLabel.Quantity != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Quantity).ToArray();
        //                ForSortTempLabel.Quantity = null;
           
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Quantity).ToArray();
        //                ForSortTempLabel.Quantity = 0;

        //            }
        //            break;
        //        case "_Trans_UoM":
        //            if (ForSortTempLabel.Trans_UoM != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Trans_UoM).ToArray();
        //                ForSortTempLabel.Trans_UoM = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Trans_UoM).ToArray();
        //                ForSortTempLabel.Trans_UoM = string.Empty;
        //            }

        //            break;
        //        case "_Unit_Cost":
        //            if (ForSortTempLabel.Unit_Cost != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Unit_Cost).ToArray();
        //                ForSortTempLabel.Unit_Cost = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Unit_Cost).ToArray();
        //                ForSortTempLabel.Unit_Cost = 0;
        //            }


        //            break;
        //        case "_Extended_Cost":
        //            if (ForSortTempLabel.Extended_Cost != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Extended_Cost).ToArray();
        //                ForSortTempLabel.Extended_Cost = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Extended_Cost).ToArray();
        //                ForSortTempLabel.Extended_Cost = 0;
        //            }

        //            break;
        //        case "_Lot_Serial":
        //            if (ForSortTempLabel.Lot_Serial != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Lot_Serial).ToArray();
        //                ForSortTempLabel.Lot_Serial = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Lot_Serial).ToArray();
        //                ForSortTempLabel.Lot_Serial = string.Empty;
        //            }
        //            break;
        //        case "_Location":
        //            if (ForSortTempLabel.Location != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Location).ToArray();
        //                ForSortTempLabel.Location = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Location).ToArray();
        //                ForSortTempLabel.Location = string.Empty;
        //            }
        //            break;
        //        case "_Lot_Status_Code":
        //            if (ForSortTempLabel.Location != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Lot_Status_Code).ToArray();
        //                ForSortTempLabel.Lot_Status_Code = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Lot_Status_Code).ToArray();
        //                ForSortTempLabel.Lot_Status_Code = string.Empty;
        //            }

        //            break;
        //        case "_Order_Number":
        //            if (ForSortTempLabel.Location != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Order_Number).ToArray();
        //                ForSortTempLabel.Order_Number = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Order_Number).ToArray();
        //                ForSortTempLabel.Order_Number = 0;
        //            }
        //            break;
        //        case "_Order_Ty":
        //            if (ForSortTempLabel.Order_Ty != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Order_Ty).ToArray();
        //                ForSortTempLabel.Order_Ty = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Order_Ty).ToArray();
        //                ForSortTempLabel.Order_Ty = string.Empty;
        //            }

        //            break;
        //        case "_Order_Co":
        //            if (ForSortTempLabel.Order_Co != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Order_Co).ToArray();
        //                ForSortTempLabel.Order_Co = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Order_Co).ToArray();
        //                ForSortTempLabel.Order_Co = string.Empty;
        //            }

        //            break;
        //        case "_LineNum":
        //            if (ForSortTempLabel.LineNum != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.LineNum).ToArray();
        //                ForSortTempLabel.LineNum = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.LineNum).ToArray();
        //                ForSortTempLabel.LineNum = 0;
        //            }

        //            break;
        //        case "_Class_Code":
        //            if (ForSortTempLabel.Class_Code != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Class_Code).ToArray();
        //                ForSortTempLabel.Class_Code = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Class_Code).ToArray();
        //                ForSortTempLabel.Class_Code = string.Empty;
        //            }

        //            break;
        //        case "_GL_Date":
        //            if (ForSortTempLabel.GL_Date != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.GL_Date).ToArray();
        //                ForSortTempLabel.GL_Date = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.GL_Date).ToArray();
        //                ForSortTempLabel.GL_Date = new DateTime();
        //            }
        //            break;
        //        case "_Supplier_Lot_Number":
        //            if (ForSortTempLabel.Supplier_Lot_Number != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Supplier_Lot_Number).ToArray();
        //                ForSortTempLabel.Supplier_Lot_Number = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Supplier_Lot_Number).ToArray();
        //                ForSortTempLabel.Supplier_Lot_Number = string.Empty;
        //            }
        //            break;
        //        case "_Trex":
        //            if (ForSortTempLabel.Trex != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.Trex).ToArray();
        //                ForSortTempLabel.Trex = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.Trex).ToArray();
        //                ForSortTempLabel.Trex = string.Empty;
        //            }
        //            break;
        //        case "_FT":
        //            if (ForSortTempLabel.FT != null)
        //            {
        //                TempSortItems = DataSort.OrderByDescending(x => x.FT).ToArray();
        //                ForSortTempLabel.FT = null;
        //            }
        //            else
        //            {
        //                TempSortItems = DataSort.OrderBy(y => y.FT).ToArray();
        //                ForSortTempLabel.FT = string.Empty;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    return TempSortItems;
        //}
    }

}

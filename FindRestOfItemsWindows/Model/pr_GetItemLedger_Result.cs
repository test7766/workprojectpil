using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRestOfItemsWindows.Model
{
  public  class pr_GetItemLedger_Result
    {

        public double? Document_Number { get; set; }
        public string Doc_Type { get; set; }
        public string Doc_Co { get; set; }
        public DateTime? Transaction_Date { get; set; }
        public string Branch_Plant { get; set; }
        public double? Quantity { get; set; }
        public string Trans_UoM { get; set; }
        public double? Unit_Cost { get; set; }
        public double? Extended_Cost { get; set; }
        public string Lot_Serial { get; set; }
        public string Location { get; set; }
        public string Lot_Status_Code { get; set; }
        public double? Order_Number { get; set; }
        public string Order_Ty { get; set; }
        public string Order_Co { get; set; }
        public double? LineNum { get; set; }
        public string Class_Code { get; set; }
        public DateTime? GL_Date { get; set; }
        public string Supplier_Lot_Number { get; set; }
        public string Trex { get; set; }
        public string FT { get; set; }

    }
}

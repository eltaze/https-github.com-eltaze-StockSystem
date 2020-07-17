using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
   public class ItemRecitDetailDisplay
    {
        public int Id { get; set; }
        public int RecitItemId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Qty { get; set; }
        public string Note { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int counter { get; set; }
        public string BarCode { get; set; }
    }
}

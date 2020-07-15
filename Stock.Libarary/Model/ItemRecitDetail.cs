using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class ItemRecitDetail
    {
        public int Id { get; set; }
        public int RecitItemId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Qty { get; set; }
        public string Note { get; set; }
    }
}

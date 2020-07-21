using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
   public class BaseItemStockDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<Decimal> Balance { get; set; }
        public string UnitName { get; set; }
    }
}

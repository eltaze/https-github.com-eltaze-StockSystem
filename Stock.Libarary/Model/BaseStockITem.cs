using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class BaseStockITem
    {
        public Nullable<int> Itemid { get; set; }
        public String Name { get; set; }
        public Nullable<int> UnitId { get; set; }
        public decimal Balance { get; set; }

    }
    public class BaseItemStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<Decimal> Balance { get; set; }

    }

}

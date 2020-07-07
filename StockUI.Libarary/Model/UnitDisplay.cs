using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
  public  class UnitDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable< int> UnitId { get; set; }
        public Nullable<decimal> Qty { get; set; }
       // public int KindId { get; set; }
    }   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Libarary.Model
{
   public  class stockitem
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ItemId { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
    }
}
  

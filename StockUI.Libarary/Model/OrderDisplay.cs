using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
  public  class OrderDisplay
    {
        public int Id { get; set; }
        public DateTime ODate { get; set; }
        public int StockId { get; set; }
        public string Note { get; set; }
        public List<OrderDetailDisplay> OrderDetails { get; set; } = new List<OrderDetailDisplay>();
    }
}

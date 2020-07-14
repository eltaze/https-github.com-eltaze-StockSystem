using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
    public class MoveorderDisplay
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string DriverName { get; set; }
        public string CarBlate { get; set; }
        public DateTime Odate { get; set; }
        public int StockId { get; set; }
        public string Note { get; set; }
        public string City { get; set; }
        public String stockName { get; set; }
        public List<MoveOrderDetailDisplay> moveorderdetailDisplays { get; set; } = new List<MoveOrderDetailDisplay>();
    }
}

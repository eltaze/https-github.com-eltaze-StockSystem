using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace StockSystem.Libarary.Model
{
   public class MoveOrder
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string DriverName { get; set; }
        public string CarBlate { get; set; }
        public DateTime Odate { get; set; }
        public int StockId { get; set; }
        public string Note { get; set; }
        public List<MoveOrderDetail> moveorderdetails = new List<MoveOrderDetail>();
    }

}

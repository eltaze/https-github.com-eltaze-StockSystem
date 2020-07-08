using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public Decimal Qty { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Note { get; set; }
        public bool FirstApprove { get; set; }
        public bool SecondApprove { get; set; }
        public bool ThirdApprove { get; set; }

    }
}

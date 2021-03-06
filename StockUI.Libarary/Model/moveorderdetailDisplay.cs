﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
    public class MoveOrderDetailDisplay
    {
        public int Id { get; set; }
        public int Moveorderid { get; set; }
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public Decimal Qty { get; set; }
        public string Note { get; set; }
        public string barcode { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public int Counter { get; set; }
    }
}

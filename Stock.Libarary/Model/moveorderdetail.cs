﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class moveorderdetail
    {
        public int Id { get; set; }
        public int Moveorderid { get; set; }
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public Decimal Qty { get; set; }
        public string Note { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class Order
    {
        public int Id { get; set; }
        public DateTime ODate { get; set; }
        public int StockId { get; set; }
        public string Note { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

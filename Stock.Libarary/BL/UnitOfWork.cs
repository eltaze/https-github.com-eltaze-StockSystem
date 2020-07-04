
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ItemEndPoint Item { get; set; }
        public DepartmentEndPoint Department { get; set; }
        public KindEndPoint Kind { get; set; }
        public StockEndPoint Stock { get; set; }
        public StockItemEndPoint StockItem { get; set; }
        public UnitEndPoint Unit { get; set; }
    }
}

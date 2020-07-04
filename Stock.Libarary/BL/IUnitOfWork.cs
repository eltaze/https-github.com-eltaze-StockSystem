﻿namespace StockSystem.Libarary.BL
{
    public interface IUnitOfWork
    {
        DepartmentEndPoint Department { get; set; }
        ItemEndPoint Item { get; set; }
        KindEndPoint Kind { get; set; }
        StockEndPoint Stock { get; set; }
        StockItemEndPoint StockItem { get; set; }
        UnitEndPoint Unit { get; set; }
    }
}
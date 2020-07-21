using System;

namespace StockSystem.Libarary.Model
{
    public class BaseItemStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<Decimal> Balance { get; set; }
        public string UnitName { get; set; }
    }
}

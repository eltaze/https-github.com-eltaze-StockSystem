using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockUI.Libarary.BL
{
    public class UnitConversions
    {
        private readonly IUnitEndPoint unitEndPoint;

        public UnitConversions(IUnitEndPoint unitEndPoint)
        {
            this.unitEndPoint = unitEndPoint;
        }
       public decimal GetConvert(Unit unitFirst,Unit lastunit,decimal qty)
        {
            decimal x = qty / unitFirst.QTYTOPARENT.Value;
            var output = x * lastunit.QTYTOPARENT.Value;
            return output;
        }
    }
}

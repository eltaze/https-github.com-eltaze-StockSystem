﻿using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System.Collections.Generic;
using System.Linq;

namespace StockUI.Libarary.BL
{
    public class UnitConversions
    {
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IStockItemEndPoint stockItemEndPoint;
        public UnitConversions(IUnitEndPoint unitEndPoint,IItemEndPoint itemEndPoint,IStockItemEndPoint stockItemEndPoint)
        {
            this.unitEndPoint = unitEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
        }
       public decimal GetConvert(Unit unitFirst,Unit lastunit,decimal qty)
        {
            decimal x = qty / unitFirst.QTYTOPARENT.Value;
            var output = x * lastunit.QTYTOPARENT.Value;
            return output;
        }
        public decimal GetItemBalance(int itemid,int stockid,int unitid = 0)
        {
            var x = stockItemEndPoint.GetByStockItem(stockid, itemid);
            if (x.UnitId == unitid)
            {
                return x.Balance;
            }
            else
            {
                var b = unitEndPoint.GetByID(x.UnitId);
                var z = unitEndPoint.GetByID(unitid);
                return GetConvert(b, z, x.Balance);
            }
        }
        public List<Unit> GetUnits(int id)
        {
            var x = unitEndPoint.GetByUnitIdTest(id).ToList();
            var b = unitEndPoint.GetByUnitIdPernt(id).ToList();
            List<Unit> units = new List<Unit>();           
            units.AddRange(x);
            units.AddRange(b);
            return units.GroupBy(k=>k.Id).Select(k=>k.First()).ToList();
        }
        public List<Unit> GetUnits(int id,int stockId=1)
        {
            ///<summary>
            ///This Method for Getting All unit include conversion of unit
            ///</summary>
            var x = GetUnits(id);
            var y = stockItemEndPoint.GetByStockItem(stockId, id);
            foreach (Unit item in x)
            {
                if (y.UnitId == item.Id)
                {
                    item.Qty = y.Balance;
                }
                else
                {
                    int k = x.FindIndex(b => b.Id == y.UnitId);
                    item.Qty = GetConvert(x[k], item, y.Balance);
                }
            }
            return x;
        }      
    }
}

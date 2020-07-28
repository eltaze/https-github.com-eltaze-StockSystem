using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.BL
{
    public class stockItemCalc
    {
        private readonly StockItemEndPoint stockItemEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly UnitEndPoint unitEndPoint;
        /// <summary>
        /// this class is control stock items calculation in  and out for all item 
        /// this class masure for all forms update and delete 
        /// </summary>
        public stockItemCalc(StockItemEndPoint stockItemEndPoint,IItemEndPoint itemEndPoint
                           , UnitConversions unitConversions , UnitEndPoint unitEndPoint)
        {
            this.stockItemEndPoint = stockItemEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitConversions = unitConversions;
            this.unitEndPoint = unitEndPoint;
        }
        /// <summary>
        /// this function get new balnace for stock item's
        /// you have to check it if is withdrow it should not be less than 0
        /// this check it should be in cslling
        /// </summary>
        /// <param name="qty"> new quantity for stock</param>
        /// <param name="itemid">item id </param>
        /// <param name="unitid">unit for new balance</param>
        /// <param name="stockid">stock id </param>
        /// <returns></returns>
        public stockitem GetNewStockitem(decimal qty, int itemid, int unitid, int stockid)
        {
            var stockitem = stockItemEndPoint.GetByStockItem(stockid, itemid);
            if (stockitem == null)
            {
                stockitem x = new stockitem
                {
                    ItemId = itemid,
                    StockId = stockid,
                    Balance = qty,
                    UnitId = unitid
                };
                stockitem = x;
            }
            else
            {
                if (stockitem.UnitId == unitid)
                {
                    stockitem.Balance += qty;
                }
                else
                {
                    var x = unitEndPoint.GetByID(unitid);
                    var y = unitEndPoint.GetByID(stockitem.UnitId);
                    stockitem.Balance = unitConversions.GetConvert(y, x, stockitem.Balance);
                    stockitem.UnitId = unitid;
                    stockitem.Balance += qty;
                }
            }
            return stockitem;
        }
        public stockitem GetStockitem(int stockid, int itemid)
        {
            stockitem output = new stockitem();
            var item = itemEndPoint.GetByID(itemid);
            var stockitem = stockItemEndPoint.GetByStockItem(stockid, itemid);
            if (stockitem == null)
            {
                stockitem x = new stockitem
                {
                    ItemId = itemid,
                    StockId = stockid,
                    Balance = 0,
                    UnitId = item.UnitId
                };
                output = x;
                return output;
            }
            else
            {
                output = stockitem;
                return output;
            }    
        }
        public stockitem GetFinalDismisStock(decimal qty,int itemid,int unitid,int stockid)
        {
            stockitem output = new stockitem();
            var stockitem = stockItemEndPoint.GetByStockItem(stockid, itemid);
            if (stockitem.UnitId ==unitid)
            {
                stockitem.Balance -= qty;
                output = stockitem;
                return output;
            }
            else
            {
                var x = unitEndPoint.GetByID(unitid);
                var y = unitEndPoint.GetByID(stockitem.UnitId);
                stockitem.UnitId = unitid;
                stockitem.Balance = unitConversions.GetConvert(y, x, stockitem.Balance) - qty;
                output = stockitem;
            }
            return output;
        }
    }
}

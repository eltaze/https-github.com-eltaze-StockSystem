using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IStockItemEndPoint
    {
        void Delete(stockitem t);
        List<stockitem> GetAll();
        stockitem GetByID(int id);
        void Save(stockitem t);
        stockitem Update(stockitem t);
        List<stockitem> GetItemByStock(int id);
        stockitem GetByStockItem(int stockid, int itemid);
    }
}
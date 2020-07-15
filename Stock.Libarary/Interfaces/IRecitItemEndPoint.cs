using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IRecitItemEndPoint
    {
        void Delete(ItemRecit t);
        List<ItemRecit> GetAll();
        ItemRecit GetByID(int id);
        ItemRecit GetByMoveOrderId(int id);
        List<ItemRecit> GetByStockId(int id);
        int Save(ItemRecit t, List<stockitem> stockitems);
        ItemRecit Update(ItemRecit t);
    }
}
using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IDismisItemEndPoint
    {
        void Delete(DismisItem t);
        List<DismisItem> GetAll();
        DismisItem GetByID(int id);
        List<DismisItem> GetByStockId(int id);
        int Save(DismisItem t, List<stockitem> stockitems);
        DismisItem Update(DismisItem t);
    }
}
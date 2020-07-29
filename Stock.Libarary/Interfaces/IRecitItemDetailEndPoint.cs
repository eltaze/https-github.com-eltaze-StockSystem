using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IRecitItemDetailEndPoint
    {
        void Delete(ItemRecitDetail t);
        List<ItemRecitDetail> GetAll();
        List<ItemRecitDetail> GetByItemId(int id);
        List<ItemRecitDetail> GetByRecitID(int id);
        List<ItemRecitDetail> GetBySearch(int itemid, int recitid);
        void Save(ItemRecitDetail t);
        ItemRecitDetail Update(ItemRecitDetail t);
        
    }
}
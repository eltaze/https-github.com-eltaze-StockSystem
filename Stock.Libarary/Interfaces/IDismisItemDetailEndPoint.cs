using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IDismisItemDetailEndPoint
    {
        void Delete(DismisItemDetail t);
        List<DismisItemDetail> GetAll();
        List<DismisItemDetail> GetByItemId(int id);
        List<DismisItemDetail> GetByRecitID(int id);
        List<DismisItemDetail> GetBySearch(int itemid, int recitid);
        void Save(DismisItemDetail t);
        DismisItemDetail Update(DismisItemDetail t);
    }
}
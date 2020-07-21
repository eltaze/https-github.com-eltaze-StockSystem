using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface ImoveorderEndPoint
    {
        void Delete(MoveOrder t);
        List<MoveOrder> GetAll();
        MoveOrder GetByBarcode(string barcde);
        MoveOrder GetByID(int id);
        List<MoveOrder> GetByStockId(int stockid);
        int Save(MoveOrder t);
        MoveOrder Update(MoveOrder t);
        List<MoveOrder> GetMoveOrdersNotRecit();
    }
}
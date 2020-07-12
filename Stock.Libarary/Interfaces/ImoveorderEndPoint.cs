using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface ImoveorderEndPoint
    {
        void Delete(moveorder t);
        List<moveorder> GetAll();
        moveorder GetByBarcode(string barcde);
        moveorder GetByID(int id);
        List<moveorder> GetByStockId(int stockid);
        int Save(moveorder t);
        moveorder Update(moveorder t);
    }
}
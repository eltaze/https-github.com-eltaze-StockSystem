using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface ImoveorderdetailEndPoint
    {
        void Delete(moveorderdetail t);
        List<moveorderdetail> GetAll();
        moveorderdetail GetByID(int id);
        List<moveorderdetail> GetByItemId(int Id);
        List<moveorderdetail> GetBySeGetByOrderDetailId(int id);
        void Save(moveorderdetail t);
        moveorderdetail Update(moveorderdetail t);
    }
}
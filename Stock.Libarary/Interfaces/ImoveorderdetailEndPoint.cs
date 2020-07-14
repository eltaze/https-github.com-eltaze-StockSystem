using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface ImoveorderdetailEndPoint
    {
        void Delete(MoveOrderDetail t);
        List<MoveOrderDetail> GetAll();
        MoveOrderDetail GetByID(int id);
        List<MoveOrderDetail> GetByItemId(int Id);
        List<MoveOrderDetail> GetBySeGetByOrderDetailId(int id);
        void Save(MoveOrderDetail t);
        MoveOrderDetail Update(MoveOrderDetail t);
        List<MoveOrderDetail> GetByMoveOrderId(int id);
    }
}
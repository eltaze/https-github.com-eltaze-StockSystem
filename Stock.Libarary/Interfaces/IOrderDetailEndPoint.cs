using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IOrderDetailEndPoint
    {
        void Delete(OrderDetail t);
        List<OrderDetail> GetAll();
        List<OrderDetail> GetByID(int id);
        List<OrderDetail> GetByItemId(int id);
        void Save(OrderDetail t);
        OrderDetail Update(OrderDetail t);
    }
}
using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IOrderEndPoint
    {
        void Delete(Order t);
        List<Order> GetAll();
        Order GetByID(int id);
        Order Save(Order t);
        Order Update(Order t);
    }
}
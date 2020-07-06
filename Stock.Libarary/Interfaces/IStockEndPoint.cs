using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IStockEndPoint
    {
        void Delete(Stock t);
        List<Stock> GetAll();
        Stock GetByID(int id);
        Stock GetByName(string Name);
        void Save(Stock t);
        Stock Update(Stock t);
    }
}
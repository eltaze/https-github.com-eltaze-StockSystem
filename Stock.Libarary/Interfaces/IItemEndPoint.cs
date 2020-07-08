using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IItemEndPoint
    {
        void Delete(Item t);
        List<Item> GetAll();
        Item GetByID(int id);
        Item GetByName(string Name);
        void Save(Item t);
        Item Update(Item t);
        Item GetByBarcode(string Barcode);
    }
}
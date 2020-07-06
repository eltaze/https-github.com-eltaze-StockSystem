using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IKindEndPoint
    {
        void Delete(Kind t);
        List<Kind> GetAll();
        Kind GetByID(int id);
        Kind GetByName(string Name);
        void Save(Kind t);
        Kind Update(Kind t);
    }
}
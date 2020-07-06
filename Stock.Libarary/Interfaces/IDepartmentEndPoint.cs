using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IDepartmentEndPoint
    {
        void Delete(department t);
        List<department> GetAll();
        department GetByID(int id);
        department GetByName(string Name);
        void Save(department t);
        department Update(department t);
    }
}
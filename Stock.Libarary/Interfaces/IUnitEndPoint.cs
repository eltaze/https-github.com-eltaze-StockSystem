using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IUnitEndPoint
    {
        void Delete(Unit t);
        List<Unit> GetAll();
        Unit GetByID(int id);
        Unit GetByName(string Name);
        void Save(Unit t);
        Unit Update(Unit t);
        List<Unit> GetByUnitID(int id);
        List<Unit> GetByUnitIdTest(int id);
    }
}
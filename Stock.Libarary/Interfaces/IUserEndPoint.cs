using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IUserEndPoint
    {
        void Delete(User t);
        List<User> GetAll();
        User GetByID(int id);
        User GetByName(string Name);
        void Save(User t);
        User Update(User t);
    }
}
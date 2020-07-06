
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Interfaces
{
    public interface IReposit<T> where T : class
    {
        T GetByID(int id);
        List<T> GetAll();
        void Save(T t);
        T Update(T t);
        void Delete(T t);
        List<T> GetBySearch(String search);
        T GetByName(String Name);
    }
}




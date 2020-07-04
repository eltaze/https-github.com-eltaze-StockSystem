
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public interface IReposit<T> where T : class
    {
        T GetByID(int id);
        List<T> GetAll();
        T Save(T t);
        T Update(T t);
        T Delete(T t);
        List<T> GetBySearch(String search);
    }
}




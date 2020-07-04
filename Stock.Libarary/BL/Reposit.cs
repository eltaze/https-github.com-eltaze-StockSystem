using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public abstract class Reposit<T> : IReposit<T> where T : class
    {
        public abstract T Delete(T t);
        public abstract List<T> GetAll();
        public abstract T GetByID(int id);
        public virtual List<T> GetBySearch(string search)
        {
            throw new NotImplementedException();
        }
        public abstract T Save(T t);
        public abstract T Update(T t);
    }
}

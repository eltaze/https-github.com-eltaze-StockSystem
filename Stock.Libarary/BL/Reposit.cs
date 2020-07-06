using StockSystem.Libarary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public abstract class Reposit<T> : IReposit<T> where T : class
    {
        public abstract void Delete(T t);
        public abstract List<T> GetAll();
        public abstract T GetByID(int id);

        public virtual T GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetBySearch(string search)
        {
            throw new NotImplementedException();
        }
        public abstract void Save(T t);
        public abstract T Update(T t);
    }
}

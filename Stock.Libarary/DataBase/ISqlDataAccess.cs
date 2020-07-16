using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockSystem.Libarary.DataBase
{
    public interface ISqlDataAccess : IDisposable
    {
        void Execute<T, U>(string str, U Parameter);
        List<T> ReadingData<T, U>(string str, U Parmater);
        void starttransaction();
        void commitrasaction();
        void rollbacktrasaction();
        void SaveTrans<T, U>(string storedproc, U parameter);
        List<T> ReadingTrans<T, U>(string storedproc, U parameter);
        void ExecuteTrans<T, U>(string storedproc, U parameter);
        void Dispose();
    }
}
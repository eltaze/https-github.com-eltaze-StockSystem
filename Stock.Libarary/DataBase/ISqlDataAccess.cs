using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockSystem.Libarary.DataBase
{
    public interface ISqlDataAccess
    {
        void Execute<T, U>(string str, U Parameter);
        List<T> ReadingData<T, U>(string str, U Parmater);
    }
}
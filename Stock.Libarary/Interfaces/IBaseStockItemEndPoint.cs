using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IBaseStockItemEndPoint
    {
        List<BaseItemStock> GetAllItemStock(int id);
        List<BaseStockITem> GetAllStockItem(int id);
    }
}
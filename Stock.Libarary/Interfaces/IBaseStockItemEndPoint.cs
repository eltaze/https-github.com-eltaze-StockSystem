using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IBaseStockItemEndPoint
    {
        /// <summary>
        /// Return all Quantity from all stock for item
        ///</summary>
        /// <param name = "Id" > Item Id Property</param>
        /// <returns></returns>
        List<BaseItemStock> GetAllItemStock(int id);
        /// <summary>
        /// Return all item and quantity in particulare stock
        ///</summary>
        /// <param name = "Id" >stock Id Property </param>
        /// <returns></returns>
        List<BaseStockITem> GetAllStockItem(int id);
    }
}
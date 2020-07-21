using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IItemCardEndPoint
    {
        List<ItemCard> GetItemCards(int ItemId, int StockId);
    }
}
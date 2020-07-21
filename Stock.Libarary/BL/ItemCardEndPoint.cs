using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class ItemCardEndPoint : IItemCardEndPoint
    {
        private readonly ISqlDataAccess sql;

        public ItemCardEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public List<ItemCard> GetItemCards(int ItemId, int StockId)
        {
            //spItemsCard
            try
            {
                var output = sql.ReadingData<ItemCard, dynamic>("spItemsCard", new { ItemId, StockId });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class BaseStockItemEndPoint : IBaseStockItemEndPoint
    {
        private readonly ISqlDataAccess sql;

        public BaseStockItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public List<BaseStockITem> GetAllStockItem(int id)
        {
            try
            {
                var output = sql.ReadingData<BaseStockITem, dynamic>("spGetITemByStock", new { id });
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        public List<BaseItemStock> GetAllItemStock(int id)
        {
            try
            {
                var output = sql.ReadingData<BaseItemStock, dynamic>("spGetStockByItem", new { id });
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
    }
}

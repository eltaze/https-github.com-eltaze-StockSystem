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
        //// <summary>
        /// Return all Quantity from all stock for item
        /// </summary>
        /// <returns>Return item and quantity for stock.</returns>
        public List<BaseStockITem> GetAllStockItem(int id)
        {
            //<Summary>
            //Return item and quantity for stock
            //</Summary>
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
            //// <summary>
            /// Return all Quantity from all stock for item
            /// </summary>
            /// <returns>List of item and Quantity.</returns>
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

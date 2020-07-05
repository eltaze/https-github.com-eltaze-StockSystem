
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class StockItemEndPoint : Reposit<stockitem>
    {
        private readonly ISqlDataAccess sql;

        public StockItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override void Delete(stockitem t)
        {
            //spStockItemDelete
            try
            {
                sql.Execute<stockitem, dynamic>("spStockItemDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override List<stockitem> GetAll()
        {
            //spStockItemGetAll
            try
            {
                var output = sql.ReadingData<stockitem, dynamic>("spStockItemGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override stockitem GetByID(int id)
        {
            //spStockItemGetById
            try
            {
               var output = sql.ReadingData<stockitem, dynamic>("spStockItemGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override void Save(stockitem t)
        {
            //spStockItemInsert
            try
            {
                sql.Execute<stockitem, dynamic>("spStockItemInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override stockitem Update(stockitem t)
        {
            //spStockItemUpdate
            try
            {
                sql.Execute<stockitem, dynamic>("spStockItemUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

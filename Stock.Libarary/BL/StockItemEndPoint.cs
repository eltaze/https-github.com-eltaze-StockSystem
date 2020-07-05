
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
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
        public override stockitem Delete(stockitem t)
        {
            //spStockItemDelete
            throw new NotImplementedException();
        }

        public override List<stockitem> GetAll()
        {
            //spStockItemGetAll
            throw new NotImplementedException();
        }

        public override stockitem GetByID(int id)
        {
            //spStockItemGetById
            throw new NotImplementedException();
        }

        public override stockitem Save(stockitem t)
        {
            //spStockItemInsert
            throw new NotImplementedException();
        }

        public override stockitem Update(stockitem t)
        {
            //spStockItemUpdate
            throw new NotImplementedException();
        }
    }
}

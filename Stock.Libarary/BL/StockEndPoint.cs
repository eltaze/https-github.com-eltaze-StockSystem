using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class StockEndPoint : Reposit<Stock>
    {
        private readonly ISqlDataAccess sql;

        public StockEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override Stock Delete(Stock t)
        {
            //spStockDelete
            throw new NotImplementedException();
        }

        public override List<Stock> GetAll()
        {
            //spStockGetAll
            throw new NotImplementedException();
        }

        public override Stock GetByID(int id)
        {
            //spStockGetById
            throw new NotImplementedException();
        }

        public override Stock Save(Stock t)
        {
            //spStockInsert
            throw new NotImplementedException();
        }

        public override Stock Update(Stock t)
        {
            //spStockUpdate
            throw new NotImplementedException();
        }
    }
}

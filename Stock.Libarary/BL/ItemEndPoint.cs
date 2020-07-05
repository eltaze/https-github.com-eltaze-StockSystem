
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class ItemEndPoint : Reposit<Item>
    {
        private readonly ISqlDataAccess sql;

        public ItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override Item Delete(Item t)
        {
            //spItemDelete
            throw new NotImplementedException();
        }

        public override List<Item> GetAll()
        {
            //spItemGetAll
            throw new NotImplementedException();
        }

        public override Item GetByID(int id)
        {
            //spItemGetById
            throw new NotImplementedException();
        }

        public override Item Save(Item t)
        {
            //[spItemInsert]
            throw new NotImplementedException();
        }

        public override Item Update(Item t)
        {
            //spItemUpdate
            throw new NotImplementedException();
        }
    }
}

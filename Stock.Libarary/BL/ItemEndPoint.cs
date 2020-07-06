
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class ItemEndPoint : Reposit<Item>, IItemEndPoint
    {
        private readonly ISqlDataAccess sql;

        public ItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override void Delete(Item t)
        {
            //spItemDelete
            try
            {
                sql.Execute<Item, dynamic>("spItemDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override List<Item> GetAll()
        {
            //spItemGetAll
            try
            {
                var output = sql.ReadingData<Item, dynamic>("spItemGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Item GetByID(int id)
        {
            //spItemGetById
            try
            {
                var output = sql.ReadingData<Item, dynamic>("spItemGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override void Save(Item t)
        {
            //[spItemInsert]
            try
            {
                sql.Execute<Item, dynamic>("spItemInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Item Update(Item t)
        {
            //spItemUpdate
            try
            {
                sql.Execute<Item, dynamic>("spItemUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Item GetByName(string Name)
        {
            //spItemGetByName
            try
            {
                var output = sql.ReadingData<Item, dynamic>("spItemGetByName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

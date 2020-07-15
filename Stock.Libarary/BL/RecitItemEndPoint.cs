using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class RecitItemEndPoint : IRecitItemEndPoint
    {
        private readonly ISqlDataAccess sql;

        public RecitItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }

        public void Delete(ItemRecit t)
        {
            //spRecitItemsDelete
            try
            {
                sql.Execute<ItemRecit, dynamic>("spRecitItemsDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<ItemRecit> GetAll()
        {
            //spRecitItemsGetAll
            try
            {
                var output = sql.ReadingData<ItemRecit, dynamic>("spRecitItemsGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public ItemRecit GetByID(int id)
        {
            //spRecitItemsGetById
            try
            {
                var output = sql.ReadingData<ItemRecit, dynamic>("spRecitItemsGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public ItemRecit GetByMoveOrderId(int id)
        {
            //spRecitItemsBymoveorderId
            try
            {
                var output = sql.ReadingData<ItemRecit, dynamic>("spRecitItemsBymoveorderId", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<ItemRecit> GetByStockId(int id)
        {
            //spRecitItemsByStockId
            try
            {
                var output = sql.ReadingData<ItemRecit, dynamic>("spRecitItemsByStockId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int Save(ItemRecit t, List<stockitem> stockitems)
        {
            //spRecitItemsInsert
            try
            {
                sql.starttransaction();
                int x = sql.SaveTrans<ItemRecit, dynamic>("spRecitItemsInsert", t);
                foreach (ItemRecitDetail item in t.recitItemDetails)
                {
                    item.RecitItemId = x;
                    sql.ExecuteTrans<ItemRecitDetail, dynamic>("spRecitItemDetailInsert", item);
                }
                foreach (stockitem item in stockitems)
                {
                    sql.ExecuteTrans<stockitem, dynamic>("spStockItemUpdate", item);
                }
                sql.commitrasaction();
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public ItemRecit Update(ItemRecit t)
        {
            //spRecitItemsUpdate
            try
            {
                sql.Execute<ItemRecit, dynamic>("spRecitItemsUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

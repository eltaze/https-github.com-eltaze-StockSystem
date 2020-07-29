using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
                sql.Execute<ItemRecit, dynamic>("spRecitItemsDelete", new { id= t.Id });
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

              
                 sql.SaveTrans<ItemRecit, dynamic>("spRecitItemsInsert",new { moveorderid = t.MoveOrderId,  t.Note, odate = t.Odate, t.RecitFrom, stockid = t.StockId });
                int x = sql.ReadingTrans<ItemRecit, dynamic>("spRecitItemsGetLast", new { }).FirstOrDefault().Id;
                foreach (ItemRecitDetail item in t.recitItemDetails)
                {
                    item.RecitItemId = x;
                    sql.ExecuteTrans<ItemRecitDetail, dynamic>("spRecitItemDetailInsert", item);
                }
                foreach (stockitem item in stockitems)
                {
                    if (item.Id != 0)
                    {
                        sql.ExecuteTrans<stockitem, dynamic>("spStockItemUpdate", item);
                    }
                    else
                    {
                        sql.ExecuteTrans<stockitem, dynamic>("spStockItemInsert", item);
                    }
                }
                sql.commitrasaction();
                return x;
            }
            catch (Exception ex)
            {
                sql.rollbacktrasaction();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sql.Dispose();
            }
        }
        public ItemRecit Update(ItemRecit t)
        {
            //spRecitItemsUpdate
            try
            {
                sql.Execute<ItemRecit, dynamic>("spRecitItemsUpdate", new {
                    Id=t.Id,
                    stockid=t.StockId,
                    odate =t.Odate,
                    RecitFrom=t.RecitFrom,
                    moveorderid=t.MoveOrderId,
                    Note=t.Note
                });
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

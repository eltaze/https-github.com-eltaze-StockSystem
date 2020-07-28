using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockSystem.Libarary.BL
{
    public class DismisItemEndPoint : IDismisItemEndPoint
    {
        private readonly ISqlDataAccess sql;

        public DismisItemEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public void Delete(DismisItem t)
        {
            //spDismisItemsDelete
            try
            {
                sql.Execute<DismisItem, dynamic>("spDismisItemsDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<DismisItem> GetAll()
        {
            //spDismisItemsGetAll
            try
            {
                var output = sql.ReadingData<DismisItem, dynamic>("spDismisItemsGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public DismisItem GetByID(int id)
        {
            //spDismisItemsGetById
            try
            {
                var output = sql.ReadingData<DismisItem, dynamic>("spDismisItemsGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<DismisItem> GetByStockId(int id)
        {
            //spDismisItemsByStockId
            try
            {
                var output = sql.ReadingData<DismisItem, dynamic>("spDismisItemsByStockId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public int Save(DismisItem t, List<stockitem> stockitems)
        {
            //spDismisItemsInsert
            try
            {
                sql.starttransaction();


                sql.SaveTrans<DismisItem, dynamic>("spDismisItemsInsert", new { t.Note, odate = t.Odate, t.DismisTo, stockid = t.StockId });
                int x = sql.ReadingTrans<DismisItem, dynamic>("spDismisItemsGetLast", new { }).FirstOrDefault().Id;
                foreach (DismisItemDetail item in t.recitItemDetails)
                {
                    item.DismisItemId = x;
                    sql.ExecuteTrans<ItemRecitDetail, dynamic>("spDismisItemDetailInsert", item);
                }
                foreach (stockitem item in stockitems)
                {
                    if (item.Id != 0)
                    {
                        sql.ExecuteTrans<stockitem, dynamic>("spStockItemUpdate", new { Id=item.Id,StockId=item.StockId, ItemId= item.ItemId, Balance =item.Balance, Note=item.Note, unitid=item.UnitId });
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

        public DismisItem Update(DismisItem t)
        {
            //spDismisItemsUpdate
            try
            {
                sql.Execute<DismisItem, dynamic>("spDismisItemsUpdate",new 
                {
                    Id =t.Id,
                    stockid =t.StockId,
                    odate =t.Odate,
                    RecitFrom = t.DismisTo,
                    Note = t.Note
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

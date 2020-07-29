using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;

namespace StockSystem.Libarary.BL
{
    public class RecitItemDetailEndPoint : IRecitItemDetailEndPoint
    {
        private readonly ISqlDataAccess sql;

        public RecitItemDetailEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }

        public void Delete(ItemRecitDetail t)
        {
            //[spRecitItemDetailDelete]
            try
            {
                sql.Execute<ItemRecitDetail, dynamic>("spRecitItemDetailDelete", new { t.Id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<ItemRecitDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ItemRecitDetail> GetByRecitID(int id)
        {
            //spRecitItemDetailGetByRecitId
            try
            {
                var output = sql.ReadingData<ItemRecitDetail, dynamic>("spRecitItemDetailGetByRecitId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<ItemRecitDetail> GetByItemId(int id)
        {
            //spRecitItemDetailGetByItemId
            try
            {
                var output = sql.ReadingData<ItemRecitDetail, dynamic>("spRecitItemDetailGetByRecitId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<ItemRecitDetail> GetBySearch(int itemid, int recitid)
        {
            //[spRecitItemDetailGetByItemIdRecitId]
            try
            {
                var output = sql.ReadingData<ItemRecitDetail, dynamic>("spRecitItemDetailGetByItemIdRecitId", new { itemid, recitid });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Save(ItemRecitDetail t)
        {
            try
            {
                sql.Execute<ItemRecitDetail, dynamic>("spRecitItemDetailInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public ItemRecitDetail Update(ItemRecitDetail t)
        {
            //[spRecitItemDetailUpdate]
            try
            {
                sql.ReadingData<ItemRecitDetail, dynamic>("spRecitItemDetailUpdate", new {id = t.Id, RecitItemid=t.RecitItemId,
                itemid=t.ItemId,note=t.Note,qty=t.Qty,unitid=t.UnitId});
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

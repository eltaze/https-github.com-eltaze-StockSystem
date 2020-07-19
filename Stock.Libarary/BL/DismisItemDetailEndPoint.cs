using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;


namespace StockSystem.Libarary.BL
{
    public class DismisItemDetailEndPoint : IDismisItemDetailEndPoint
    {
        private readonly ISqlDataAccess sql;
        public DismisItemDetailEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public void Delete(DismisItemDetail t)
        {
            //spDismisItemDetailDelete
            try
            {
                sql.Execute<ItemRecitDetail, dynamic>("spDismisItemDetailDelete", new { t.Id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<DismisItemDetail> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<DismisItemDetail> GetByRecitID(int id)
        {
            //spDismisItemDetailGetByRecitId
            try
            {
                var output = sql.ReadingData<DismisItemDetail, dynamic>("spDismisItemDetailGetByRecitId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<DismisItemDetail> GetByItemId(int id)
        {
            //spDismisItemDetailGetByItemId
            try
            {
                var output = sql.ReadingData<DismisItemDetail, dynamic>("spDismisItemDetailGetByItemId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<DismisItemDetail> GetBySearch(int itemid, int recitid)
        {
            //spDismisItemDetailGetByItemIdRecitId
            try
            {
                var output = sql.ReadingData<DismisItemDetail, dynamic>("spDismisItemDetailGetByItemIdRecitId", new { itemid, recitid });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Save(DismisItemDetail t)
        {
            //spDismisItemDetailInsert
            try
            {
                sql.Execute<DismisItemDetail, dynamic>("spDismisItemDetailInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public DismisItemDetail Update(DismisItemDetail t)
        {
            //[spDismisItemDetailUpdate]
            try
            {
                sql.ReadingData<DismisItemDetail, dynamic>("spDismisItemDetailUpdate", new { t });
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

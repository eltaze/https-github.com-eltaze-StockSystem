using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockSystem.Libarary.BL
{
    public class moveorderdetailEndPoint : ImoveorderdetailEndPoint
    {
        private readonly ISqlDataAccess sql;
        public moveorderdetailEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public void Delete(moveorderdetail t)
        {
            throw new NotImplementedException();
        }
        public List<moveorderdetail> GetAll()
        {
            try
            {
                var output = sql.ReadingData<moveorderdetail, dynamic>("", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public moveorderdetail GetByID(int id)
        {
            try
            {
                //spmoveorderdetailGetById
                var output = sql.ReadingData<moveorderdetail, dynamic>("spmoveorderdetailGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<moveorderdetail> GetByItemId(int Id)
        {
            //spmoveorderdetailGetByItemId
            try
            {
                var output = sql.ReadingData<moveorderdetail, dynamic>("spmoveorderdetailGetByItemId", new { Id });
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<moveorderdetail> GetBySeGetByOrderDetailId(int id)
        {
            try
            {
                //spmoveorderdetailGetByOrderDetailId
                var output = sql.ReadingData<moveorderdetail, dynamic>("spmoveorderdetailGetByOrderDetailId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Save(moveorderdetail t)
        {
            try
            {
                //spmoveorderdetailinsert
                sql.Execute<moveorderdetail, dynamic>("spmoveorderdetailinsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public moveorderdetail Update(moveorderdetail t)
        {
            try
            {
                //spmoveorderdetailupdate
                sql.Execute<moveorderdetail, dynamic>("spmoveorderdetailupdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

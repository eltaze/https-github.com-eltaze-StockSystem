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
        public void Delete(MoveOrderDetail t)
        {
            throw new NotImplementedException();
        }
        public List<MoveOrderDetail> GetAll()
        {
            try
            {
                var output = sql.ReadingData<MoveOrderDetail, dynamic>("", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public MoveOrderDetail GetByID(int id)
        {
            try
            {
                //spmoveorderdetailGetById
                var output = sql.ReadingData<MoveOrderDetail, dynamic>("spmoveorderdetailGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<MoveOrderDetail> GetByItemId(int Id)
        {
            //spmoveorderdetailGetByItemId
            try
            {
                var output = sql.ReadingData<MoveOrderDetail, dynamic>("spmoveorderdetailGetByItemId", new { Id });
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MoveOrderDetail> GetBySeGetByOrderDetailId(int id)
        {
            try
            {
                //spmoveorderdetailGetByOrderDetailId
                var output = sql.ReadingData<MoveOrderDetail, dynamic>("spmoveorderdetailGetByOrderDetailId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Save(MoveOrderDetail t)
        {
            try
            {
                //spmoveorderdetailinsert
                sql.Execute<MoveOrderDetail, dynamic>("spmoveorderdetailinsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public MoveOrderDetail Update(MoveOrderDetail t)
        {
            try
            {
                //spmoveorderdetailupdate
                sql.Execute<MoveOrderDetail, dynamic>("spmoveorderdetailupdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<MoveOrderDetail> GetByMoveOrderId(int id)
        {
            //spmoveorderdetailGetByMoveOrderId 
            try
            {
                //spmoveorderdetailGetByOrderDetailId
                var output = sql.ReadingData<MoveOrderDetail, dynamic>("spmoveorderdetailGetByMoveOrderId", new { id });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

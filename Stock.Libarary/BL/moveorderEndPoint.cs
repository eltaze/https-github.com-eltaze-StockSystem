using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockSystem.Libarary.BL
{
    public class moveorderEndPoint : ImoveorderEndPoint
    {
        private readonly ISqlDataAccess sql;

        public moveorderEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }

        public void Delete(moveorder t)
        {
            throw new NotImplementedException();
        }

        public List<moveorder> GetAll()
        {
            //spmoveorderGetAll
            try
            {
                var output = sql.ReadingData<moveorder, dynamic>("spmoveorderGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public moveorder GetByID(int id)
        {
            //spmoveorderGetById
            try
            {
                var output = sql.ReadingData<moveorder, dynamic>("spmoveorderGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public moveorder GetByBarcode(string barcde)
        {
            //spmoveorderGetByBarCode
            try
            {
                var output = sql.ReadingData<moveorder, dynamic>("spmoveorderGetByBarCode", new { barcde }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<moveorder> GetByStockId(int stockid)
        {
            //spmoveorderGetBystockId
            try
            {
                var output = sql.ReadingData<moveorder, dynamic>("spmoveorderGetBystockId", new { stockid }).ToList();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public int Save(moveorder t)
        {
            //spmoveorderInsert
            try
            {
                sql.starttransaction();
                var id = sql.SaveTrans<moveorder, dynamic>("spmoveorderInsert", t);
                foreach (moveorderdetail item in t.moveorderdetails)
                {
                    item.Moveorderid = id;
                    sql.ExecuteTrans<moveorderdetail, dynamic>("spmoveorderdetailinsert", item);
                }
                sql.commitrasaction();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public moveorder Update(moveorder t)
        {
            //spomveorderUpdate
            try
            {
                sql.Execute<moveorder, dynamic>("spomveorderUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

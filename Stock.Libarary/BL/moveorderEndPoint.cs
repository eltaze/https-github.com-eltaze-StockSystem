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

        public void Delete(MoveOrder t)
        {
            throw new NotImplementedException();
        }

        public List<MoveOrder> GetAll()
        {
            //spmoveorderGetAll
            try
            {
                var output = sql.ReadingData<MoveOrder, dynamic>("spmoveorderGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public MoveOrder GetByID(int id)
        {
            //spmoveorderGetById
            try
            {
                var output = sql.ReadingData<MoveOrder, dynamic>("spmoveorderGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public MoveOrder GetByBarcode(string barcde)
        {
            //spmoveorderGetByBarCode
            try
            {
                var output = sql.ReadingData<MoveOrder, dynamic>("spmoveorderGetByBarCode", new { barcde }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<MoveOrder> GetByStockId(int stockid)
        {
            //spmoveorderGetBystockId
            try
            {
                var output = sql.ReadingData<MoveOrder, dynamic>("spmoveorderGetBystockId", new { stockid }).ToList();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public int Save(MoveOrder t)
        {
            //spmoveorderInsert
            try
            {
                sql.starttransaction();
                 sql.SaveTrans<MoveOrder, dynamic>("spmoveorderInsert", t);
                var id = sql.ReadingTrans<MoveOrder, dynamic>("spmoveorderGetLast", t).FirstOrDefault().Id;
                foreach (MoveOrderDetail item in t.moveorderdetails)
                {
                    item.Moveorderid = id;
                    sql.ExecuteTrans<MoveOrderDetail, dynamic>("spmoveorderdetailinsert", item);
                }
                sql.commitrasaction();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public MoveOrder Update(MoveOrder t)
        {
            //spomveorderUpdate
            try
            {
                sql.Execute<MoveOrder, dynamic>("spomveorderUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

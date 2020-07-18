using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class StockEndPoint : IStockEndPoint
    {
        private readonly ISqlDataAccess sql;

        public StockEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public  void Delete(Stock t)
        {
            //spStockDelete
            try
            {
                sql.Execute<Stock, dynamic>("spStockDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public  List<Stock> GetAll()
        {
            //spStockGetAll
            try
            {
                var output = sql.ReadingData<Stock, dynamic>("spStockGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public  Stock GetByID(int id)
        {
            //spStockGetById
            try
            {
                var output = sql.ReadingData<Stock, dynamic>("spStockGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public  void Save(Stock t)
        {
            //spStockInsert
            try
            {
                sql.Execute<Stock, dynamic>("spStockInsert", new { Name = t.Name,Note = t.Note});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public  Stock Update(Stock t)
        {
            //spStockUpdate
            try
            {
                sql.Execute<Stock, dynamic>("spStockUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public  Stock GetByName(string Name)
        {
            //spStockGetByName
            try
            {
                var output = sql.ReadingData<Stock, dynamic>("spStockGetByName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

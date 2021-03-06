﻿using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockSystem.Libarary.BL
{
    public class OrderDetailEndPoint : IOrderDetailEndPoint
    {
        private readonly ISqlDataAccess sql;

        public OrderDetailEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public void Delete(OrderDetail t)
        {
            //sporderdetailDelete
            try
            {
                sql.Execute<OrderDetail, dynamic>("sporderdetailDelete", t);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        public List<OrderDetail> GetAll()
        {
            //spOrderdetailsGetAll
            try
            {
                var output = sql.ReadingData<OrderDetail, dynamic>("spOrderdetailsGetAll", new { }).ToList();
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All Byt Order Id and not orderdetail Id
        /// </summary>
        /// <param name="id">this is orderid not orderdetail id</param>
        /// <returns></returns>
        public List<OrderDetail> GetByID(int id)
        {
            //sporderdetailsGetById -order id
            try
            {
                var output = sql.ReadingData<OrderDetail, dynamic>("sporderdetailsGetById", new { id }).ToList();
                return output;

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Save(OrderDetail t)
        {
            //sporderdetailInsert
            try
            {
                sql.Execute<OrderDetail, dynamic>("sporderdetailInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public OrderDetail Update(OrderDetail t)
        {
            //spOrderDetailUpdate
            try
            {
                sql.Execute<OrderDetail, dynamic>("spOrderDetailUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<OrderDetail> GetByItemId(int id)
        {
            //sporderdetailsGetByItemId
            try
            {
                var output=sql.ReadingData<OrderDetail, dynamic>("sporderdetailsGetByItemId", new { id}).ToList();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public OrderDetail GetLastPriceByItem(int id)
        {
            // spOrderdetailsGetLastPrice
            try
            {
                var output = sql.ReadingData<OrderDetail, dynamic>("spOrderdetailsGetLastPrice", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<OrderDetail> GetOrderDetailsByMoveOrder()
        {
            //spOrderDetailsMoveOrder
            try
            {
                var output = sql.ReadingData<OrderDetail, dynamic>("spOrderDetailsMoveOrder", new { }).ToList();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void DeleteByOrderId(int id)
        {
            //[sporderdetailDeleteByOrderId]
            try
            {
                sql.Execute<OrderDetail, dynamic>("sporderdetailDeleteByOrderId", new {id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

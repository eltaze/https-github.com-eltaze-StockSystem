using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class OrderEndPoint : IOrderEndPoint
    {
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly ISqlDataAccess sql;

        public OrderEndPoint(IOrderDetailEndPoint orderDetailEndPoint,ISqlDataAccess sql)
        {
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.sql = sql;
        }
        public void Delete(Order t)
        {
            //sporderDelete
            try
            {
                sql.starttransaction();
               var output= orderDetailEndPoint.GetByID(t.Id).ToList();
                foreach (var item in output)
                {
                    sql.ExecuteTrans<OrderDetail, dynamic>("sporderdetailDelete", item);
                }
                sql.ExecuteTrans<Order, dynamic>("sporderDelete", t);
                sql.commitrasaction();
            }
            catch (Exception ex)
            {
                sql.rollbacktrasaction();
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<Order> GetAll()
        {
            //spOrderGetAll
            try
            {
                var output = sql.ReadingData<Order, dynamic>("spOrderGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        public Order GetByID(int id)
        {
            //spOrderGetById
            try
            {
                var output = sql.ReadingData<Order, dynamic>("spOrderGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Order Save(Order t)
        {
            //spOrdersInsert
            try
            {
                sql.starttransaction();
                int x = sql.SaveTrans<Order, dynamic>("spOrdersInsert", t);
                foreach (var item in t.OrderDetails)
                {
                    item.orderid = x;
                    sql.SaveTrans<OrderDetail, dynamic>("sporderdetailInsert", item);
                }
                t.Id = x;
                sql.commitrasaction();
                return t;
            }
            catch (Exception ex)
            {
                sql.rollbacktrasaction();
                throw new Exception(ex.Message.ToString());
            }
        }
        public Order Update(Order t)
        {
            ////spOrderUpdate
            try
            {
                sql.Execute<Order, dynamic>("spOrderUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

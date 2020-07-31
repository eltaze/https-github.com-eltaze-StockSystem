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
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly ISqlDataAccess sql;
        private readonly IStockItemEndPoint stockItemEndPoint;

        public OrderEndPoint(IOrderDetailEndPoint orderDetailEndPoint,
                             IItemEndPoint itemEndPoint,IUnitEndPoint unitEndPoint
                             ,ISqlDataAccess sql,IStockItemEndPoint stockItemEndPoint)
        {
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.sql = sql;
            this.stockItemEndPoint = stockItemEndPoint;
        }
        public void Delete(Order t)
        {
            //sporderDelete
            try
            {
                sql.Execute<Order, dynamic>("sporderDelete", new { t.Id});  
            }
            catch (Exception ex)
            {
                
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
                sql.SaveTrans<Order, dynamic>("spOrdersInsert", new  {stockid=t.StockId,odate=t.ODate,note=t.Note });
                int x = sql.ReadingTrans<Order, dynamic>("spOrderGetLast", new { }).FirstOrDefault().Id;
                foreach (OrderDetail item in t.OrderDetails)
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
                sql.Execute<Order, dynamic>("spOrderUpdate", new { t.Id,t.Note,t.ODate,t.StockId });
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

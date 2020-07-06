using StockSystem.Libarary.BL;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.BL
{
   public class Validation
    {
        public Validation(StockEndPoint stockEndPoint)
        {
            this.stockEndPoint = stockEndPoint;
        }
        public string massege;
        private readonly StockEndPoint stockEndPoint ;

        public bool validatestock(Stock stock)
        {
            if(string.IsNullOrEmpty(stock.Name) )
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            if (stock.Name ==" ")
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            var output = stockEndPoint.GetByName(stock.Name);
            if (output !=null)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
    }
}

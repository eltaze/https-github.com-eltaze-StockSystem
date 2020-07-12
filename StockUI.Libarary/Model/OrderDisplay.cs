using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockUI.Libarary.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
  public  class OrderDisplay
    {
        public int Id { get; set; }
        public DateTime ODate { get; set; }
        public int StockId { get; set; }
        public string Note { get; set; }
        public string StockName { get; set; }
        public decimal Total { get; set; }
        public string Tafgeet 
        {
            get
            {
                ConvertNumbersToArabicAlphabet convert = new ConvertNumbersToArabicAlphabet(Total.ToString());
                return convert.GetNumberAr();
            }
           
        }
        public List<OrderDetailDisplay> OrderDetails { get; set; } = new List<OrderDetailDisplay>();
    }
}

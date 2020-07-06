using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
   public class StockDisplay
    {
        private readonly IMapper mapper;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;

        public StockDisplay(IMapper mapper,IBaseStockItemEndPoint baseStockItemEndPoint)
        {
            this.mapper = mapper;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
        }
        public StockDisplay()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<BaseStockITemDisplay> baseStockITems
        {
            get
            {
                List<BaseStockITemDisplay> output = new List<BaseStockITemDisplay>();
                var x = baseStockItemEndPoint?.GetAllItemStock(Id);
                if (x !=null)
                {
                     output = mapper.Map<List<BaseStockITemDisplay>>(x);
                }
                return output;
            } 
         }
    }
}

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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<BaseStockITemDisplay> baseStockITems
        {
            get
            {
                var output = mapper.Map<List<BaseStockITemDisplay>>(baseStockItemEndPoint.GetAllItemStock(Id));
                return output;
            } 
         }
    }
}

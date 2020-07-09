using StockSystem.Libarary.Interfaces;
using System;

namespace StockUI.Libarary.Model
{
    public class OrderDetailDisplay
    {
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;

        public OrderDetailDisplay()
        {

        }
        public OrderDetailDisplay(IItemEndPoint itemEndPoint,IUnitEndPoint unitEndPoint)
        {
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
        }
        public int Id { get; set; }
        public int orderid { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public Decimal Qty { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Note { get; set; }
        public bool FirstApprove { get; set; }
        public bool SecondApprove { get; set; }
        public bool ThirdApprove { get; set; }

        public decimal  LastPrice
        {
            get { return 0; }
        }
        public string ItemName
        {
            get
            {
                var x = itemEndPoint.GetByID(ItemId);
                return x.Name;
            }
        }
        public string UnitName
        {
            get
            {
                var x = unitEndPoint.GetByID(UnitId);
                return x.Name;
            }
        }
    }
}

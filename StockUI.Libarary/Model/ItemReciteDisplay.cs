
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;


namespace StockUI.Libarary.Model
{
   public class ItemReciteDisplay
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public DateTime Odate { get; set; }
        public string RecitFrom { get; set; }
        public Nullable<int> MoveOrderId { get; set; }
        public string Note { get; set; }
        public List<ItemRecitDetailDisplay> recitItemDetails { get; set; } = new List<ItemRecitDetailDisplay>();
    }
}

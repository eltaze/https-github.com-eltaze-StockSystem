using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
  public  class ItemRecit
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public DateTime Odate { get; set; }
        public string RecitFrom { get; set; }
        public Nullable<int> MoveOrderId { get; set; }
        public string Note { get; set; }
        public List<ItemRecitDetail> recitItemDetails { get; set; } = new List<ItemRecitDetail>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class DismisItem
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public DateTime Odate { get; set; }
        public string DismisTo { get; set; }
        public string Note { get; set; }
        public List<DismisItemDetail> recitItemDetails { get; set; } = new List<DismisItemDetail>();
    }
}

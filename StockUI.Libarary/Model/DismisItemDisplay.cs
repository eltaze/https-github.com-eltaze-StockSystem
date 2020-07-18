using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
   public class DismisItemDisplay
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public DateTime Odate { get; set; }
        public string DismisTo { get; set; }
        public string Note { get; set; }
        public List<DismisItemDetailDisplay>  dismisItemDetailDisplays { get; set; } = new List<DismisItemDetailDisplay>();
    }
}

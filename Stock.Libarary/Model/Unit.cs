using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Libarary.Model
{
  public  class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int UnitId { get; set; }
        public decimal Qty { get; set; }
        public int KindId { get; set; }
    }   
}

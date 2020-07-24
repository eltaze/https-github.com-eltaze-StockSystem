using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
   public class Right
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Read { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}

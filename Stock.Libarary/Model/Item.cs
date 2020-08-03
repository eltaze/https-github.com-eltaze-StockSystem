using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int DepartmentId { get; set; }
        public string Note { get; set; }
        public int kindId { get; set; }
        public bool DisplayInDash { get; set; }
    }
}
    


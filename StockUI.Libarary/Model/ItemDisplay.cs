using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.Model
{
    public class ItemDisplay
    {
        private readonly IMapper mapper;

        public ItemDisplay(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int DepartmentId { get; set; }
        public string Note { get; set; }
        public int kindId { get; set; }
    }
}
    


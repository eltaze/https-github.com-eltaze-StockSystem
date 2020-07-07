using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class Items : Form
    {
        private readonly IMapper mapper;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IKindEndPoint kindEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly IStockEndPoint stockEndPoint;
        private List<ItemDisplay> itemDisplays = new List<ItemDisplay>();
        public Items(IMapper mapper,IUnitEndPoint unitEndPoint,IKindEndPoint kindEndPoint,IItemEndPoint itemEndPoint
            ,IBaseStockItemEndPoint baseStockItemEndPoint,IStockEndPoint stockEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.kindEndPoint = kindEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
            this.stockEndPoint = stockEndPoint;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            var output = itemEndPoint.GetAll();
            itemDisplays = mapper.Map<List<ItemDisplay>>(output);
            if (itemDisplays.Count>0)
            {

            }
        }
        #region Navigation

        #endregion
    }
}

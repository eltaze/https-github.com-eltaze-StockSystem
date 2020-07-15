using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmItemRecit : Form
    {
        private readonly IRecitItemDetailEndPoint recitItemDetailEndPoint;
        private readonly IRecitItemEndPoint recitItemEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly IStockEndPoint stockEndPoint;
        private List<ItemReciteDisplay> itemReciteDisplays = new List<ItemReciteDisplay>();
        private List<ItemRecitDetailDisplay> itemRecitDetailsDisplay = new List<ItemRecitDetailDisplay>();

        public FrmItemRecit(IRecitItemDetailEndPoint recitItemDetailEndPoint,IRecitItemEndPoint recitItemEndPoint,
            IItemEndPoint itemEndPoint,IUnitEndPoint unitEndPoint,UnitConversions unitConversions ,IStockEndPoint stockEndPoint)
        {
            InitializeComponent();
            this.recitItemDetailEndPoint = recitItemDetailEndPoint;
            this.recitItemEndPoint = recitItemEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.unitConversions = unitConversions;
            this.stockEndPoint = stockEndPoint;
        }
        private void FrmItemRecit_Load(object sender, EventArgs e)
        {
            var x = stockEndPoint.GetAll();
            CmbStock.DataSource = x.ToList();
            CmbStock.ValueMember = "Id";
            CmbStock.DisplayMember = "Name";

        }
    }
}

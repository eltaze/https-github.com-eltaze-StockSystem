using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmDismisItem : Form
    {
        private readonly IStockEndPoint stockEndPoint;
        private readonly IMapper mapper;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IDismisItemDetailEndPoint dismisItemDetailEndPoint;
        private readonly IDismisItemEndPoint dismisItemEndPoint;
        private readonly IStockItemEndPoint stockItemEndPoint;
        private List<Stock> stocks = new List<Stock>();
        private List<department> departments = new List<department>();
        private List<Item> items = new List<Item>();
        private List<Unit> units = new List<Unit>();
        private List<DismisItemDisplay> dismisItemDisplays = new List<DismisItemDisplay>();
        private List<DismisItemDetailDisplay> dismisItemDetailDisplays = new List<DismisItemDetailDisplay>();

        public FrmDismisItem(IStockEndPoint stockEndPoint,IMapper mapper,IUnitEndPoint unitEndPoint
                            ,IItemEndPoint itemEndPoint,UnitConversions unitConversions
                            ,IDepartmentEndPoint departmentEndPoint,IDismisItemDetailEndPoint dismisItemDetailEndPoint
                            ,IDismisItemEndPoint dismisItemEndPoint,IStockItemEndPoint stockItemEndPoint)
        {
            InitializeComponent();
            this.stockEndPoint = stockEndPoint;
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitConversions = unitConversions;
            this.departmentEndPoint = departmentEndPoint;
            this.dismisItemDetailEndPoint = dismisItemDetailEndPoint;
            this.dismisItemEndPoint = dismisItemEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
        }
        private void FrmDismisItem_Load(object sender, EventArgs e)
        {
            var st = stockEndPoint.GetAll();
            loadcmb<Stock>(st.ToList(), CmbStock);
            items = itemEndPoint.GetAll();
            departments = departmentEndPoint.GetAll();
            loadcmb<department>(departments, CmbDepartment);
        }
        private void loadcmb<T>(List<T> t, ComboBox comboBox)
        {
            comboBox.DataSource = t;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex ==-1 )
            {
                return;
            }
            int k = 0;
            if (int.TryParse(CmbDepartment.SelectedValue.ToString(),out k))
            {
                var x = items.Where(b => b.DepartmentId == int.Parse(CmbDepartment.SelectedValue.ToString()));
                loadcmb<Item>(x.ToList(), CmbItemName);
            }
        }
        private void CmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k;
            if (int.TryParse(CmbItemName.SelectedValue.ToString(), out k))
            {
                TxtItemId.Text = CmbItemName.SelectedValue.ToString();
                int z = items.FindIndex(b => b.Id == int.Parse(CmbItemName.SelectedValue.ToString()));
                var x = unitConversions.GetUnits(items[z].Id);
                units.Clear();
                units =x;
                CmbUnitId.DataSource = x.ToList();
                CmbUnitId.ValueMember = "Id";
                CmbUnitId.DisplayMember = "Name";
            }
        }
        private void loadbalance()
        {
            if (CmbUnitId.SelectedIndex == -1)
            {
                return;
            }
            int k;
            if (!int.TryParse(CmbUnitId.SelectedValue.ToString(),out k))
            {
                return;
            }
            var x = stockItemEndPoint.GetByStockItem(int.Parse(CmbStock.SelectedValue.ToString()), int.Parse(CmbItemName.SelectedValue.ToString()));
            foreach (Unit item in units)
            {
                if (item.UnitId != x.UnitId)
                {
                     k = units.FindIndex(b => b.Id == x.UnitId);
                    item.Qty = unitConversions.GetConvert(item, units[k], x.Balance);
                }
                else
                {
                    item.Qty = x.Balance;
                }
            }
        }

        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = units.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
            //TxtBalance.Text = units[k].Qty.ToString();
        }
    }
}

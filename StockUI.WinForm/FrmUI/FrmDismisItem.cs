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
        private List<stockitem> stockitems = new List<stockitem>();
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
            stockitems = stockItemEndPoint.GetAll();
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
            if (CmbStock.SelectedIndex == -1)
            {
                CmbDepartment.SelectedIndex = -1;
                MessageBox.Show("يجب اختيار المخزن");
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
            if (int.TryParse(CmbItemName.SelectedValue?.ToString(), out k))
            {
                TxtItemId.Text = CmbItemName.SelectedValue.ToString();
                int z = items.FindIndex(b => b.Id == int.Parse(CmbItemName.SelectedValue.ToString()));
                var x = unitConversions.GetUnits(items[z].Id);
                units.Clear();
                units =x;
                loadbalance();
                loadcmb<Unit>(x, CmbUnitId);
            }
        }
        private void loadbalance()
        {
            int v = stockitems.FindIndex(b=>b.StockId==int.Parse(CmbStock.SelectedValue.ToString()) && b.ItemId== int.Parse(TxtItemId.Text.ToString()));
            stockitem z;
            if (v==-1)
            {
                z = new stockitem();
                z.ItemId = int.Parse(TxtItemId.Text.ToString());
                z.Balance = 0;
                int n = items.FindIndex(b => b.Id == int.Parse(CmbItemName.SelectedValue.ToString()));
                z.UnitId = items[n].UnitId;
            }
           else
            {
                z = stockitems[v];
            }
            foreach (Unit item in units)
            {
                if (item.Id == z.UnitId)
                {
                    item.Qty = z.Balance;
                }
                else
                {
                    int x = units.FindIndex(b => b.Id == z.UnitId);
                    item.Qty = unitConversions.GetConvert(units[x], item, z.Balance);
                }
            }
        }
        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUnitId.SelectedValue ==null || CmbUnitId.SelectedIndex ==-1 || CmbUnitId.SelectedItem ==null)
            {
                return;
            }
            int k;
            if (int.TryParse(CmbUnitId.SelectedValue.ToString(),out k))
            {
                k = units.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
                TxtBalance.Text = units[k].Qty?.ToString();
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtItemId.Text = "";
            TxtNote.Text = "";
            TxtQty.Text = "";          
            CmbItemName.SelectedIndex = -1;
            CmbDepartment.SelectedIndex = -1;
            CmbStock.SelectedIndex = -1;
            CmbUnitId.SelectedIndex = -1;
            dataGridView1.DataSource = "";
            dataGridView1.Columns.Clear(); 
            if (BtnNew.Text == "إلغاء")
            {
                BtnNew.Text = "جديد";
                BtnSave.Enabled = false;
                BtnUpdate.Enabled = true;              
                button5.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                BtnUpdate.Enabled = false;
                button5.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            decimal k;
            if ((decimal.TryParse(TxtQty.Text.ToString(),out k)==false))
            {
                MessageBox.Show("الكمية يجب أن تكون ارقام");
                return;
            }
            if (decimal.Parse(TxtQty.Text.ToString())==0 )
            {
                MessageBox.Show("يجب إدخال الكمية");
                return;
            }
            if (k > decimal.Parse(TxtBalance.Text.ToString()))
            {
                MessageBox.Show("لايمكن صرف كميات غير متوفرة في المخزن");
                return;
            }

        }
    }
}

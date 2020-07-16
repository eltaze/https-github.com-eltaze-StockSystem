using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmItemRecit : Form
    {
        private readonly IRecitItemDetailEndPoint recitItemDetailEndPoint;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IRecitItemEndPoint recitItemEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly IStockEndPoint stockEndPoint;
        private List<ItemReciteDisplay> itemReciteDisplays = new List<ItemReciteDisplay>();
        private List<Item> items = new List<Item>();
        private List<ItemRecitDetailDisplay> itemRecitDetailsDisplay = new List<ItemRecitDetailDisplay>();

        public FrmItemRecit(IRecitItemDetailEndPoint recitItemDetailEndPoint, IDepartmentEndPoint departmentEndPoint
            , IRecitItemEndPoint recitItemEndPoint,
            IItemEndPoint itemEndPoint, IUnitEndPoint unitEndPoint, UnitConversions unitConversions, IStockEndPoint stockEndPoint)
        {
            InitializeComponent();
            this.recitItemDetailEndPoint = recitItemDetailEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.recitItemEndPoint = recitItemEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.unitConversions = unitConversions;
            this.stockEndPoint = stockEndPoint;
        }
        private void FrmItemRecit_Load(object sender, EventArgs e)
        {
            var x = stockEndPoint.GetAll();
            loadcmb<Stock>(x.ToList(), CmbStock);
            var department = departmentEndPoint.GetAll();
            loadcmb<department>(department.ToList(), CmbDepartment);
            items = itemEndPoint.GetAll();
        }
        private void loadcmb<T>(List<T> t, ComboBox comboBox)
        {
            comboBox.DataSource = t;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
        }
        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex == -1)
            {
                return;
            }
            var x = items.Where(b => b.DepartmentId == int.Parse(CmbDepartment.SelectedValue.ToString())).ToList();
            loadcmb<Item>(x, CmbItemName);
        }
        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbItemName.Items == null || CmbItemName.SelectedIndex == -1)
            {
                return;
            }
            var z = items.FindIndex(b => b.Id == int.Parse(CmbItemName.SelectedValue.ToString()));
            var x = unitConversions.GetUnits(items[z].UnitId);
            loadcmb<Unit>(x.ToList(), CmbUnitId);
            CmbUnitId.SelectedValue = items[z].UnitId;
            TxtItemId.Text = CmbItemName.SelectedValue.ToString();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtItemId.Text = "";
            CmbItemName.SelectedIndex = -1;
            CmbStock.SelectedIndex = -1;
            CmbUnitId.SelectedIndex = -1;
            TxtNote.Text = "";
            TxtQty.Text = "0.00";
            CmbDepartment.SelectedIndex = -1;
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
                itemRecitDetailsDisplay.Clear();
                dataGridView1.DataSource = null;

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
            int x = itemRecitDetailsDisplay.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            if (x >= 0)
            {
                Unit unit = unitEndPoint.GetByID(int.Parse(CmbUnitId.SelectedValue.ToString()));
                Unit unit1 = unitEndPoint.GetByID(itemRecitDetailsDisplay[x].UnitId);
                decimal c = unitConversions.GetConvert(unit1, unit, itemRecitDetailsDisplay[x].Qty);
                itemRecitDetailsDisplay[x].UnitId = unit.Id;
                itemRecitDetailsDisplay[x].UnitName = unit.Name;
                itemRecitDetailsDisplay[x].Qty = c + decimal.Parse(TxtQty.Text.ToString());
                loadgrid();
                return;
            }
            ItemRecitDetailDisplay itemRecitDetail = new ItemRecitDetailDisplay
            {
                ItemId = int.Parse(TxtItemId.Text.ToString()),
                Qty = decimal.Parse(TxtQty.Text.ToString()),
                ItemName = CmbItemName.Text,
                UnitId = int.Parse(CmbUnitId.SelectedValue.ToString()),
                UnitName = CmbUnitId.Text
            };
            itemRecitDetailsDisplay.Add(itemRecitDetail);
            loadgrid();
        }
        private void loadgrid()
        {
            var x = from b in itemRecitDetailsDisplay
                    select new { الصنف = b.ItemName, الكمية = b.Qty.ToString("0.000"), الوحدة = b.UnitName };
            dataGridView1.DataSource = x.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = 0;
            if (e.RowIndex <= dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                x = itemRecitDetailsDisplay.FindIndex(b => b.ItemName == (string)dataGridView1[0, e.RowIndex].Value.ToString());
                CmbDepartment.SelectedValue = items.Where(b => b.Id == itemRecitDetailsDisplay[x].ItemId).FirstOrDefault().DepartmentId;
                CmbItemName.SelectedValue = itemRecitDetailsDisplay[x].ItemId;
                CmbUnitId.SelectedValue = itemRecitDetailsDisplay[x].UnitId;
                TxtQty.Text = itemRecitDetailsDisplay[x].Qty.ToString("0.00");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int x = itemRecitDetailsDisplay.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            Unit unit = unitEndPoint.GetByID(int.Parse(CmbUnitId.SelectedValue.ToString()));
            Unit unit1 = unitEndPoint.GetByID(itemRecitDetailsDisplay[x].UnitId);
            itemRecitDetailsDisplay[x].UnitId = unit.Id;
            itemRecitDetailsDisplay[x].UnitName = unit.Name;
            itemRecitDetailsDisplay[x].Qty =  decimal.Parse(TxtQty.Text.ToString());
            loadgrid();
        }
    }
}

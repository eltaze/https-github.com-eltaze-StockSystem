using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmBarCode : Form
    {
        private readonly UnitConversions unitConversions;
        private readonly IItemEndPoint itemEndPoint;
        public List<Item> items = new List<Item>();
        public List<Unit> units = new List<Unit>();

        public FrmBarCode(UnitConversions unitConversions,IItemEndPoint itemEndPoint)
        {
            InitializeComponent();
            this.unitConversions = unitConversions;
            this.itemEndPoint = itemEndPoint;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void FrmBarCode_Load(object sender, EventArgs e)
        {
            items = itemEndPoint.GetAll();
        }

        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUnitId.DataSource == null)
            {
                return;
            }
            int x = 0;
            if (int.TryParse(CmbUnitId.SelectedValue.ToString(),out x))
            {
                var r = units.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
                TxtBalance.Text = units[r].Qty.ToString();
            }
        }
        private void TxtBarcod_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                int x = items.FindIndex(b => b.Barcode == TxtBarcod.Text);
                if (x == -1)
                {
                    MessageBox.Show("الباركود غير مدرج");
                    TxtBarcod.Text = "";
                    TxtBarcod.Focus();
                    return;
                }
                TxtItemName.Text = items[x].Name;
                units = unitConversions.GetUnits(items[x].UnitId, 3);
                CmbUnitId.DataSource = units.ToList();
                CmbUnitId.ValueMember = "Id";
                CmbUnitId.DisplayMember = "Name";
                CmbUnitId.SelectedValue = items[x].UnitId;
                CmbUnitId.Focus();
            }
        }
        private void CmbUnitId_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                int x;
                if (int.TryParse(CmbUnitId.SelectedValue.ToString(),out x)==false)
                {
                    MessageBox.Show("يجب إختيار من ضمن اللسته فقط");
                    return;
                }
                TxtQty.Focus();
            }
        }

        private void TxtQty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                decimal x;
                if (decimal.TryParse(TxtQty.Text.ToString(), out x) == false)
                {
                    MessageBox.Show("الكمية يجب أن تكون أرقام فقط");
                    TxtQty.Text = "0.00";
                    TxtQty.Focus();
                }
                BtnNew.Focus();
            }
        }
        private void BtnNew_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Tab)
            {
                return;
            }
                TxtBarcod.Text = "";
                TxtBalance.Text = "0.00";
                TxtItemName.Text = "";
                CmbUnitId.DataSource = null;
                CmbUnitId.Items.Clear();
                TxtBarcod.Focus();
        }
    }
}

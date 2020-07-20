using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.BL.Helper;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmBarCode : Form
    {
        private readonly UnitConversions unitConversions;
        private readonly IItemEndPoint itemEndPoint;
        public  IBarCode barCode;
        public List<Item> items ;
        public List<Unit> units = new List<Unit>();
        public FrmDismisItem form;
        public int stockId;
        public decimal unitprice;
        public FrmBarCode(UnitConversions unitConversions,IItemEndPoint itemEndPoint)
        {
            InitializeComponent();
            this.unitConversions = unitConversions;
            this.itemEndPoint = itemEndPoint;
           //this.barCode = barCode;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void FrmBarCode_Load(object sender, EventArgs e)
        {
            if (typeof(IBarCode).IsAssignableFrom(typeof(FrmOrder)))
            {
                label3.Visible = true;
                TxtPrice.Visible = true;
            }
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
                units = unitConversions.GetUnits(items[x].UnitId, stockId);
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
                if (typeof(IBarCode).IsAssignableFrom(typeof(FrmOrder)))
                {
                    TxtPrice.Focus();
                    return;
                }
                BtnNew.Focus();
            }
        }
        private void BtnNew_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Tab )
            {
                return;
            }
            if (validate() == false)
            {
                return;
            }
            send();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (validate() == false)
            {
                return;
            }
            send();
        }
        private void send()
        {
            Bar bar = new Bar();
            int x = items.FindIndex(b => b.Barcode == TxtBarcod.Text);
            bar.ItemId = items[x].Id;
            bar.QTY = decimal.Parse(TxtQty.Text.ToString());
            bar.UnitId = int.Parse(CmbUnitId.SelectedValue.ToString());
            if (TxtPrice.Visible == true)
            {
                unitprice = decimal.Parse(TxtPrice.Text.ToString());
            }
            barCode.Test(bar);
            clear();
        }
        private void clear()
        {
            TxtBarcod.Text = "";
            TxtBalance.Text = "0.00";
            TxtItemName.Text = "";
            CmbUnitId.DataSource = null;
            CmbUnitId.Items.Clear();
            TxtBarcod.Focus();
        }
        private Boolean validate()
        {
            int x;
            if (int.TryParse(CmbUnitId.SelectedValue?.ToString(), out x) == false)
            {
                MessageBox.Show("يجب إختيار من ضمن اللسته فقط");
                return false;
            }
            decimal xx;
            if (decimal.TryParse(TxtQty.Text.ToString(), out xx) == false)
            {
                MessageBox.Show("الكمية يجب أن تكون أرقام فقط");
                TxtQty.Text = "0.00";
                TxtQty.Focus();
                return false;
            }

             x = items.FindIndex(b => b.Barcode == TxtBarcod.Text);
            if (x == -1)
            {
                MessageBox.Show("الباركود غير مدرج");
                TxtBarcod.Text = "";
                TxtBarcod.Focus();
                return false;
            }
            if (typeof(IBarCode).IsAssignableFrom(typeof(FrmOrder)))
            {
                if (decimal.TryParse(TxtPrice.Text.ToString(), out xx) == false)
                {
                    MessageBox.Show("يجب إدخال السعر");
                    TxtPrice.Text = "0.00";
                    TxtPrice.Focus();
                    return false;
                }
            }
            return true;
        }
        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (true)
            {
                decimal x;
                if (decimal.TryParse(TxtPrice.Text.ToString(), out x) == false)
                {
                    MessageBox.Show("السعر يجب أن تكون أرقام فقط");
                    TxtPrice.Text = "0.00";
                    TxtPrice.Focus();
                    return;
                }
                BtnNew.Focus();

            }
        }
    }
}

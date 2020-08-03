using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using StockUI.WinForm.Formating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmItems : Form
    {
        private readonly IMapper mapper;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly DataGridFormat dataGridFormat;
        private readonly IKindEndPoint kindEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly StockItemEndPoint stockItemEndPoint;
        private readonly DepartmentEndPoint departmentEndPoint;
        private readonly Validation validation;
        private readonly IItemCardEndPoint itemCardEndPoint;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly UserValidation userValidation;
        private readonly IStockEndPoint stockEndPoint;
        private List<ItemDisplay> itemDisplays = new List<ItemDisplay>();
        private List<ItemCardDisplay> itemCardDisplays = new List<ItemCardDisplay>();
        int count = 0;
        public FrmItems(IMapper mapper,IUnitEndPoint unitEndPoint, DataGridFormat dataGridFormat
            , IKindEndPoint kindEndPoint,IItemEndPoint itemEndPoint,StockItemEndPoint stockItemEndPoint
            ,DepartmentEndPoint departmentEndPoint,Validation validation,IItemCardEndPoint itemCardEndPoint
            ,IBaseStockItemEndPoint baseStockItemEndPoint,UserValidation userValidation
            ,IStockEndPoint stockEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.dataGridFormat = dataGridFormat;
            this.kindEndPoint = kindEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.validation = validation;
            this.itemCardEndPoint = itemCardEndPoint;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
            this.userValidation = userValidation;
            this.stockEndPoint = stockEndPoint;
        }
        private void loadcmb<T>(List<T> t,ComboBox comboBox)
        {
            comboBox.DataSource = t;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }
        private void Items_Load(object sender, EventArgs e)
        {
            BtnDelete.Enabled = userValidation.validateDelete("FrmItems");
            BtnUpdate.Enabled = userValidation.validateEdit("FrmItems");
            var outkind = kindEndPoint.GetAll();
            loadcmb<Kind>(outkind, CmbKind);
            var outunit = unitEndPoint.GetAll();
            loadcmb<Unit>(outunit, CmbUnit);
            var outdept = departmentEndPoint.GetAll();
            loadcmb<department>(outdept, CmbDepartment);
            var outstock = stockEndPoint.GetAll();
            loadcmb<Stock>(outstock, CmbStock);
            loadcmb<Stock>(outstock, CmbStockBrows);
            var output = itemEndPoint.GetAll();
            itemDisplays = mapper.Map<List<ItemDisplay>>(output);
            if (itemDisplays.Count>0)
            {
                navigation(0);
                count = 0;
            }
        }
        #region Navigation
        private void navigation(int id)
        {
            if (id>=0 && id <= itemDisplays.Count-1 )
            {
                TxtId.Text = itemDisplays[id].Id.ToString();
                TxtName.Text = itemDisplays[id].Name;
                TxtNote.Text = itemDisplays[id].Note;
                CmbDepartment.SelectedValue = itemDisplays[id].DepartmentId;
                TxtBarcode.Text = itemDisplays[id].Barcode;
                CmbKind.SelectedValue = itemDisplays[id].kindId;
                CmbUnit.SelectedValue = itemDisplays[id].UnitId;
                datagridfill(itemDisplays[id].Id);                
                label5.Text = $"{count + 1} Of {itemDisplays.Count}";
                int x;
                if (int.TryParse(CmbStockBrows.SelectedValue?.ToString(), out x))
                {
                    load(int.Parse(TxtId.Text.ToString()), x);
                }
                dataGridFormat.Style(dataGridView1);
            }
        }
        private void datagridfill(int id)
        {
            var x = baseStockItemEndPoint.GetAllItemStock(id).ToList();
            foreach (var item in x)
            {
                var z = stockEndPoint.GetByName(item.Name);
                var y = stockItemEndPoint.GetByStockItem(z.Id, id);
                item.UnitName = unitEndPoint.GetByID(y.UnitId).Name;
            }
            var output = (from b in x
                         select new { المخزن = b.Name, الكمية = b.Balance ,الوحدة=b.UnitName}).ToList();
            //dataGridView2.DataSource;
            dataGridView2.DataSource = output;
            dataGridFormat.Style(dataGridView2);
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count -= 1;
                navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count < itemDisplays.Count - 1)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = itemDisplays.Count - 1;
            navigation(count);
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        #endregion
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CmbStock.Enabled = checkBox1.Checked;
            TxtQty.ReadOnly = !checkBox1.Checked;
            if (CmbStock.Enabled==false)
            {
                CmbStock.SelectedIndex = -1;
                TxtQty.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtBarcode.Text = "";
            TxtNote.Text = "";
            checkBox1.Checked = false;
            CmbDepartment.SelectedIndex = -1;
            CmbKind.SelectedIndex = -1;
            CmbUnit.SelectedIndex = -1;
            CmbStockBrows.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }
        private string barcode()
        {
            string x = $"{CmbUnit.SelectedValue.ToString()}{TxtName.Text.ToString()}{CmbDepartment.SelectedValue.ToString()}";
            return x;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (TxtBarcode.Text.Length ==0)
            {
                MessageBox.Show("يرجي إدخال الباركود أو إنشاء ");
                return;
            }
            Item item = GetItem();
            if (validation.validateItem(item))
            {
                itemEndPoint.Save(item);
                itemDisplays.Add(mapper.Map<ItemDisplay>(item));
                count = itemDisplays.Count - 1;
                navigation(count);
                MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }
        public Item GetItem()
        {
            Item item = new Item
            {
                Barcode = TxtBarcode.Text,
                kindId = int.Parse(CmbKind.SelectedValue.ToString()),
                DepartmentId = int.Parse(CmbDepartment.SelectedValue.ToString()),
                UnitId = int.Parse(CmbUnit.SelectedValue.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (TxtId.Text.Length>0)
            {
                item.Id = int.Parse(TxtId.Text.ToString());
            }
            if (checkBox2.Checked)
            {
                item.DisplayInDash = true;
            }
            return item;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtBarcode.Text.Length == 0)
            {
                MessageBox.Show("يرجي إدخال الباركود أو إنشاء ");
                return;
            }
            Item item = GetItem();
           
            if (validation.validateItem(item))
            {
                itemEndPoint.Update(item);
                itemDisplays.Remove(itemDisplays[count]);
                itemDisplays.Add(mapper.Map<ItemDisplay>(item));
                count = itemDisplays.Count - 1;
                navigation(count);
                MessageBox.Show("تم الحفظ  التغير بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TxtBarcode.Text = barcode();
            TxtName.Focus();
        }
        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                int x = itemDisplays.FindIndex(b => b.Barcode == TxtBarcode.Text);
                if (x!=-1)
                {
                    count = x;
                    navigation(count);
                }
                TxtName.Focus();
            }
        }
        private void load(int itemid,int stockid)
        {
            var x = itemCardEndPoint.GetItemCards(itemid, stockid);
            List<ItemCardDisplay> itemscard = new List<ItemCardDisplay>();
            itemscard = mapper.Map<List<ItemCardDisplay>>(x);
            foreach (ItemCardDisplay item in itemscard)
            {
                item.UnitName = unitEndPoint.GetByID(item.UnitId).Name;
            }
            var y = (from b in itemscard
                    select new
                    {
                       وارد = b.RecitItem,
                       صادر=b.DismisItem,
                       رقم_المعاملة=b.ReciId,
                       الوحدة=b.UnitName,
                       نوع_المعاملة=b.Nariation           
                    }).ToList();
            dataGridView1.DataSource = y;
        }
        private void CmbStockBrows_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(CmbStockBrows.SelectedValue?.ToString(),out x))
            {
                load(int.Parse(TxtId.Text.ToString()), x);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Item item = GetItem();
            
            itemEndPoint.Delete(item);
            itemDisplays.RemoveAt(count);
            MessageBox.Show("تم الحذف بنجاح");
            count = itemDisplays.Count - 1;
            navigation(count);
        }
        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e, 1);
        }
    }
}

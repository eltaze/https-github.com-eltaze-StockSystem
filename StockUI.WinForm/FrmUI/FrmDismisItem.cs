using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.BL.Helper;
using StockUI.Libarary.Model;
using StockUI.WinForm.Formating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmDismisItem : Form,IBarCode
    {
        private readonly IStockEndPoint stockEndPoint;
        private readonly IMapper mapper;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly ReportForms reportForms;
        private readonly IItemEndPoint itemEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly FrmBarCode frmBarCode;
        private readonly DataGridFormat dataGridFormat;
        private readonly UserValidation userValidation;
        private readonly Validation validation;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IDismisItemDetailEndPoint dismisItemDetailEndPoint;
        private readonly IDismisItemEndPoint dismisItemEndPoint;
        private readonly IStockItemEndPoint stockItemEndPoint;
        private List<Stock> stocks = new List<Stock>();
        private List<department> departments = new List<department>();
        public List<Item> items = new List<Item>();
        public List<Unit> units = new List<Unit>();
        private List<stockitem> stockitems = new List<stockitem>();
        private List<DismisItemDisplay> dismisItemDisplays = new List<DismisItemDisplay>();
        private List<DismisItemDetailDisplay> dismisItemDetailDisplays = new List<DismisItemDetailDisplay>();
        int count = 0;
        
        public FrmDismisItem(IStockEndPoint stockEndPoint, IMapper mapper, IUnitEndPoint unitEndPoint,ReportForms reportForms
                            , IItemEndPoint itemEndPoint, UnitConversions unitConversions,FrmBarCode frmBarCode
                            , DataGridFormat dataGridFormat,UserValidation userValidation,Validation validation
                            , IDepartmentEndPoint departmentEndPoint, IDismisItemDetailEndPoint dismisItemDetailEndPoint
                            , IDismisItemEndPoint dismisItemEndPoint, IStockItemEndPoint stockItemEndPoint)
        {
            InitializeComponent();
            this.stockEndPoint = stockEndPoint;
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.reportForms = reportForms;
            this.itemEndPoint = itemEndPoint;
            this.unitConversions = unitConversions;
            this.frmBarCode = frmBarCode;
            this.dataGridFormat = dataGridFormat;
            this.userValidation = userValidation;
            this.validation = validation;
            this.departmentEndPoint = departmentEndPoint;
            this.dismisItemDetailEndPoint = dismisItemDetailEndPoint;
            this.dismisItemEndPoint = dismisItemEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
        }
        private void FrmDismisItem_Load(object sender, EventArgs e)
        {
            BtnDelete.Enabled = userValidation.validateDelete("FrmDismisItem");
            BtnUpdate.Enabled = userValidation.validateEdit("FrmDismisItem");
            loadlist();
            var st = stockEndPoint.GetAll();
            loadcmb<Stock>(st.ToList(), CmbStock);
            loadcmb<department>(departments, CmbDepartment);
            if (dismisItemDisplays.Count >0)
            {
                navigation(0);
                count = 0;
            }
        }
        private void loadlist()
        {
            dismisItemDisplays = mapper.Map<List<DismisItemDisplay>>(dismisItemEndPoint.GetAll());
            stockitems = stockItemEndPoint.GetAll();
            items = itemEndPoint.GetAll();
            departments = departmentEndPoint.GetAll();
        }
        private void loadcmb<T>(List<T> t, ComboBox comboBox)
        {
            comboBox.DataSource = t;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
        }

        #region Navigation for system
        private void navigation(int id)
        {
            if (id >=0 && id <= dismisItemDisplays.Count -1)
            {
                TxtId.Text = dismisItemDisplays[id].Id.ToString();
                CmbStock.SelectedValue = dismisItemDisplays[id].StockId;
                TxtFrom.Text = dismisItemDisplays[id].DismisTo;
                dateTimePicker1.Value = dismisItemDisplays[id].Odate;
                TxtQty.Text = dismisItemDisplays[id].Note;
                loadDismisDetail(dismisItemDisplays[id].Id);
                filldate();
                dataGridFormat.Style(dataGridView1);
                label9.Text = $"{count + 1} Of {dismisItemDisplays.Count}";
            }
        }
        private void loadDismisDetail(int id)
        {
            dismisItemDetailDisplays.Clear();
            dismisItemDetailDisplays = mapper.Map<List< DismisItemDetailDisplay>>(dismisItemDetailEndPoint.GetByRecitID(id));
            foreach (DismisItemDetailDisplay item in dismisItemDetailDisplays)
            {
                int x = items.FindIndex(b => b.Id == item.ItemId);
                item.ItemName = items[x].Name;
                item.BarCode = items[x].Barcode;
                item.UnitName = unitEndPoint.GetByID(item.UnitId).Name;
                x = departments.FindIndex(b => b.Id == items[x].DepartmentId);
                item.DepartmentName = departments[x].Name;          
            }
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count = -1;
                navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count < dismisItemDisplays.Count)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = dismisItemDisplays.Count - 1;
            navigation(count);
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        #endregion
        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex == -1)
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
            if (int.TryParse(CmbDepartment.SelectedValue.ToString(), out k))
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
                units = x;
                loadbalance();
                loadcmb<Unit>(x, CmbUnitId);
            }
        }
        private void loadbalance()
        {
            int v = stockitems.FindIndex(b => b.StockId == int.Parse(CmbStock.SelectedValue.ToString()) && b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            stockitem z;
            if (v == -1)
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
            if (CmbUnitId.SelectedValue == null || CmbUnitId.SelectedIndex == -1 || CmbUnitId.SelectedItem == null)
            {
                return;
            }
            int k;
            if (int.TryParse(CmbUnitId.SelectedValue.ToString(), out k))
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
                //BtnUpdate.Enabled = true;
                //button5.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
               // BtnUpdate.Enabled = false;
                //button5.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button1.Enabled = true;
            }
            dismisItemDetailDisplays.Clear();
        }
        private bool validate()
        {
            decimal k;
            if ((decimal.TryParse(TxtQty.Text.ToString(), out k) == false))
            {
                MessageBox.Show("الكمية يجب أن تكون ارقام");
                return false;
            }
            if (decimal.Parse(TxtQty.Text.ToString()) == 0)
            {
                MessageBox.Show("يجب إدخال الكمية");
                return false;
            }
            return true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (validate() ==false )
            {
                return;
            }
            
            if (decimal.Parse(TxtQty.Text.ToString()) > decimal.Parse(TxtBalance.Text.ToString()))
            {
                MessageBox.Show("لايمكن صرف كميات غير متوفرة في المخزن");
                return ;
            }
           
            int x = items.FindIndex(b => b.Id == int.Parse(TxtItemId.Text));
            int xx = dismisItemDetailDisplays.FindIndex(b => b.ItemId == int.Parse(CmbItemName.SelectedValue.ToString()));
            if (xx != -1)
            {
                int id1 = units.FindIndex(b => b.Id == dismisItemDetailDisplays[xx].UnitId);
                int id2 = units.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
                if (units[id1].Id == units[id2].Id)
                {
                    dismisItemDetailDisplays[x].Qty -= decimal.Parse(TxtQty.Text.ToString());

                }
                else
                {
                    dismisItemDetailDisplays[x].Qty = unitConversions.GetConvert(units[id1], units[id2], dismisItemDetailDisplays[x].Qty) + decimal.Parse(TxtQty.Text.ToString());
                    dismisItemDetailDisplays[x].UnitId = units[id2].Id;
                    dismisItemDetailDisplays[x].UnitName = units[id2].Name;
                }
                x = stockitems.FindIndex(b => b.ItemId == dismisItemDetailDisplays[x].ItemId && b.StockId == int.Parse(CmbStock.SelectedValue.ToString()));
                stockitems[x].Balance = decimal.Parse(TxtBalance.Text.ToString()) - decimal.Parse(TxtQty.Text.ToString());
                stockitems[x].UnitId = dismisItemDetailDisplays[x].UnitId;
                TxtBalance.Text = stockitems[x].Balance.ToString("0.00");
                loadbalance();
                filldate();
                return;
            }
            DismisItemDetailDisplay dismisItemDetailDisplay = new DismisItemDetailDisplay
            {
                BarCode = items[x].Barcode,
                DepartmentId = int.Parse(CmbDepartment.SelectedValue.ToString()),
                DepartmentName = CmbDepartment.Text,
                UnitId = int.Parse(CmbUnitId.SelectedValue.ToString()),
                UnitName = CmbUnitId.Text,
                ItemId = items[x].Id,
                ItemName = items[x].Name,
                Qty = decimal.Parse(TxtQty.Text.ToString())
            };
            dismisItemDetailDisplays.Add(dismisItemDetailDisplay);
            x = stockitems.FindIndex(b => b.ItemId == dismisItemDetailDisplay.ItemId && b.StockId == int.Parse(CmbStock.SelectedValue.ToString()));
            stockitems[x].Balance = decimal.Parse(TxtBalance.Text.ToString()) - decimal.Parse(TxtQty.Text.ToString());
            stockitems[x].UnitId = dismisItemDetailDisplay.UnitId;
            TxtBalance.Text = stockitems[x].Balance.ToString("0.00");
            loadbalance();
            filldate();
        }
        private void filldate()
        {
            var x = (from b in dismisItemDetailDisplays
                     select new
                     {
                         الصنف = b.ItemName,
                         الكمية = b.Qty,
                         الوحدة = b.UnitName,
                         الباركود = b.BarCode,
                         b.ItemId,
                         b.UnitId,
                         b.Note,
                         b.DepartmentId,
                         b.DepartmentName
                     }).ToList();
            dataGridView1.DataSource = x;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (validate()==false)
            {
                return;
            }
            int x = dismisItemDetailDisplays.FindIndex(b => b.ItemId == int.Parse(CmbItemName.SelectedValue.ToString()));
            if (x == -1)
            {
                MessageBox.Show("لايمكن تعديل صنف غير مدرج يجب إدراج الصنف أولا");
                return;
            }
            int kx = stockitems.FindIndex(b => b.ItemId == dismisItemDetailDisplays[x].ItemId);
            stockitems[kx].Balance += dismisItemDetailDisplays[x].Qty;
            if (stockitems[kx].UnitId == int.Parse(CmbUnitId.SelectedValue.ToString()))
            {
                stockitems[kx].Balance -= decimal.Parse(TxtQty.Text.ToString());
                TxtBalance.Text = stockitems[kx].Balance.ToString("0.00");
            }
            else
            {
                int id1 = units.FindIndex(b => b.Id == stockitems[kx].UnitId);
                int id2 = units.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
                decimal tot= unitConversions.GetConvert(units[id1], units[id2], stockitems[kx].Balance);
                if (tot < decimal.Parse(TxtQty.Text.ToString()))
                {
                    MessageBox.Show("الكمية غير متاحة في المخزن");
                    return;
                }
                stockitems[kx].Balance = tot - decimal.Parse(TxtQty.Text.ToString());
                stockitems[kx].UnitId = int.Parse(CmbUnitId.SelectedValue.ToString());
                TxtBalance.Text = stockitems[kx].Balance.ToString("0.00");
            }
            dismisItemDetailDisplays[x].UnitName = CmbUnitId.Text;
            dismisItemDetailDisplays[x].UnitId = int.Parse(CmbUnitId.SelectedValue.ToString());
            dismisItemDetailDisplays[x].Qty = decimal.Parse(TxtQty.Text.ToString());
            dataGridView1.DataSource = null;
            loadbalance();
            filldate();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                CmbDepartment.SelectedValue = int.Parse((string)dataGridView1[7, e.RowIndex].Value.ToString());
                CmbItemName.SelectedValue = int.Parse((string)dataGridView1[4, e.RowIndex].Value.ToString());
                CmbUnitId.SelectedValue = int.Parse((string)dataGridView1[5, e.RowIndex].Value.ToString());
                TxtQty.Text = (string)dataGridView1[1, e.RowIndex].Value.ToString();
                TxtBalance.Text = (decimal.Parse(TxtBalance.Text.ToString()) + decimal.Parse(TxtQty.Text.ToString())).ToString();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DismisItem dismisItem = new DismisItem
            {
                DismisTo = TxtFrom.Text,
                Note = TxtNote.Text,
                Odate  = dateTimePicker1.Value,
                StockId = int.Parse(CmbStock.SelectedValue.ToString())
            };
            List<DismisItemDetail> dismisItemDetails = new List<DismisItemDetail>();    
            dismisItemDetails = mapper.Map<List<DismisItemDetail>>(dismisItemDetailDisplays);
            dismisItem.recitItemDetails = dismisItemDetails;
            List<stockitem> stckitems = new List<stockitem>();
            foreach (DismisItemDetail item in dismisItemDetails)
            {
                int kx = stockitems.FindIndex(b => b.ItemId == item.ItemId);
                if (kx >=0)
                {
                    stckitems.Add(stockitems[kx]);
                }
            }
            int x = dismisItemEndPoint.Save(dismisItem, stckitems);
            dismisItem.Id = x;
            dismisItemDisplays.Add(mapper.Map<DismisItemDisplay>(dismisItem));
            count = dismisItemDisplays.Count - 1;
            navigation(count);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            reportForms.start = 4;
            reportForms.DismisItemDisplay = dismisItemDisplays[count];
            reportForms.DismisItemDisplay.StockName = CmbStock.Text;
            int i = 1;
            foreach (var item in dismisItemDetailDisplays)
            {
                item.counter = i;
                i++;
            }
            reportForms.DismisItemDisplay.dismisItemDetailDisplays = dismisItemDetailDisplays;
            reportForms.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBarCode.barCode = this;
            int x;
            if (int.TryParse(CmbStock.SelectedValue?.ToString(),out x) == false)
            {
                MessageBox.Show("يجب إختيار المخزن أولا");
                return;
            }
            frmBarCode.stockId = int.Parse(CmbStock.SelectedValue.ToString());
            frmBarCode.items = items;
            frmBarCode.ShowDialog();
        }
      
        public void Test(Bar bar)
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            fill(bar);
            button8_Click(sender, e);
        }
        private void fill(Bar bar)
        {
            int x = items.FindIndex(b => b.Id == bar.ItemId);
            CmbDepartment.SelectedValue = items[x].DepartmentId;
            CmbItemName.SelectedValue = items[x].Id;
            TxtItemId.Text = bar.ItemId.ToString();
            TxtQty.Text = bar.QTY.ToString();
            CmbUnitId.SelectedValue = bar.UnitId;
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }
    }
}

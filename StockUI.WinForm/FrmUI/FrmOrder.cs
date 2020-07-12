using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmOrder : Form
    {
        private readonly IMapper mapper;
        private readonly IOrderEndPoint orderEndPoint;
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IStockEndPoint stockEndPoint;
        private readonly IStockItemEndPoint stockItemEndPoint;
        private readonly ReportForms reportForms;
        private List<ItemDisplay> items = new List<ItemDisplay>();
        private List<OrderDisplay> orderDisplays = new List<OrderDisplay>();
        private List<UnitDisplay> unitDisplays = new List<UnitDisplay>();
        private List<OrderDetailDisplay> orderDetailDisplays = new List<OrderDetailDisplay>();
        private OrderDisplay neworder = new OrderDisplay();
        int count = 0;
        int modification = -1;
        public FrmOrder(IMapper mapper,IOrderEndPoint orderEndPoint
            ,IOrderDetailEndPoint orderDetailEndPoint
            ,IUnitEndPoint unitEndPoint,IItemEndPoint itemEndPoint
            ,IBaseStockItemEndPoint baseStockItemEndPoint
            ,IDepartmentEndPoint departmentEndPoint,
            IStockEndPoint stockEndPoint,IStockItemEndPoint stockItemEndPoint,ReportForms reportForms)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.orderEndPoint = orderEndPoint;
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.stockEndPoint = stockEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
            this.reportForms = reportForms;
        }

        private void loadstock()
        {
            var output = stockEndPoint.GetAll().ToList();
            CmbStock.DataSource = output.ToList();
            CmbStock.ValueMember = "Id";
            CmbStock.DisplayMember = "Name";
        } 
        private void LoadDepartment()
        {
            var output = departmentEndPoint.GetAll();
            CmbDepartment.DataSource = output.ToList();
            CmbDepartment.ValueMember = "Id";
            CmbDepartment.DisplayMember = "Name";
        }
        private void calcunit(Item item)
        {
            var output = unitEndPoint.GetByUnitIdTest(item.UnitId).ToList();
            unitDisplays = mapper.Map<List<UnitDisplay>>(output);
            foreach (UnitDisplay unit in unitDisplays)
            {
                if (unit.Qty != null & item.UnitId != unit.Id)
                {
                    unit.Qty = unit.Qty * loadBalance();
                }
                else
                {
                    unit.Qty = loadBalance();
                }
            }
            CmbUnitId.DataSource = unitDisplays.ToList();
            CmbUnitId.ValueMember = "Id";
            CmbUnitId.DisplayMember = "Name";
            CmbUnitId.SelectedValue = item.UnitId;
        }
        private void loadItem()
        {
            try
            {
                if (Validateint(CmbDepartment.SelectedValue.ToString()))
                {
                    var output = from b in items
                                 where b.DepartmentId == int.Parse(CmbDepartment.SelectedValue.ToString())
                                 select b;
                    CmbItemName.DataSource = null;
                    CmbItemName.DataSource = output.ToList();
                    CmbItemName.ValueMember = "Id";
                    CmbItemName.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        private Decimal loadBalance()
        {
            int kk = int.Parse(TxtItemId.Text.ToString());
            var stockitems = stockItemEndPoint.GetItemByStock(kk).ToList();
            decimal output =0;
            if (int.TryParse(CmbStock.SelectedValue?.ToString(), out kk))
            {
                var y = stockitems.Where(x => x.StockId == kk).FirstOrDefault();
                if (y != null)
                {
                    output = y.Balance;
                }
            }
            return output;
        }
        private void orderdetails()
        {
            int xx = neworder.OrderDetails.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()) && b.UnitId == int.Parse(CmbUnitId.SelectedValue.ToString()));
            if (xx >= 0)
            {
                neworder.OrderDetails[xx].Qty += decimal.Parse(TxtQty.Text.ToString());
                filldatagrid();
                return;
            }
            OrderDetailDisplay displays = new OrderDetailDisplay
            {
                ItemId = int.Parse(TxtItemId.Text.ToString()),
                UnitPrice = decimal.Parse(TxtUnitPrice.Text.ToString()),
                Qty = decimal.Parse(TxtQty.Text.ToString()),
                UnitId = int.Parse(CmbUnitId.SelectedValue.ToString()),
                ItemName = CmbItemName.Text,
                UnitName = CmbUnitId.Text,
            };
            neworder.OrderDetails.Add(displays);
            filldatagrid();
        }
        private void filldatagrid()
        {
            dataGridView1.DataSource = "";
            dataGridView1.Columns.Clear();
            var x = from b in neworder.OrderDetails
                    select new
                    {
                        إسم_الصنف = b.ItemName,
                        الكمية = b.Qty,
                        سعر_الوحدة = b.UnitPrice,
                        السعر_السابق = b.LastPrice,
                        الوحدة = b.UnitName,
                        الإجمال = b.Total.ToString("0.00")
                    };
            dataGridView1.DataSource = x.ToList();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Name = "حذف";
            buttonColumn.Text = "حذف";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Text = "حذف";
            dataGridView1.Columns.Add(buttonColumn);
            string xx = neworder.OrderDetails.Sum(b => b?.Qty * b?.UnitPrice).ToString();
            TxtTotal.Text = xx.PadLeft(2, '0');
        }
        private bool Validateint(string id)
        {
            int c;
            return int.TryParse(id, out c);
        }
        private bool Validatedecimal(string id)
        {
            decimal c;
            return decimal.TryParse(id, out c);
        }
        #region Navigation To Orders
        private void Navigation(int id)
        {
            if (id>=0 && id<=orderDisplays.Count-1)
            {
                TxtId.Text = orderDisplays[id].Id.ToString();
                TxtNote.Text = orderDisplays[id].Note;
                dateTimePicker1.Value = orderDisplays[id].ODate.Date;
                CmbStock.SelectedValue = orderDisplays[id].StockId;
                loadDetail(orderDisplays[id].Id);
                label14.Text = $"{count + 1} Of {orderDisplays.Count}";
            }
        }
        private void loadDetail(int id)
        {
            var output = orderDetailEndPoint.GetByID(id).ToList();
            orderDisplays[count].OrderDetails = mapper.Map<List<OrderDetailDisplay>>(output);
            neworder = new OrderDisplay();
            neworder = orderDisplays[count];
            foreach (var orde in neworder.OrderDetails)
            {
                orde.ItemName = itemEndPoint.GetByID(orde.ItemId).Name;
                orde.UnitName = unitEndPoint.GetByID(orde.UnitId).Name;
            }
            filldatagrid();
            TxtTotal.Text = orderDisplays[count].OrderDetails.Sum(b => b.Total).ToString("0.00");
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count -= 1;
                Navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count < orderDisplays.Count - 1)
            {
                count += 1;
                Navigation(count);
            }
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            Navigation(count);
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = orderDisplays.Count - 1;
            Navigation(count);
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtItemId.Text = "";
            TxtItemQtyInStock.Text = "";
            TxtNote.Text = "";
            TxtQty.Text = "";
            TxtTotal.Text = "0.00";
            TxtUnitPrice.Text = "0.00";
            CmbItemName.SelectedIndex = -1;
            CmbStock.SelectedIndex = -1;
            CmbUnitId.SelectedIndex = -1;
            dataGridView1.DataSource = "";
            dataGridView1.Columns.Clear();
            orderDetailDisplays.Clear();
            if (BtnNew.Text == "إلغاء")
            {
                BtnNew.Text = "جديد";
                BtnSave.Enabled = false;
                BtnUpdate.Enabled = true;
                Navigation(count);
                button5.Enabled = false;
                //button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                BtnUpdate.Enabled = false;
                neworder = new OrderDisplay();
                button5.Enabled = true;
                //button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                
            }
        }
        private void CmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbItemName.SelectedIndex !=-1)
            {
                var item = itemEndPoint.GetByName(CmbItemName.Text.ToString());
                if (item != null)
                {
                    TxtItemId.Text = item.Id.ToString();
                    try
                    {
                        calcunit(item);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message.ToString());
                    }
                }
            }
        }
        private void TxtItemId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                if (Validateint(TxtItemId.Text.ToString())==false)
                {
                    MessageBox.Show("رقم الصنف لايمكن ان يكون الا حروف");
                    return;
                }
                int bb = items.FindIndex(x => x.Id == int.Parse(TxtItemId.Text.ToString()));
                if (bb ==-1)
                {
                    MessageBox.Show("لايوجد صنف بهذا الرقم يرجي التاكد من الرقم الصحيح");
                    TxtItemId.Text = "";
                    TxtItemId.Focus();
                }
                else
                {
                    CmbDepartment.SelectedValue = items[bb].DepartmentId;
                    List<ItemDisplay> output = new List<ItemDisplay>();
                     output.Add(items[bb]);
                    CmbItemName.DataSource = output;
                    CmbItemName.ValueMember = "Id";
                    CmbItemName.DisplayMember = "Name";
                    loadBalance();
                }
            }
        }
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            items = mapper.Map<List<ItemDisplay>>(itemEndPoint.GetAll().ToList());
            loadstock();
            LoadDepartment();
            var output = orderEndPoint.GetAll().ToList();
            orderDisplays = mapper.Map<List<OrderDisplay>>(output);
            if (orderDisplays.Count > 0)
            {
                Navigation(0);
                count = 0;
            }
        }
        private void CmbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtItemId.Text.Length>0)
            {
//                loadBalance();
            }
        }
        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Validateint(CmbUnitId.SelectedValue?.ToString()))
                {
                    var x = unitDisplays.FindIndex(b => b.Id == int.Parse(CmbUnitId.SelectedValue.ToString()));
                    TxtItemQtyInStock.Text = unitDisplays[x].Qty.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadItem();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (Validatedecimal(TxtQty.Text.ToString()) == false || Validatedecimal(TxtUnitPrice.Text.ToString())==false 
                  || TxtUnitPrice.Text =="0.00")
            {
                MessageBox.Show("يرجي مراجعة الكمية وسعر الوحدة ");
                return;
            }
            if(Validateint(CmbStock.SelectedValue?.ToString())==false)
            {
                MessageBox.Show("يرجي إختيار المخزن");
                return;
            }
            if (neworder.OrderDetails.Count > 0)
            {
                orderdetails();
            }
            else
            {
                neworder.Note = TxtNote.Text;
                neworder.ODate = dateTimePicker1.Value.Date;
                neworder.StockId = int.Parse(CmbStock.SelectedValue.ToString());
                orderdetails();
                TxtTotal.Text = neworder.OrderDetails.Sum(x => x.Qty * x.UnitPrice).ToString("0.00");
            }
        }      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["حذف"].Index)
            {
                string x = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                string c = (string)dataGridView1[4, e.RowIndex].Value.ToString();
                int z = neworder.OrderDetails.FindIndex(b => b.ItemName == x && b.UnitName == c);
                TxtItemId.Text = neworder.OrderDetails[z].ItemId.ToString();
                TxtQty.Text = neworder.OrderDetails[z].Qty.ToString();
                TxtUnitPrice.Text = neworder.OrderDetails[z].UnitPrice.ToString();
                Item item = new Item();
                item = itemEndPoint.GetByID(neworder.OrderDetails[z].ItemId);
                CmbDepartment.SelectedValue = item.DepartmentId;
                CmbItemName.SelectedValue = item.Id;
                CmbUnitId.SelectedValue = neworder.OrderDetails[z].UnitId;
                modification = z;
            }
            else
            {
                string x = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                string c = (string)dataGridView1[4, e.RowIndex].Value.ToString();
                int z = neworder.OrderDetails.FindIndex(b => b.ItemName == x && b.UnitName == c);
                neworder.OrderDetails.RemoveAt(z);
                filldatagrid();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(modification ==-1)
            {
                return;
            }
            neworder.OrderDetails.RemoveAt(modification);
            orderdetails();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TxtQty.Text = "0.00";
            TxtUnitPrice.Text = "0.00";
            CmbStock.SelectedIndex = 0;
            CmbDepartment.SelectedIndex = 0;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            List<OrderDetail> details = new List<OrderDetail>();
            details = mapper.Map<List<OrderDetail>>(neworder.OrderDetails);
            order = mapper.Map<Order>(neworder);
            var x = orderEndPoint.Save(order);
            neworder.Id = x.Id;
            orderDisplays.Add(neworder);
            neworder = new OrderDisplay();
            count = orderDisplays.Count - 1;
            Navigation(count);
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            neworder.StockName = stockEndPoint.GetByID(neworder.StockId).Name;
            neworder.Total = neworder.OrderDetails.Sum(x => x.Total);
            int i = 1;
            foreach (var item in neworder.OrderDetails)
            {
                item.Counter = i;
                i += 1;
            }
            reportForms.OrderDisplay = neworder;
            reportForms.ShowDialog();
        }
    }
}

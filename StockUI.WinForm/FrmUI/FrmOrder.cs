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
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmOrder : Form, IBarCode
    {
        private readonly IMapper mapper;
        private readonly IOrderEndPoint orderEndPoint;
        private readonly FrmBarCode frmBarCode;
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly DataGridFormat dataGridFormat;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly UserValidation userValidation;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly Validation validation;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly UnitConversions unitConversions;
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
        public FrmOrder(IMapper mapper,IOrderEndPoint orderEndPoint,FrmBarCode frmBarCode
            ,IOrderDetailEndPoint orderDetailEndPoint,DataGridFormat dataGridFormat
            ,IUnitEndPoint unitEndPoint,IItemEndPoint itemEndPoint,UserValidation userValidation
            ,IBaseStockItemEndPoint baseStockItemEndPoint,Validation validation
            ,IDepartmentEndPoint departmentEndPoint,UnitConversions unitConversions
            ,IStockEndPoint stockEndPoint,IStockItemEndPoint stockItemEndPoint,ReportForms reportForms)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.orderEndPoint = orderEndPoint;
            this.frmBarCode = frmBarCode;
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.dataGridFormat = dataGridFormat;
            this.unitEndPoint = unitEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.userValidation = userValidation;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
            this.validation = validation;
            this.departmentEndPoint = departmentEndPoint;
            this.unitConversions = unitConversions;
            this.stockEndPoint = stockEndPoint;
            this.stockItemEndPoint = stockItemEndPoint;
            this.reportForms = reportForms;
        }
        private void loadcmb<T>(List<T> t, ComboBox comboBox)
        {
            
            comboBox.DataSource = t;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
        }
        private void calcunit(Item item)
        {
            var x = unitConversions.GetUnits(item.UnitId);   
            unitDisplays = mapper.Map<List<UnitDisplay>>(x);
            decimal bal = loadBalance().Balance;
            foreach (UnitDisplay unit in unitDisplays)
            {
                if ( unit.Id != loadBalance().UnitId)
                {
                    int z = x.FindIndex(b => b.Id == loadBalance().UnitId);
                    int c = x.FindIndex(b => b.Id == unit.Id);
                    unit.Qty = unitConversions.GetConvert(x[z], x[c], bal);
                }
                else
                {
                    unit.Qty = bal;
                }
            }
            loadcmb(unitDisplays, CmbUnitId);
            CmbUnitId.SelectedValue = item.UnitId;
        }
        private stockitem loadBalance()
        {
            int kk = int.Parse(TxtItemId.Text.ToString());
            var stockitems = stockItemEndPoint.GetItemByStock(kk).ToList();
            stockitem output = new stockitem();
            if (int.TryParse(CmbStock.SelectedValue?.ToString(), out kk))
            {
                output = stockitems.Where(x => x.StockId == kk).FirstOrDefault();
            }
            return output;
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

                    loadcmb<ItemDisplay>(output.ToList(), CmbItemName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
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
                dataGridFormat.Style(dataGridView1);
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
        private void button()
        {
           
            button8.Enabled=userValidation.validateEdit("FrmOrder");
            button5.Enabled= userValidation.validateEdit("FrmOrder");
            button7.Enabled = userValidation.validateEdit("FrmOrder");
        }
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
                //BtnUpdate.Enabled = true;
                Navigation(count);
                button();
                button1.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                //BtnUpdate.Enabled = false;
                neworder = new OrderDisplay();
                button1.Enabled = true;
                //button6.Enabled = true;
                button();
                             
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
            BtnDelete.Enabled = userValidation.validateDelete("FrmOrder");
            BtnUpdate.Enabled = userValidation.validateEdit("FrmOrder");
            button();
            items = mapper.Map<List<ItemDisplay>>(itemEndPoint.GetAll().ToList());
            var z = stockEndPoint.GetAll();
            loadcmb<Stock>(z.ToList(), CmbStock);
            var x = departmentEndPoint.GetAll();
            loadcmb<department>(x.ToList(), CmbDepartment);
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
            reportForms.start = 1;
            reportForms.OrderDisplay = neworder;
            reportForms.ShowDialog();
        }

        public void Test(Bar bar)
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            fill(bar);
            button8_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBarCode.barCode = this;
            int x;
            if (int.TryParse(CmbStock.SelectedValue?.ToString(), out x) == false)
            {
                MessageBox.Show("يجب إختيار المخزن أولا");
                return;
            }
            frmBarCode.stockId = int.Parse(CmbStock.SelectedValue.ToString());
            frmBarCode.items = itemEndPoint.GetAll();
            frmBarCode.ShowDialog();
        }
        private void fill(Bar bar)
        {
            int x = items.FindIndex(b => b.Id == bar.ItemId);
            CmbDepartment.SelectedValue = items[x].DepartmentId;
            CmbItemName.SelectedValue = items[x].Id;
            TxtItemId.Text = bar.ItemId.ToString();
            TxtQty.Text = bar.QTY.ToString();
            CmbUnitId.SelectedValue = bar.UnitId;
            TxtUnitPrice.Text = frmBarCode.unitprice.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                Id = int.Parse(TxtId.Text.ToString())
            };
            List<OrderDetail> details = new List<OrderDetail>();
            orderDetailEndPoint.DeleteByOrderId(order.Id);
            orderEndPoint.Delete(order);
            orderDetailDisplays.Clear();
            
            count = orderDisplays.Count - 1;
            MessageBox.Show("تم الحذف بنجاح");
            Navigation(count);
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }
        public Order GetOrder()
        {
            Order order = new Order
            {
               
                Note = TxtNote.Text,
                ODate = dateTimePicker1.Value,
                StockId = int.Parse(CmbStock.SelectedValue.ToString())
            };
            if (TxtId.Text.Length>0)
            {
                order.Id = int.Parse(TxtId.Text.ToString()),
            }
            return order;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Order order = GetOrder();
            
            orderDetailEndPoint.DeleteByOrderId(order.Id);
            List<OrderDetail> details = new List<OrderDetail>();
            details = mapper.Map<List<OrderDetail>>(neworder.OrderDetails);
            foreach (OrderDetail item in details)
            {
                item.Id = 0;
                item.orderid = order.Id;
                orderDetailEndPoint.Save(item);
            }
            orderEndPoint.Update(order);
            MessageBox.Show("تم حفظ التعديلات بنجاح");
        }
    }
}

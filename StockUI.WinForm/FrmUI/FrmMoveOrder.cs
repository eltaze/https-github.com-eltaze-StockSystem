using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using StockUI.WinForm.Formating;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmMoveOrder : Form
    {
        private readonly IMapper mapper;
        private readonly ImoveorderdetailEndPoint moveorderdetailEndPoint;
        private readonly DataGridFormat dataGridFormat;
        private readonly ImoveorderEndPoint moveorderEndPoint;
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly ReportForms reportForms;
        private readonly UserValidation userValidation;
        private readonly IStockEndPoint stockEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private List<MoveorderDisplay> moveorderDisplays = new List<MoveorderDisplay>();
        private List<MoveOrderDetailDisplay> moveOrderDetailDisplays = new List<MoveOrderDetailDisplay>();
        private List<OrderDetailDisplay> orderDetailDisplays = new List<OrderDetailDisplay>();
        private List<UnitDisplay> unitDisplays = new List<UnitDisplay>();
        int count = 0;

        public FrmMoveOrder(IMapper mapper,ImoveorderdetailEndPoint moveorderdetailEndPoint, DataGridFormat dataGridFormat
            ,ImoveorderEndPoint moveorderEndPoint,IOrderDetailEndPoint orderDetailEndPoint
            ,ReportForms reportForms,UserValidation userValidation
            ,IStockEndPoint stockEndPoint,IItemEndPoint itemEndPoint,IUnitEndPoint unitEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.moveorderdetailEndPoint = moveorderdetailEndPoint;
            this.dataGridFormat = dataGridFormat;
            this.moveorderEndPoint = moveorderEndPoint;
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.reportForms = reportForms;
            this.userValidation = userValidation;
            this.stockEndPoint = stockEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
        }
        private void FrmMoveOrder_Load(object sender, EventArgs e)
        {
            BtnDelete.Enabled = userValidation.validateDelete("FrmMoveOrder");
            BtnUpdate.Enabled = userValidation.validateEdit("FrmMoveOrder");
            var stocks =stockEndPoint.GetAll();
            CmbStock.DataSource = stocks.ToList();
            CmbStock.ValueMember = "Id";
            CmbStock.DisplayMember = "Name";
            moveorderDisplays = mapper.Map<List<MoveorderDisplay>>(moveorderEndPoint.GetAll().ToList());
            if (moveorderDisplays.Count >0 )
            {
                count = 0;
                Navigation(0);
            }
        }
        #region Navigation forms and movement
        private void Navigation(int id)
        {
            if (id >= 0 && id <= moveorderDisplays.Count - 1)
            {
                TxtId.Text = moveorderDisplays[id].Id.ToString();
                CmbStock.SelectedValue = moveorderDisplays[id].StockId;
                //dateTimePicker1.Value = moveorderDisplays[id].Odate.Date;
                TxtNote.Text = moveorderDisplays[id].Note;
                TxtDriveName.Text = moveorderDisplays[id].DriverName;
                TxtCarBlate.Text = moveorderDisplays[id].CarBlate;
                TxtCity.Text = "";
                label11.Text = $"{count + 1} Of {moveorderDisplays.Count}";
                loadMoveOrderDetails(moveorderDisplays[id].Id);
                datagridfill();
                dataGridFormat.Style(dataGridView1);
                dataGridFormat.Style(dataGridView2);
            }
        }
        private void loadMoveOrderDetails(int id)
        {
            moveOrderDetailDisplays = mapper.Map<List<MoveOrderDetailDisplay>>(moveorderdetailEndPoint.GetByMoveOrderId(id));
            foreach (MoveOrderDetailDisplay item in moveOrderDetailDisplays)
            {
                item.ItemName = itemEndPoint.GetByID(item.Id).Name;
                item.UnitName = unitEndPoint.GetByID(item.UnitId).Name;
            }
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count = -1;
                Navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count < moveorderDisplays.Count)
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
            count = moveorderDisplays.Count - 1;
            Navigation(count);
        }
        #endregion
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            CmbStock.SelectedValue = -1;
            dateTimePicker1.Value = DateTime.Now.Date;
            TxtNote.Text = "";
            TxtDriveName.Text ="";
            TxtCarBlate.Text = "";
            TxtCity.Text = "";
            if (BtnNew.Text == "إلغاء")
            {
                BtnNew.Text = "جديد";
                BtnSave.Enabled = false;
                //BtnUpdate.Enabled = true;
                Navigation(count);
                //button5.Enabled = false;
                //button6.Enabled = false;
                dataGridView2.DataSource = null;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                //BtnUpdate.Enabled = false;
                fillDataGridOrder();
               // button5.Enabled = true;
                //button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }           
        }
       private void fillDataGridOrder()
        {
            orderDetailDisplays = mapper.Map<List<OrderDetailDisplay>>(orderDetailEndPoint.GetOrderDetailsByMoveOrder().ToList());
            foreach (OrderDetailDisplay item in orderDetailDisplays)
            {
                item.UnitName = unitEndPoint.GetByID(item.UnitId).Name;
                item.ItemName = itemEndPoint.GetByID(item.ItemId).Name;               
            }
            var x = (from b in orderDetailDisplays
                     select new { 
                         إسم_الصنف = b.ItemName,
                         الكمية = b.Qty,
                         الوحدة = b.UnitName ,
                         b.UnitId,
                         b.ItemId }).ToList();
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = x;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            //DataGridViewCheckBoxColumn buttonColumn = new DataGridViewCheckBoxColumn();
            //buttonColumn.HeaderText = "";
            //buttonColumn.Name = "إضافة";
            //buttonColumn.HeaderText = "إضاقة";
            ////buttonColumn.UseColumnTextForButtonValue = true;
            ////buttonColumn = "حذف";
            //dataGridView2.Columns.Add(buttonColumn);
        }
        private void calcunit(int id, int itemid)
        {
            var output = unitEndPoint.GetByUnitIdTest(id).ToList();
            var item = itemEndPoint.GetByID(itemid);
            unitDisplays = mapper.Map<List<UnitDisplay>>(output);
            foreach (UnitDisplay unit in unitDisplays)
            {
                if (unit.Qty != null & item.UnitId != unit.Id)
                {
                    unit.Qty = unit.Qty * decimal.Parse(TxtQty.Text.ToString());
                }
                else
                {
                    unit.Qty = decimal.Parse(TxtQty.Text.ToString());
                }
            }
            CmbUnitId.DataSource = unitDisplays.ToList();
            CmbUnitId.ValueMember = "Id";
            CmbUnitId.DisplayMember = "Name";
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <= dataGridView2.Rows.Count -1 && e.RowIndex >=0)
            {
                TxtItemName.Text = (string)dataGridView2[0, e.RowIndex].Value.ToString();
                TxtQty.Text = (string)dataGridView2[1, e.RowIndex].Value.ToString();
                TxtItemId.Text = (string)dataGridView2[4, e.RowIndex].Value.ToString();
                calcunit(int.Parse((string)dataGridView2[3, e.RowIndex].Value.ToString()), int.Parse((string)dataGridView2[4, e.RowIndex].Value.ToString()));
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (TxtItemId.Text.Length <=0)
            {
                MessageBox.Show("يرجي إختيار الصنف أولا");
                return;
            }
            var x = orderDetailDisplays.FindIndex(b =>  b.ItemId == int.Parse(TxtItemId.Text.ToString()) && b.UnitName ==CmbUnitId.Text);
            int xx = moveOrderDetailDisplays.FindIndex(b => b.ItemId == orderDetailDisplays[x].ItemId && b.UnitName == CmbUnitId.Text);
            if (xx>=0)
            {
                if (orderDetailDisplays[x].Qty < (decimal.Parse(TxtQty.Text.ToString()) + moveOrderDetailDisplays[xx].Qty))
                {
                    MessageBox.Show("لايمكن إضافة قيمة أكبر من طلب الشراء");
                    return;
                }
                MoveOrderDetailDisplay detailDisplay = new MoveOrderDetailDisplay
                {
                    Note = "",
                    ItemId = orderDetailDisplays[x].ItemId,
                    OrderDetailId = orderDetailDisplays[x].Id,
                    Qty = decimal.Parse(TxtQty.Text.ToString())+moveOrderDetailDisplays[xx].Qty,
                    UnitId = orderDetailDisplays[x].UnitId,
                    barcode = itemEndPoint.GetByID(orderDetailDisplays[x].ItemId).Barcode,
                    ItemName = orderDetailDisplays[x].ItemName,
                    UnitName = orderDetailDisplays[x].UnitName
                };
                moveOrderDetailDisplays.RemoveAt(xx);
                moveOrderDetailDisplays.Add(detailDisplay);
                datagridfill();
            }
            else
            {
                if (orderDetailDisplays[x].Qty < decimal.Parse(TxtQty.Text.ToString()))
                {
                    MessageBox.Show("لايمكن إضافة قيمة أكبر من طلب الشراء");
                    return;
                }
               MoveOrderDetailDisplay detailDisplay = new MoveOrderDetailDisplay
                {
                    Note = "",
                    ItemId = orderDetailDisplays[x].ItemId,
                    OrderDetailId = orderDetailDisplays[x].Id,
                    Qty = decimal.Parse(TxtQty.Text.ToString()),
                    UnitId = orderDetailDisplays[x].UnitId,
                    barcode = itemEndPoint.GetByID(orderDetailDisplays[x].ItemId).Barcode,
                    ItemName = orderDetailDisplays[x].ItemName,
                    UnitName = orderDetailDisplays[x].UnitName
                };
                moveOrderDetailDisplays.Add(detailDisplay);
                datagridfill();
            }
        }
        private void datagridfill()
        {
            dataGridView1.DataSource = null;
            var x = from b in moveOrderDetailDisplays
                    select new {
                        إسم_الصنف = b.ItemName, 
                        إسم_الوحدة = b.UnitName,
                        الكمية = b.Qty, 
                        باركود = b.barcode ,
                        b.UnitId,
                        b.ItemId
                    };
            dataGridView1.DataSource = x.ToList();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[3].DefaultCellStyle.Font= new Font("IDAHC39M Code 39 Barcode", 8.5F, GraphicsUnit.Pixel);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView2.Rows.Count - 1 && e.RowIndex >= 0)
            {
                TxtItemName.Text = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                TxtQty.Text = (string)dataGridView1[2, e.RowIndex].Value.ToString();
                TxtItemId.Text = (string)dataGridView1[5, e.RowIndex].Value.ToString();
                calcunit(int.Parse((string)dataGridView1[4, e.RowIndex].Value.ToString()), int.Parse((string)dataGridView1[5, e.RowIndex].Value.ToString()));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = moveOrderDetailDisplays.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()) && b.UnitName == CmbUnitId.Text);
            if(x>=0)
            {
                moveOrderDetailDisplays[x].Qty = decimal.Parse(TxtQty.Text.ToString());
                datagridfill();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbStock.SelectedIndex == -1 ||TxtDriveName.Text.Length ==0 || TxtCarBlate.Text.Length==0 || TxtCity.Text.Length ==0 )
            {
                MessageBox.Show("لايمكن أن يكون اسم المخزن أو اسم السائق أو رقم العربة أو المدينة خالية");
                return;
            }
            MoveorderDisplay moveOrder = new MoveorderDisplay
            {
                BarCode="",
                StockId = int.Parse(CmbStock.SelectedValue.ToString()),
                DriverName =TxtDriveName.Text,
                CarBlate = TxtCarBlate.Text,
                Odate =dateTimePicker1.Value,
                Note = TxtNote.Text
            };
            moveOrder.moveorderdetailDisplays = moveOrderDetailDisplays;
            try
            {
                MoveOrder order = new MoveOrder();
                order = mapper.Map<MoveOrder>(moveOrder);
                order.moveorderdetails = mapper.Map<List<MoveOrderDetail>>(moveOrderDetailDisplays);
                int x = moveorderEndPoint.Save(order);
                moveOrder.Id = x;
                moveorderDisplays.Add(moveOrder);
                count = moveorderDisplays.Count - 1;
                Navigation(count);
                MessageBox.Show("تم الحفظ بنجاح");
            }
          catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            moveorderDisplays[count].City = TxtCity.Text;
            moveorderDisplays[count].stockName = stockEndPoint.GetByID(moveorderDisplays[count].StockId).Name;
            moveorderDisplays[count].moveorderdetailDisplays = moveOrderDetailDisplays;
            int i = 1;
            foreach (var item in moveorderDisplays[count].moveorderdetailDisplays)
            {
                item.Counter = i;
                i++;
            }
            reportForms.start = 2;
            reportForms.MoveorderDisplay = moveorderDisplays[count];
            reportForms.ShowDialog();
        }
    }
}

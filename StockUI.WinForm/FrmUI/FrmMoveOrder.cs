using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.Model;
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
        private readonly ImoveorderEndPoint moveorderEndPoint;
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly IStockEndPoint stockEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private List<MoveorderDisplay> moveorderDisplays = new List<MoveorderDisplay>();
        private List<OrderDetailDisplay> orderDetailDisplays = new List<OrderDetailDisplay>();
        private List<UnitDisplay> unitDisplays = new List<UnitDisplay>();
        int count = 0;

        public FrmMoveOrder(IMapper mapper,ImoveorderdetailEndPoint moveorderdetailEndPoint,
            ImoveorderEndPoint moveorderEndPoint,IOrderDetailEndPoint orderDetailEndPoint
            ,IStockEndPoint stockEndPoint,IItemEndPoint itemEndPoint,IUnitEndPoint unitEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.moveorderdetailEndPoint = moveorderdetailEndPoint;
            this.moveorderEndPoint = moveorderEndPoint;
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.stockEndPoint = stockEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
        }
        private void CmbUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void FrmMoveOrder_Load(object sender, EventArgs e)
        {
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
                dateTimePicker1.Value = moveorderDisplays[id].Odate.Date;
                TxtNote.Text = moveorderDisplays[id].Note;
                TxtDriveName.Text = moveorderDisplays[id].DriverName;
                TxtCarBlate.Text = moveorderDisplays[id].CarBlate;
                TxtCity.Text = "";
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
                BtnUpdate.Enabled = true;
                Navigation(count);
                button5.Enabled = false;
                //button6.Enabled = false;
                dataGridView2.DataSource = null;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                BtnUpdate.Enabled = false;
                fillDataGridOrder();
                button5.Enabled = true;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Item item = new Item();
            //item = itemEndPoint.GetByID(neworder.OrderDetails[z].ItemId);
            //CmbDepartment.SelectedValue = item.DepartmentId;
            //CmbItemName.SelectedValue = item.Id;
            //CmbUnitId.SelectedValue = neworder.OrderDetails[z].UnitId;
            //modification = z;
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
            TxtItemName.Text = (string)dataGridView2[0, e.RowIndex].Value.ToString();
            TxtQty.Text = (string)dataGridView2[1, e.RowIndex].Value.ToString();
            TxtItemId.Text = (string)dataGridView2[4, e.RowIndex].Value.ToString();
            calcunit(int.Parse((string)dataGridView2[3, e.RowIndex].Value.ToString()), int.Parse((string)dataGridView2[4, e.RowIndex].Value.ToString()));
            
        }
    }
}

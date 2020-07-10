﻿using AutoMapper;
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
        private List<ItemDisplay> items = new List<ItemDisplay>();
        private List<OrderDisplay> orderDisplays = new List<OrderDisplay>();
        private List<UnitDisplay> unitDisplays = new List<UnitDisplay>();
        private List<OrderDetailDisplay> orderDetailDisplays = new List<OrderDetailDisplay>();
        int count = 0;
        public FrmOrder(IMapper mapper,IOrderEndPoint orderEndPoint,IOrderDetailEndPoint orderDetailEndPoint
            ,IUnitEndPoint unitEndPoint,IItemEndPoint itemEndPoint
            ,IBaseStockItemEndPoint baseStockItemEndPoint
            ,IDepartmentEndPoint departmentEndPoint,
            IStockEndPoint stockEndPoint,IStockItemEndPoint stockItemEndPoint)
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
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            items =mapper.Map<List<ItemDisplay>>(itemEndPoint.GetAll().ToList());
            loadstock();
            LoadDepartment();
            //loadItem();
            var output = orderEndPoint.GetAll().ToList();
            orderDisplays = mapper.Map<List<OrderDisplay>>(output);
            if(orderDisplays.Count>0)
            {
                Navigation(0);
                count = 0;
            }
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
            }
        }
        private void loadDetail(int id)
        {
            var output = orderDetailEndPoint.GetByID(id).ToList();
            var t = mapper.Map<List<OrderDetailDisplay>>(output);
            var x = (from b in t
                    select new 
                    { اسم = b.ItemName, الكمية = b.Qty,
                        سعرالوحدة = b.UnitPrice, الوحدة = b.UnitName
                    }).ToList();
            dataGridView1.DataSource = x;
            TxtTotal.Text = x.Sum(b => b.سعرالوحدة * b.الكمية).ToString("0.00");
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
            orderDetailDisplays.Clear();
            if (BtnNew.Text == "إلغاء")
            {
                BtnNew.Text = "جديد";
                BtnSave.Enabled = false;
                BtnUpdate.Enabled = true;
                Navigation(count);
            }
            else
            {
                BtnNew.Text = "إلغاء";
                BtnSave.Enabled = true;
                BtnUpdate.Enabled = false;
            }
        }
        private void calcunit(Item item)
        {
            var output = unitEndPoint.GetByUnitIdTest(item.UnitId).ToList();
            unitDisplays = mapper.Map<List<UnitDisplay>>(output);
            foreach (UnitDisplay unit in unitDisplays)
            {
                if (unit.Qty != null)
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
                int l;
                if (!int.TryParse(TxtItemId.Text.ToString(), out l))
                {
                    MessageBox.Show("رقم الصنف لايمكن ان يكون الا حروف");
                    return;
                }
                int bb = items.FindIndex(x => x.Id == l);
                
                if (bb ==-1)
                {
                    MessageBox.Show("لايوجد رقم يرجي التاكد من الرقم الصحيح");
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
        private Decimal loadBalance()
        {
           int kk = int.Parse(TxtItemId.Text.ToString());
            var output = stockItemEndPoint.GetItemByStock(kk).ToList();
            if(int.TryParse(CmbStock.SelectedValue?.ToString(),out kk))
            {
                var y = output.Where(x => x.StockId == kk).FirstOrDefault();
                if (y !=null)
                {
                    return y.Balance;
                }
               else
                {
                    return 0;
                }
            }
            return 0;
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
                int bbb;
                if (int.TryParse(CmbUnitId.SelectedValue.ToString(),out bbb))
                {
                    var x = unitDisplays.FindIndex(b => b.Id == bbb);
                    TxtItemQtyInStock.Text = unitDisplays[x].Qty.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        private void loadItem()
        {
            try
            {
                int bb;
                if (int.TryParse(CmbDepartment.SelectedValue.ToString(),out bb))
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
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadItem();
        }
    }
}
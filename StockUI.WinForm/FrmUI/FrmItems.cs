﻿using AutoMapper;
using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
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
        private readonly IKindEndPoint kindEndPoint;
        private readonly IItemEndPoint itemEndPoint;
        private readonly DepartmentEndPoint departmentEndPoint;
        private readonly Validation validation;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly IStockEndPoint stockEndPoint;
        private List<ItemDisplay> itemDisplays = new List<ItemDisplay>();
        int count = 0;
        public FrmItems(IMapper mapper,IUnitEndPoint unitEndPoint
            ,IKindEndPoint kindEndPoint,IItemEndPoint itemEndPoint
            ,DepartmentEndPoint departmentEndPoint,Validation validation
            ,IBaseStockItemEndPoint baseStockItemEndPoint
            ,IStockEndPoint stockEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.kindEndPoint = kindEndPoint;
            this.itemEndPoint = itemEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.validation = validation;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
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
                CmbKind.SelectedValue = itemDisplays[id].kindId;
                CmbUnit.SelectedValue = itemDisplays[id].UnitId;
                datagridfill(itemDisplays[id].Id);
                label5.Text = $"{count + 1} Of {itemDisplays.Count}";
            }
        }
        private void datagridfill(int id)
        {
            var x = baseStockItemEndPoint.GetAllItemStock(id).ToList();
            var output = (from b in x
                         select new { المخزن = b.Name, الكمية = b.Balance }).ToList();
            //dataGridView2.DataSource;
            dataGridView2.DataSource = output;
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
            string x = barcode();
            Item item = new Item
            {
                Barcode = x,
                kindId=int.Parse(CmbKind.SelectedValue.ToString()),
                DepartmentId = int.Parse(CmbDepartment.SelectedValue.ToString()),
                UnitId= int.Parse(CmbUnit.SelectedValue.ToString()),
                Name=TxtName.Text,
                Note=TxtNote.Text
            };
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
        private void button1_Click(object sender, EventArgs e)
        {
            Item item = new Item
            {
                Id= int.Parse(TxtId.Text.ToString()),
                kindId = int.Parse(CmbKind.SelectedValue.ToString()),
                DepartmentId = int.Parse(CmbDepartment.SelectedValue.ToString()),
                UnitId = int.Parse(CmbUnit.SelectedValue.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
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
    }
}

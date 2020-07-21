using AutoMapper;
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
    public partial class FrmStock : Form
    {
        private readonly IStockEndPoint stockEndPoint;
        private readonly Validation validation;
        private readonly IMapper mapper;
        private readonly IBaseStockItemEndPoint baseStockItemEndPoint;
        private readonly DataGridFormat dataGridFormat;
        private List< StockDisplay> stockDisplay = new List<StockDisplay>();
        private int count = 0;
        public FrmStock(IMapper mapper, IBaseStockItemEndPoint baseStockItemEndPoint, DataGridFormat dataGridFormat
            ,IStockEndPoint stockEndPoint, Validation validation)
        {
            InitializeComponent();
            this.stockEndPoint = stockEndPoint;
            this.validation = validation;
            this.mapper = mapper;
            this.baseStockItemEndPoint = baseStockItemEndPoint;
            this.dataGridFormat = dataGridFormat;
        }
        private void ChkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
                TxtFilter.Text = "";
                TxtFilter.ReadOnly =! ChkBoxFilter.Checked;
        }
        private void FrmStock_Load(object sender, EventArgs e)
        {
            var output = stockEndPoint.GetAll();
            stockDisplay = mapper.Map<List<StockDisplay>>(output);
            if (stockDisplay.Count>0)
            {
                navigation(0);
                count = 0;
            }
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtNote.Text = "";
            dataGridView1.DataSource = "";
            ChkBoxFilter.Checked = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock
            {
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (validation.validatestock(stock))
            {
                stockEndPoint.Save(stock);
                var output = stockEndPoint.GetByName(stock.Name);
                stockDisplay.Add(mapper.Map<StockDisplay>(output));
                count = stockDisplay.Count - 1;
                navigation(count);
                MessageBox.Show("تم حفظ المخزن بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock
            {
                Id = int.Parse(TxtId.Text.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (validation.validatestock(stock))
            {
                stockEndPoint.Update(stock);
                stockDisplay[count].Name = TxtName.Text;
                stockDisplay[count].Note = TxtNote.Text;
                MessageBox.Show("تم التعديل بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }
        #region the navigation for system
        private void navigation(int id)
        {
            if (id >=0 && id<=stockDisplay.Count-1)
            {
                filldategrid(id);
                TxtId.Text = stockDisplay[id].Id.ToString();
                TxtName.Text = stockDisplay[id].Name;
                TxtNote.Text = stockDisplay[id].Note;
                label5.Text = $"{count + 1}  Of {stockDisplay.Count}";
                dataGridFormat.Style(dataGridView1);
            }
        }
        private void filldategrid(int id)
        {
            dataGridView1.DataSource = null;
            var output = (from b in stockDisplay[id].baseStockITems.ToList()
                         select new { رقم_الصنف = b.Itemid, إسم_الصنف = b.Name, الكمية = b.Balance }).ToList();
            dataGridView1.DataSource = output;
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count>0)
            {
                count -= 1;
                navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count > stockDisplay.Count)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = stockDisplay.Count;
            navigation(count);
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }

        #endregion
    }
}

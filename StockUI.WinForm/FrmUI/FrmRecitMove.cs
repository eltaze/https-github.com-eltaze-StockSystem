using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using StockUI.WinForm.Formating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmRecitMove : Form
    {
        private readonly IMapper mapper;
        private readonly ImoveorderdetailEndPoint moveorderdetailEndPoint;
        private readonly DataGridFormat dataGridFormat;
        private readonly ImoveorderEndPoint moveorderEndPoint;
        private readonly IOrderDetailEndPoint orderDetailEndPoint;
        private readonly ReportForms reportForms;
        private readonly IStockItemEndPoint stockItemEndPoint;
        private readonly IRecitItemEndPoint recitItemEndPoint;
        private readonly IStockEndPoint stockEndPoint;
        private readonly UnitConversions unitConversions;
        private readonly IItemEndPoint itemEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private List<Stock> stocks = new List<Stock>();
        private List<stockitem> stockitems = new List<stockitem>();
        private List<MoveorderDisplay> moveorderDisplays = new List<MoveorderDisplay>();
        private List<ItemRecitDetail> ItemRecitDetails = new List<ItemRecitDetail>();
        private List<MoveOrderDetailDisplay> moveOrderDetailDisplays = new List<MoveOrderDetailDisplay>();
        private List<ItemRecitDetailDisplay> ItemRecitDetailDisplays = new List<ItemRecitDetailDisplay>();
        int count = 0;

        public FrmRecitMove(IMapper mapper, ImoveorderdetailEndPoint moveorderdetailEndPoint, DataGridFormat dataGridFormat
            , ImoveorderEndPoint moveorderEndPoint, IOrderDetailEndPoint orderDetailEndPoint, ReportForms reportForms 
            ,IStockItemEndPoint stockItemEndPoint,IRecitItemEndPoint recitItemEndPoint
            , IStockEndPoint stockEndPoint, UnitConversions unitConversions
            , IItemEndPoint itemEndPoint, IUnitEndPoint unitEndPoint)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.moveorderdetailEndPoint = moveorderdetailEndPoint;
            this.dataGridFormat = dataGridFormat;
            this.moveorderEndPoint = moveorderEndPoint;
            this.orderDetailEndPoint = orderDetailEndPoint;
            this.reportForms = reportForms;
            this.stockItemEndPoint = stockItemEndPoint;
            this.recitItemEndPoint = recitItemEndPoint;
            this.stockEndPoint = stockEndPoint;
            this.unitConversions = unitConversions;
            this.itemEndPoint = itemEndPoint;
            this.unitEndPoint = unitEndPoint;
        }
        private void FrmRecitMove_Load(object sender, EventArgs e)
        {
            moveorderDisplays = mapper.Map<List<MoveorderDisplay>>(moveorderEndPoint.GetMoveOrdersNotRecit());
            stocks = stockEndPoint.GetAll();
            CmbStock.DataSource = stocks.ToList();
            CmbStock.ValueMember = "id";
            CmbStock.DisplayMember = "Name";
            if (moveorderDisplays.Count > 0)
            {
                count = 0;
                navigation(count);
            }
        }
        #region Navigation For System
        private void navigation(int id)
        {
            if (id >= 0 && id <= moveorderDisplays.Count - 1)
            {
                TxtId.Text = moveorderDisplays[id].Id.ToString();
                CmbStock.SelectedValue = moveorderDisplays[id].StockId;
                //dateTimePicker1.Value = moveorderDisplays[id].Odate;
                TxtCarBlate.Text = moveorderDisplays[id].CarBlate;
                TxtDriveName.Text = moveorderDisplays[id].DriverName;
                TxtNote.Text = moveorderDisplays[id].Note;
                label11.Text = $"{count + 1} Of {moveorderDisplays.Count}";
            }
            LoadDetail(moveorderDisplays[id].Id);
        }
        private void LoadDetail(int id)
        {
            moveOrderDetailDisplays.Clear();
            moveOrderDetailDisplays = mapper.Map<List<MoveOrderDetailDisplay>>(moveorderdetailEndPoint.GetByMoveOrderId(id));
            foreach (MoveOrderDetailDisplay item in moveOrderDetailDisplays)
            {
                item.ItemName = itemEndPoint.GetByID(item.ItemId).Name;
                item.UnitName = unitEndPoint.GetByID(item.UnitId).Name;
            }
            filldatagrid1();
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
            if (count < moveorderDisplays.Count)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = moveorderDisplays.Count - 1;
            navigation(count);
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        #endregion
        private void filldatagrid1()
        {
            var x = (from b in moveOrderDetailDisplays
                     select new
                     {
                         اسم_الصنف = b.ItemName,
                         إسم_الوحدة = b.UnitName,
                         الكمية = b.Qty,
                         b.ItemId,
                         b.UnitId
                     }).ToList();
            dataGridView2.DataSource = x.ToList();
            dataGridFormat.Style(dataGridView2);
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
        }
        private void filldategrid2()
        {
            var x = (from b in ItemRecitDetailDisplays
                     select new
                     {
                         الصنف =b.ItemName,
                         الكمية=b.Qty,
                         الوحدة=b.UnitName,
                         b.ItemId,b.UnitId
                     }).ToList();
            dataGridView1.DataSource = x;
            dataGridFormat.Style(dataGridView1);
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView2.Rows.Count - 1 && e.RowIndex >= 0)
            {
                TxtItemName.Text = (string)dataGridView2[0, e.RowIndex].Value.ToString();
                TxtQty.Text = (string)dataGridView2[2, e.RowIndex].Value.ToString();
                TxtItemId.Text = (string)dataGridView2[3, e.RowIndex].Value.ToString();
                CmbUnitId.Text = (string)dataGridView2[1, e.RowIndex].Value.ToString();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int y = moveOrderDetailDisplays.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            if (decimal.Parse(TxtQty.Text.ToString()) > moveOrderDetailDisplays[y].Qty)
            {
                MessageBox.Show("الكمية أكبر من قيمة المرسلة لايمكن إنجاز العملية");
                return;
            }
            var x = unitEndPoint.GetByName(CmbUnitId.Text);
            stockitems.Add(stockIt(decimal.Parse(TxtQty.Text.ToString()), int.Parse(TxtItemId.Text.ToString()), x.Id, int.Parse(CmbStock.SelectedValue.ToString())));
            ItemRecitDetailDisplay display = new ItemRecitDetailDisplay
            {
                ItemId = int.Parse(TxtItemId.Text.ToString()),
                UnitId = x.Id,
                UnitName = CmbUnitId.Text,
                ItemName = TxtItemName.Text,
                Qty = decimal.Parse(TxtQty.Text.ToString()),
            };
            ItemRecitDetailDisplays.Add(display);
            filldategrid2();
        }
        private stockitem stockIt(decimal qty, int itemid, int unitid, int stockid)
        {
            var stockitem = stockItemEndPoint.GetByStockItem(stockid, itemid);

            if (stockitem == null)
            {
                stockitem x = new stockitem
                {
                    ItemId = itemid,
                    StockId = stockid,
                    Balance = qty,
                    UnitId = unitid
                };
                stockitem = x;
            }
            else
            {
                if (stockitem.UnitId == unitid)
                {
                    stockitem.Balance += qty;
                }
                else
                {
                    var x = unitEndPoint.GetByID(unitid);
                    var y = unitEndPoint.GetByID(stockitem.UnitId);
                    stockitem.Balance = unitConversions.GetConvert(y, x, stockitem.Balance);
                    stockitem.UnitId = unitid;
                    stockitem.Balance += qty;
                }
            }
            return stockitem;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in moveOrderDetailDisplays)
            {
                var x = unitEndPoint.GetByName(CmbUnitId.Text);
                stockitems.Add(stockIt(item.Qty, item.ItemId, item.UnitId, int.Parse(CmbStock.SelectedValue.ToString())));
                ItemRecitDetailDisplay display = new ItemRecitDetailDisplay
                {
                    ItemId = item.ItemId,
                    UnitId = item.UnitId,
                    UnitName = item.UnitName,
                    ItemName = item.ItemName,
                    Qty = item.Qty,
                };
                ItemRecitDetailDisplays.Add(display);
                filldategrid2();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int y = moveOrderDetailDisplays.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            int z = stockitems.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            if (decimal.Parse(TxtQty.Text.ToString()) > moveOrderDetailDisplays[y].Qty)
            {
                MessageBox.Show("الكمية أكبر من قيمة المرسلة لايمكن إنجاز العملية");
                return;
            }
            int x = ItemRecitDetailDisplays.FindIndex(b => b.ItemId == int.Parse(TxtItemId.Text.ToString()));
            if (x==-1)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                return;
            }
            decimal bb = decimal.Parse(TxtQty.Text.ToString());
            decimal balance = bb- ItemRecitDetailDisplays[x].Qty;
            stockitems[z].Balance += balance;
            ItemRecitDetailDisplays[x].Qty = decimal.Parse(TxtQty.Text.ToString());
            filldategrid2();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                TxtItemName.Text = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                TxtQty.Text = (string)dataGridView1[2, e.RowIndex].Value.ToString();
                TxtItemId.Text = (string)dataGridView1[3, e.RowIndex].Value.ToString();
                CmbUnitId.Text = (string)dataGridView1[1, e.RowIndex].Value.ToString();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ItemRecit itemRecit = new ItemRecit
            {
                MoveOrderId = int.Parse(TxtId.Text),
                Note = TxtNote.Text,
                Odate = dateTimePicker1.Value,
                RecitFrom = "أمر تحرك",
                StockId = int.Parse(CmbStock.SelectedValue.ToString())
            };
            itemRecit.recitItemDetails = mapper.Map<List<ItemRecitDetail>>(ItemRecitDetailDisplays);
            int x = recitItemEndPoint.Save(itemRecit, stockitems);
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}

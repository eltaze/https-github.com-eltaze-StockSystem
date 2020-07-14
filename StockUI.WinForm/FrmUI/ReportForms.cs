using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class ReportForms : Form
    {
        public ReportForms()
        {
            InitializeComponent();
        }
        public OrderDisplay OrderDisplay = new OrderDisplay();
        public MoveorderDisplay MoveorderDisplay = new MoveorderDisplay();
        public int start = 0;
        private void ReportForms_Load(object sender, EventArgs e)
        {
            if (start==1)
            {
                orderforms();
            }
            else if (start ==2)
            {
                moveorderforms();
            }
        }
        private void orderforms()
        {
            OrderDisplayBindingSource.DataSource = OrderDisplay;
            bindingSource1.DataSource = OrderDisplay.OrderDetails;
          //  this.reportViewer1.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.OrderReport.rdlc";
            reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer2.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        private void moveorderforms()
        {
            MoveOrderDetailDisplayBindingSource.DataSource = MoveorderDisplay.moveorderdetailDisplays;
            MoveorderDisplayBindingSource.DataSource = MoveorderDisplay;
            //this.reportViewer2.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.RptMoveOrder.rdlc";
            reportViewer2.Dock= System.Windows.Forms.DockStyle.Fill;
            reportViewer2.LocalReport.EnableExternalImages = true;
            reportViewer1.Visible = false;
            this.reportViewer2.RefreshReport();
        }
    }
}

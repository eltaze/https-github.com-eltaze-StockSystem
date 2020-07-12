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

        private void ReportForms_Load(object sender, EventArgs e)
        {
            OrderDisplayBindingSource.DataSource = OrderDisplay;
            bindingSource1.DataSource = OrderDisplay.OrderDetails;
            this.reportViewer1.RefreshReport();
        }
    }
}

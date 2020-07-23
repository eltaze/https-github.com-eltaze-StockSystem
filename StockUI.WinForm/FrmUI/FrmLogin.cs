using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using StockSystem.Libarary.Interfaces;
using StockUI.Libarary.BL;
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
    public partial class FrmLogin : Form
    {
        private readonly IUserEndPoint userEndPoint;
        private readonly Encode encode;
        public FrmDashBoard frmDashBoard;
        private bool loged = false;
        public FrmLogin(IUserEndPoint userEndPoint,Encode encode)
        {
            InitializeComponent();
            this.userEndPoint = userEndPoint;
            this.encode = encode;
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        public Boolean validate()
        {
            return loged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = userEndPoint.GetByName(TxtId.Text);
            if(x == null || TxtName.Text != encode.Base64Decode(x.Password.ToString()) )
            {
                MessageBox.Show("كلمة المرور أو إسم المستخدم خطأ");
                loged = false;
                return;
            }
            MessageBox.Show($"مرحبا بك {TxtId.Text}");
            frmDashBoard.UserName = TxtId.Text;
            loged = true;
            this.Close();
        }
    }
}

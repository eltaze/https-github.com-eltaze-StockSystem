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
    public partial class FrmDashBoard : Form
    {
        private readonly FrmItems frmItems;
        private readonly FrmMoveOrder frmMoveOrder;
        private readonly FrmUnit frmUnit;
        private readonly FrmDepartment frmDepartment;
        private readonly FrmKind frmKind;
        private readonly FrmStock frmStock;
        private readonly FrmLogin frmLogin;
        private readonly FrmUserRegister frmUserRegister;
        private readonly FrmRecitMove frmRecitMove;
        private readonly FrmDismisItem frmDismisItem;
        private readonly UserValidation userValidation;
        private readonly FrmOrder frmOrder;
        private readonly FrmItemRecit frmItemRecit;
        public string UserName="User Name";
        public FrmDashBoard(FrmItems frmItems,FrmMoveOrder frmMoveOrder,FrmUnit frmUnit,FrmDepartment frmDepartment
                            , FrmKind frmKind, FrmStock frmStock, FrmLogin frmLogin,FrmUserRegister frmUserRegister
                            , FrmRecitMove frmRecitMove,FrmDismisItem frmDismisItem,UserValidation userValidation
                            ,FrmOrder frmOrder,FrmItemRecit frmItemRecit)
        {

            InitializeComponent();
            this.frmItems = frmItems;
            this.frmMoveOrder = frmMoveOrder;
            this.frmUnit = frmUnit;
            this.frmDepartment = frmDepartment;
            this.frmKind = frmKind;
            this.frmStock = frmStock;
            this.frmLogin = frmLogin;
            this.frmUserRegister = frmUserRegister;
            this.frmRecitMove = frmRecitMove;
            this.frmDismisItem = frmDismisItem;
            this.userValidation = userValidation;
            this.frmOrder = frmOrder;
            this.frmItemRecit = frmItemRecit;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(frmMoveOrder);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(frmItems);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(frmOrder);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadForm(frmItemRecit);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadForm(frmRecitMove);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            LoadForm(frmDismisItem);
        }
        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            frmLogin.frmDashBoard = this;
            frmLogin.userValidation = userValidation;
            frmLogin.ShowDialog();
            if (frmLogin.validate() == false)
            {
                this.Dispose();
            }
            LblUser.Text = UserName;
            validate();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            LoadForm(frmUnit);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            LoadForm(frmDepartment);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            LoadForm(frmStock);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (userValidation.validateForm("FrmKind") == false)
            {
                MessageBox.Show("لايمكنك الدخول برجاء مراجعة الإدارة");
                return;
            }
            LoadForm (frmKind);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            LoadForm(frmUserRegister);
        }
        private void LoadForm(Form form)
        {
            form.InitializeLifetimeService();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
        private void validate()
        {
            if (userValidation.validateForm("FrmOrder")==false)
            {
                BtnOrder.Enabled = false;
            }
        }
    }
}

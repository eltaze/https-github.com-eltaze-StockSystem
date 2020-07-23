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
       
        private readonly FrmRecitMove frmRecitMove;
        private readonly FrmDismisItem frmDismisItem;
        private readonly FrmOrder frmOrder;
        private readonly FrmItemRecit frmItemRecit;
        public string UserName="User Name";
        public FrmDashBoard(FrmItems frmItems,FrmMoveOrder frmMoveOrder,FrmUnit frmUnit,FrmDepartment frmDepartment
                            , FrmKind frmKind, FrmStock frmStock, FrmLogin frmLogin
                            , FrmRecitMove frmRecitMove,FrmDismisItem frmDismisItem
                            ,FrmOrder frmOrder,FrmItemRecit frmItemRecit)
        {
            frmLogin.ShowDialog();
            if (frmLogin.validate() == false)
            {
                this.Dispose();
            }
          
            InitializeComponent();
            this.frmItems = frmItems;
            this.frmMoveOrder = frmMoveOrder;
            this.frmUnit = frmUnit;
            this.frmDepartment = frmDepartment;
            this.frmKind = frmKind;
            this.frmStock = frmStock;
            this.frmLogin = frmLogin;       
            this.frmRecitMove = frmRecitMove;
            this.frmDismisItem = frmDismisItem;
            this.frmOrder = frmOrder;
            this.frmItemRecit = frmItemRecit;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmMoveOrder.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmItems.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmOrder.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            frmItemRecit.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            frmRecitMove.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            frmDismisItem.ShowDialog();
        }
        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            LblUser.Text = UserName;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            frmUnit.ShowDialog();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            frmDepartment.ShowDialog();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            frmStock.ShowDialog();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            frmKind.ShowDialog();
        }
    }
}

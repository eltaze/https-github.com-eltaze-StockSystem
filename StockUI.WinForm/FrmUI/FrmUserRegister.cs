using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
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
    public partial class FrmUserRegister : Form
    {
        private readonly IUserEndPoint userEndPoint;
        private readonly Encode encode;
        private readonly IUserRightEndPoint userRightEndPoint;
        private List<User> users = new List<User>();
        private List<Right> rights = new List<Right>();
        public FrmUserRegister(IUserEndPoint userEndPoint, Encode encode,IUserRightEndPoint userRightEndPoint)
        {
            InitializeComponent();
            this.userEndPoint = userEndPoint;
            this.encode = encode;
            this.userRightEndPoint = userRightEndPoint;
        }

        private void FrmUserRegister_Load(object sender, EventArgs e)
        {
            rights = userRightEndPoint.GetRights();
            CmbRight.DataSource = rights.ToList();
            CmbRight.ValueMember = "Id";
            CmbRight.DisplayMember = "Note";
            users = userEndPoint.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtPassword.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TxtId.Text.Length ==0 || TxtName.Text.Length<6 || TxtPassword.Text != TxtName.Text)
            {
                MessageBox.Show("كلمة المرور يجب أن تكون أعلي من 6 أحرف ويجب تأكيد كلمة المرور والإسم لايمكن أن يكون خالي");
                return;
            }
            var x = users.FindIndex(b => b.Name == TxtId.Text);
            if (x > -1)
            {
                MessageBox.Show("إسم المستخدم مدخل مسبقا");
                return;
            }
            User user = new User
            {
                Name = TxtId.Text,
                Password = encode.Base64Encode(TxtName.Text)
            };
            userEndPoint.Save(user);
            MessageBox.Show("تم حفظ بنجاح");
        }
    }
}

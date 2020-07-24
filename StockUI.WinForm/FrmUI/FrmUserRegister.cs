using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.WinForm.Formating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmUserRegister : Form
    {
        private readonly IUserEndPoint userEndPoint;
        private readonly Encode encode;
        private readonly DataGridFormat dataGridFormat;
        private readonly IUserRightEndPoint userRightEndPoint;
        private List<User> users = new List<User>();
        private List<Right> rights = new List<Right>();
        int count = 0;
        public FrmUserRegister(IUserEndPoint userEndPoint, Encode encode,DataGridFormat dataGridFormat
                               ,IUserRightEndPoint userRightEndPoint)
        {
            InitializeComponent();
            this.userEndPoint = userEndPoint;
            this.encode = encode;
            this.dataGridFormat = dataGridFormat;
            this.userRightEndPoint = userRightEndPoint;
        }

        private void FrmUserRegister_Load(object sender, EventArgs e)
        {
            rights = userRightEndPoint.GetRights();
            var x = from b in rights
                    where  b.Note != ""
                    select b;
            CmbRight.DataSource = x.ToList();
            CmbRight.ValueMember = "Id";
            CmbRight.DisplayMember = "Note";
            users = userEndPoint.GetAll();
            if (users.Count >0)
            {
                navigation(0);
                count = 0;
            }
        }
        #region Naigation system
        private void navigation(int id)
        {
            if (id>=0 && id <=users.Count-1)
            {
                TxtId.Text = users[id].Name;
                var x = userRightEndPoint.GetRight(users[id].Id);
                rights = x.Rights;
                filldate();
            }
        }
        private void filldate()
        {
            var xx = from b in rights
                     select new
                     {
                        الصلاحيات=b.Note
                     };
            dataGridView1.DataSource = xx.ToList();
            dataGridFormat.Style(dataGridView1);
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count > users.Count - 1)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count -= 1;
                navigation(count);
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = users.Count - 1;
            navigation(count);
        }
        #endregion
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
            var xx =userEndPoint.GetByName(user.Name);
            users.Add(xx);
            count = users.Count - 1;
            navigation(count);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (RdAdd.Checked==false && RdDelete.Checked ==false)
            {
                MessageBox.Show("يرجي تحديد إضافة أم حذف");
                return;
            }
            if (RdAdd.Checked)
            {
                add();
            }
            else
            {
                remove();
            }
        }
        private void add()
        {
            int x = rights.FindIndex(b => b.Id == int.Parse(CmbRight.SelectedValue.ToString()));
            if (x !=-1)
            {
                return;
            }
            Right right = new Right
            {
                Id = int.Parse(CmbRight.SelectedValue.ToString()),
                Note = CmbRight.Text
            };
            rights.Add(right);
            filldate();
        }
        private void remove()
        {
            int x = rights.FindIndex(b => b.Id == int.Parse(CmbRight.SelectedValue.ToString()));
            if (x > -1)
            {
                rights.RemoveAt(x);
                filldate();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                string x = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                int y = rights.FindIndex(b => b.Note == x);
                CmbRight.SelectedValue = rights[y].Id;
            }
        }
    }
}

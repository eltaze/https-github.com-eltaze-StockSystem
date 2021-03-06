﻿using StockSystem.Libarary.Interfaces;
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
        public FrmUserRegister(IUserEndPoint userEndPoint, Encode encode, DataGridFormat dataGridFormat
                               , IUserRightEndPoint userRightEndPoint)
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
                    where b.Note != ""
                    select b;
            CmbRight.DataSource = x.ToList();
            CmbRight.ValueMember = "Id";
            CmbRight.DisplayMember = "Note";
            users = userEndPoint.GetAll();
            if (users.Count > 0)
            {
                count = 0;
                navigation(0);
            }
        }
        #region Naigation system
        private void navigation(int id)
        {
            if (id >= 0 && id <= users.Count - 1)
            {
                TxtId.Text = users[id].Name;
                var x = userRightEndPoint.GetRight(users[id].Id);
                TxtName.Text = "";
                TxtPassword.Text = "";
                rights.Clear();
                rights = x.Rights;
                filldate();
                label5.Text = $"{count + 1} Of {users.Count}";
            }
        }
        private void filldate()
        {
            var xx = from b in rights
                     select new
                     {
                         الصلاحيات = b.Note,
                         كتابة_و_قراءة = b.Read,
                         التعديل = b.Edit,
                         الحذف = b.Delete
                     };
            dataGridView1.DataSource = xx.ToList();
            dataGridFormat.Style(dataGridView1);
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (count < users.Count )
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
            CmbRight.SelectedIndex = -1;
            rights.Clear();
            chekc();
            filldate();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (TxtId.Text.Length == 0 || TxtName.Text.Length < 6 || TxtPassword.Text != TxtName.Text)
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
            var xx = userEndPoint.GetByName(user.Name);
            users.Add(xx);
            button6_Click(sender, e);
            count = users.Count - 1;
            navigation(count);
        }
        private void add()
        {
            int x = rights.FindIndex(b => b.Id == int.Parse(CmbRight.SelectedValue.ToString()));
            if (x != -1)
            {
                if (ChkDelete.Checked)
                {
                    rights[x].Delete = true;
                }
                if (ChkEdit.Checked)
                {
                    rights[x].Edit = true;
                }
                if (ChkRead.Checked)
                {
                    rights[x].Read = true;
                }
                filldate();
                return;
            }
            Right right = new Right
            {
                Id = int.Parse(CmbRight.SelectedValue.ToString()),
                Note = CmbRight.Text
            };
            if (ChkDelete.Checked)
            {
                right.Delete = true;
            }
            if (ChkEdit.Checked)
            {
                right.Edit = true;
            }
            if (ChkRead.Checked)
            {
                right.Read = true;
            }
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
        private void chekc()
        {
            ChkDelete.Checked = false;
            ChkEdit.Checked = false;
            ChkRead.Checked = false;
            RdAdd.Checked = false;
            RdDelete.Checked = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                chekc();
                string x = (string)dataGridView1[0, e.RowIndex].Value.ToString();
                int y = rights.FindIndex(b => b.Note == x);
                CmbRight.SelectedValue = rights[y].Id;
                if (rights[y].Read == true)
                {
                    ChkRead.Checked = true;
                }
                if (rights[y].Edit == true)
                {
                    ChkEdit.Checked = true;
                }
                if (rights[y].Delete == true)
                {
                    ChkDelete.Checked = true;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (RdAdd.Checked == false && RdDelete.Checked == false)
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
            chekc();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Right item in rights)
            {
                User f = new User();
                f = users[count];
                f.Rights.Clear();
                var x = userRightEndPoint.SelectUserRight(users[count].Id, item.Id);
                if (x != null)
                {
                    f.Rights.Add(item);
                    userRightEndPoint.updateRight(f);
                }
                else
                {
                    f.Rights.Add(item);
                    userRightEndPoint.insertUserRight(f);
                }
            }
            MessageBox.Show("تم الحفظ التعديلات في الصلاحيات بنجاح");
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if(  TxtName.Text.Length < 6 || TxtPassword.Text != TxtName.Text)
           {
                MessageBox.Show("الكلمة مرور غير متطابقة أو أقل من 6 أحرف");
                return;
           }
            users[count].Password = encode.Base64Encode(TxtName.Text);
            userEndPoint.Update(users[count]);
            MessageBox.Show("تم تغير كلمة المرور بنجاح");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Right item in rights)
            {
                User f = new User();
                f = users[count];
                f.Rights.Clear();
                f.Rights.Add(item);
                userRightEndPoint.DeleteRight(f);
            }
            userEndPoint.Delete(users[count]);
            users.RemoveAt(count);
            count = users.Count - 1;
            navigation(count);
            MessageBox.Show("تم مسح المستخدم بنجاح");
        }
    }
}

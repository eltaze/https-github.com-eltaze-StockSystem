using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmKind : Form
    {
        private readonly IMapper mapper;
        private readonly Validation validation;
        private readonly IKindEndPoint kindEndPoint;
        private readonly UserValidation userValidation;
        private List<KindDisplay> kindDisplays = new List<KindDisplay>();
        int count = 0;
        public FrmKind(IMapper mapper, Validation validation,IKindEndPoint kindEndPoint,UserValidation userValidation)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.validation = validation;
            this.kindEndPoint = kindEndPoint;
            this.userValidation = userValidation;
        }
        private void FrmKind_Load(object sender, EventArgs e)
        {
            BtnDelete.Enabled = userValidation.validateDelete("FrmKind");
            BtnEdit.Enabled = userValidation.validateEdit("FrmKind");
            var output = kindEndPoint.GetAll().ToList();
            kindDisplays = mapper.Map<List<KindDisplay>>(output);
            if (kindDisplays.Count>0)
            {
                navigation(0);
                count = 0;
            }
        }
        #region Navigation for system
        private void navigation(int id)
        {
            if (id>=0 && id<=kindDisplays.Count-1)
            {
                TxtId.Text = kindDisplays[id].Id.ToString();
                TxtName.Text = kindDisplays[id].Name;
                TxtNote.Text = kindDisplays[id].Note;
                label5.Text = $"{count + 1} Of {kindDisplays.Count}";
            }
        }
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(count>0)
            {
                count = -1;
                navigation(count);
            }
        }
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (count < kindDisplays.Count)
            {
                count += 1;
                navigation(count);
            }
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = kindDisplays.Count - 1;
            navigation(count);
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtNote.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Kind kind = new Kind
            {
                Name = TxtName.Text,
                Note=TxtNote.Text
            };
            if (validation.validateKind(kind))
            {
                kindEndPoint.Save(kind);
                kind = kindEndPoint.GetByName(kind.Name);
                kindDisplays.Add(mapper.Map<KindDisplay>(kind));
                count = kindDisplays.Count - 1;
                navigation(count);
                MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Kind kind = new Kind
            {
                Id = int.Parse(TxtId.Text.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (validation.validateKind(kind))
            {
                kindEndPoint.Update(kind);
                kindDisplays[count].Name = TxtName.Text;
                kindDisplays[count].Note = TxtNote.Text;
                MessageBox.Show("تم الحفظ   التعديل بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
            //Kind kind = new Kind
            //{
            //    Name = TxtName.Text,
            //    Note = TxtNote.Text
            //};
            //if (validation.validateKind(kind))
            //{
            //    kindEndPoint.Update(kind);
            //    kindDisplays[count].Name = TxtName.Text;
            //    kindDisplays[count].Note = TxtNote.Text;
            //    MessageBox.Show("تم التعديل بنجاح");
            //}
            //else
            //{
            //    MessageBox.Show(validation.massege);
            //}
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Kind kind = new Kind
            {
                Id = kindDisplays[count].Id,
                Name = kindDisplays[count].Name,
                Note = kindDisplays[count].Note
            };
            kindEndPoint.Delete(kind);
            kindDisplays.RemoveAt(count);
            MessageBox.Show("تم الحذف بنجاح");
            count = kindDisplays.Count - 1;
            navigation(count);
        }
    }
}

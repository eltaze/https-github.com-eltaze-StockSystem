using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
using StockUI.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockUI.WinForm.FrmUI
{
    public partial class FrmDepartment : Form
    {
        private readonly IMapper mapper;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly Validation validation;
        private List<DepartmentDisplay> departmentDisplays = new List<DepartmentDisplay>();
        int count = 0;
        public FrmDepartment(IMapper mapper,IDepartmentEndPoint departmentEndPoint,Validation validation)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.departmentEndPoint = departmentEndPoint;
            this.validation = validation;
        }
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            var output = departmentEndPoint.GetAll();
            departmentDisplays = mapper.Map<List<DepartmentDisplay>>(output);
            if (departmentDisplays.Count>0)
            {
                navigation(0);
                count = 0;
            }
        }
        #region Navigation
        private void navigation(int id)
        {
            if (id >=0 && id <= departmentDisplays.Count-1)
            {
                TxtId.Text = departmentDisplays[id].Id.ToString();
                TxtName.Text = departmentDisplays[id].Name;
                TxtNote.Text = departmentDisplays[id].Note;
                label5.Text = $"{count + 1} Of {departmentDisplays.Count}";
            }
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
            if (count<departmentDisplays.Count)
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
            count = departmentDisplays.Count - 1;
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
            department department = new department
            {
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (validation.validatedepartment(department))
            {
                departmentEndPoint.Save(department);
                var output = departmentEndPoint.GetByName(department.Name);
                departmentDisplays.Add(mapper.Map<DepartmentDisplay>(output));
                count = departmentDisplays.Count - 1;
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
            department department = new department
            {
                Id = int.Parse(TxtId.Text.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text
            };
            if (validation.validatedepartment(department))
            {
                departmentEndPoint.Update(department);
                departmentDisplays[count].Name = department.Name;
                departmentDisplays[count].Note = department.Note;
                MessageBox.Show("تم الحفظ التعديل بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }
    }
}

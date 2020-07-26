using AutoMapper;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using StockUI.Libarary.BL;
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
    public partial class FrmUnit : Form
    {
        private readonly IMapper mapper;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly UserValidation userValidation;
        private readonly Validation validation;
        private List<UnitDisplay> unitDisplays = new List<UnitDisplay>();
        private int count = 0;
        public FrmUnit(IMapper mapper ,IUnitEndPoint unitEndPoint,UserValidation userValidation,Validation validation)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.unitEndPoint = unitEndPoint;
            this.userValidation = userValidation;
            this.validation = validation;
        }
        private void FrmUnit_Load(object sender, EventArgs e)
        {
            BtnEdit.Enabled = userValidation.validateEdit("FrmUnit");
            Btndelete.Enabled = userValidation.validateDelete("FrmUnit");
            var output = unitEndPoint.GetAll();
            unitDisplays = mapper.Map<List<UnitDisplay>>(output);
            if (unitDisplays.Count>0)
            {
                cmbload();
                count = 0;
                navigation(0);
            }
        }
        #region Navigations of unit form
        private void navigation(int id)
        {
            if (id >=0  && id <= unitDisplays.Count-1)
            {
                TxtId.Text = unitDisplays[id].Id.ToString();
                TxtName.Text = unitDisplays[id].Name;
                TxtNote.Text = unitDisplays[id].Note;
                if (unitDisplays[id].UnitId !=null)
                {
                    checkBox1.Checked = true;
                    CmbUnitId.SelectedValue = unitDisplays[id].UnitId;
                    TxtQty.Text = unitDisplays[id].Qty.ToString();
                    TxtQuntityFormBig.Text = unitDisplays[id].QTYTOPARENT.ToString();
                }
                else
                {
                    checkBox1.Checked = false;
                    CmbUnitId.SelectedIndex = -1;
                    TxtQty.Text = "";
                    TxtQuntityFormBig.Text = "";
                }
                label5.Text = $"{count + 1} Of {unitDisplays.Count}";
            }
        }
        private void cmbload()
        {
            CmbUnitId.DataSource = null;
            CmbUnitId.DataSource = unitDisplays;
            CmbUnitId.ValueMember = "Id";
            CmbUnitId.DisplayMember = "Name";
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
            if (count < unitDisplays.Count-1)
            {
                count += 1;
                navigation(count);
            }
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            count = unitDisplays.Count - 1;
            navigation(count);
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            count = 0;
            navigation(count);
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtNote.Text = "";
            TxtQty.Text = "";
            TxtQuntityFormBig.Text = "";
            TxtQuntityFormBig.Text = "1";
            checkBox1.Checked = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {      
                CmbUnitId.Enabled = checkBox1.Checked;
                TxtQty.ReadOnly = !checkBox1.Checked;
                TxtQuntityFormBig.ReadOnly = !checkBox1.Checked;
            if (CmbUnitId.Enabled==false)
            {
                CmbUnitId.SelectedIndex = -1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit
            {
                Name = TxtName.Text,
                Note = TxtNote.Text,
                QTYTOPARENT = 1
            };
            if(CmbUnitId.Enabled==true)
            {
                decimal c;
                if (! decimal.TryParse(TxtQty.Text.ToString(), out c) || decimal.TryParse(TxtQuntityFormBig.Text.ToString(),out c))
                {
                    MessageBox.Show("الكمية لاتكون غير أرقام");
                    TxtQty.Focus();
                    return;
                }
                if (decimal.Parse(TxtQuntityFormBig.Text.ToString()) <= 1)
                {
                    MessageBox.Show("الكمية للوحدة الأكبر لابد ان تكون أكبر من الواحد "); 
                    return;
                }
                unit.Qty = decimal.Parse(TxtQty.Text.ToString());
                unit.UnitId = int.Parse(CmbUnitId.SelectedValue.ToString());
                unit.QTYTOPARENT = decimal.Parse(TxtQuntityFormBig.Text.ToString());
            }
           if(validation.validateUnit(unit))
            {
                unitEndPoint.Save(unit);
                var output = unitEndPoint.GetByName(unit.Name);
                unitDisplays.Add(mapper.Map<UnitDisplay>(unit));
                count = unitDisplays.Count - 1;
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
            Unit unit = new Unit
            {
                Id=int.Parse(TxtId.Text.ToString()),
                Name = TxtName.Text,
                Note = TxtNote.Text,
            };
            if (checkBox1.Checked)
            {
                decimal c;
                if (!decimal.TryParse(TxtQty.Text.ToString(), out c))
                {
                    MessageBox.Show("الكمية لاتكون غير أرقام");
                    TxtQty.Focus();
                    return;
                }
                unit.Qty = decimal.Parse(TxtQty.Text.ToString());
                unit.UnitId = int.Parse(CmbUnitId.SelectedValue.ToString());
            }
            if (validation.validateUnit(unit))
            {
                unitEndPoint.Update(unit);
                var output = unitEndPoint.GetByName(unit.Name);
                unitDisplays.RemoveAt(count);
                unitDisplays.Add(mapper.Map<UnitDisplay>(unit));
                count = unitDisplays.Count - 1;
                navigation(count);
                MessageBox.Show("تم الحفظ  التغير بنجاح");
            }
            else
            {
                MessageBox.Show(validation.massege);
            }
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit
            {
                Id = unitDisplays[count].Id,
                Name = unitDisplays[count].Name,
                Note = unitDisplays[count].Note,
                Qty = unitDisplays[count].Qty
            };
            unitEndPoint.Delete(unit);
            unitDisplays.RemoveAt(count);
            MessageBox.Show("تم الحذف بنجاح");
            count = unitDisplays.Count - 1;
            navigation(count);
        }

        private void TxtQuntityFormBig_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation.validateText(sender, e);
        }
    }
}

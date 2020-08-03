using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System.Windows.Forms;

namespace StockUI.Libarary.BL
{
    public class Validation
    {
        public string massege;
        private readonly IStockEndPoint stockEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IKindEndPoint kindEndPoint;
        private readonly ItemEndPoint itemEndPoint;

        public Validation(IStockEndPoint stockEndPoint
            , IUnitEndPoint unitEndPoint, IDepartmentEndPoint departmentEndPoint
            , IKindEndPoint kindEndPoint, ItemEndPoint itemEndPoint)
        {
            this.stockEndPoint = stockEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.kindEndPoint = kindEndPoint;
            this.itemEndPoint = itemEndPoint;
        }
        private bool validateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            if (name == " ")
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            return true;
        }
        public bool validatestock(Stock stock)
        {
            if (!validateName(stock.Name))
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            var output = stockEndPoint.GetByName(stock.Name);
            if (output != null && stock.Id != output.Id)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        public bool validateKind(Kind kind)
        {
            if (!validateName(kind.Name))
            {
                massege = "لايمكن ترك اسم المخزن فارغا";
                return false;
            }
            var output = kindEndPoint.GetByName(kind.Name);
            if (output != null && kind.Id != output.Id)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        public bool validatedepartment(department department)
        {
            if (!validateName(department.Name))
            {
                massege = "لايمكن ترك اسم النوع فارغا";
                return false;
            }
            var output = departmentEndPoint.GetByName(department.Name);
            if (output != null && department.Id != output.Id)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        public bool validateUnit(Unit unit)
        {
            if (!validateName(unit.Name))
            {
                massege = "لايمكن ترك اسم النوع فارغا";
                return false;
            }
            var output = unitEndPoint.GetByName(unit.Name);
            if (output != null && unit.Id != output.Id)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        public bool validateItem(Item item)
        {

            if (!validateName(item.Name))
            {
                massege = "لايمكن ترك اسم الصنف فارغا";
                return false;
            }
            var output = itemEndPoint.GetByName(item.Name);
            if (output != null && item.Id != output.Id)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        ///<summary>
        ///This validation for textbox number only and one point decimal
        /// sender and e paramter 
        ///</summary>
        public void validateText(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        ///<summary>
        ///This validation for textbox number only 
        /// sender and e paramter 
        ///</summary>
        public void validateText(object sender, KeyPressEventArgs e,int i)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

using StockSystem.Libarary.BL;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.BL
{
   public class Validation
    {
        public string massege;
        private readonly IStockEndPoint stockEndPoint;
        private readonly IUnitEndPoint unitEndPoint;
        private readonly IDepartmentEndPoint departmentEndPoint;
        private readonly IKindEndPoint kindEndPoint;

        public Validation(IStockEndPoint stockEndPoint,IUnitEndPoint unitEndPoint,IDepartmentEndPoint departmentEndPoint,IKindEndPoint kindEndPoint)
        {
            this.stockEndPoint = stockEndPoint;
            this.unitEndPoint = unitEndPoint;
            this.departmentEndPoint = departmentEndPoint;
            this.kindEndPoint = kindEndPoint;
        }
        private bool validateName(string name )
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
            if (output !=null)
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
            if (output != null)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
        public bool validatedepartment( department department)
        {
            if (!validateName(department.Name))
            {
                massege = "لايمكن ترك اسم النوع فارغا";
                return false;
            }
            var output = departmentEndPoint.GetByName(department.Name);
            if (output != null)
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
            if (output != null)
            {
                massege = "الإسم موجود مسبقا يرجي التاكد من الاسم";
                return false;
            }
            massege = "";
            return true;
        }
    }
}

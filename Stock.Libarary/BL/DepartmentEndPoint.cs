
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class DepartmentEndPoint : Reposit<department>
    {
        private readonly ISqlDataAccess sql;

        public DepartmentEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override department Delete(department t)
        {
            //spDepartmentDelete
            throw new NotImplementedException();
        }

        public override List<department> GetAll()
        {
            //spDepartmentGetAll
            throw new NotImplementedException();
        }

        public override department GetByID(int id)
        {
            //spDepartmentGetById
            throw new NotImplementedException();
        }

        public override department Save(department t)
        {
            //spDepartmentInsert
            throw new NotImplementedException();
        }

        public override department Update(department t)
        {
            //spDepartmentUpdate
            throw new NotImplementedException();
        }
    }
}

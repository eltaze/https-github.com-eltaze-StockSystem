
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class KindEndPoint : Reposit<Kind>
    {
        private readonly ISqlDataAccess sql;

        public KindEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override Kind Delete(Kind t)
        {
            //spKindDelete
            throw new NotImplementedException();
        }

        public override List<Kind> GetAll()
        {
            //spKindGetAll
            throw new NotImplementedException();
        }

        public override Kind GetByID(int id)
        {
            //spKindGetById
            throw new NotImplementedException();
        }

        public override Kind Save(Kind t)
        {
            //spKindInsert
            throw new NotImplementedException();
        }

        public override Kind Update(Kind t)
        {
            //spKindUpdate
            throw new NotImplementedException();
        }
    }
}

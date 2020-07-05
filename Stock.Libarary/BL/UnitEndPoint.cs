
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class UnitEndPoint : Reposit<Unit>
    {
        private readonly ISqlDataAccess sql;

        public UnitEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override Unit Delete(Unit t)
        {
            //spUnitDelete
            throw new NotImplementedException();
        }

        public override List<Unit> GetAll()
        {
            //spUnitGetAll
            throw new NotImplementedException();
        }

        public override Unit GetByID(int id)
        {
            //spUnitGetById
            throw new NotImplementedException();
        }

        public override Unit Save(Unit t)
        {
            //spUnitInsert
            throw new NotImplementedException();
        }

        public override Unit Update(Unit t)
        {
            //spUnitUpdate
            throw new NotImplementedException();
        }
    }
}

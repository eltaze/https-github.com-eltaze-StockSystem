
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class UnitEndPoint : Reposit<Unit>, IUnitEndPoint
    {
        private readonly ISqlDataAccess sql;

        public UnitEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override void Delete(Unit t)
        {
            //spUnitDelete
            try
            {
                sql.Execute<Unit, dynamic>("spUnitDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override List<Unit> GetAll()
        {
            //spUnitGetAll
            try
            {
                var output = sql.ReadingData<Unit, dynamic>("spUnitGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override Unit GetByID(int id)
        {
            //spUnitGetById
            try
            {
                var output = sql.ReadingData<Unit, dynamic>("spUnitGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override void Save(Unit t)
        {
            //spUnitInsert
            try
            {
                sql.Execute<Unit, dynamic>("spUnitInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override Unit Update(Unit t)
        {
            //spUnitUpdate
            try
            {
                sql.Execute<Unit, dynamic>("spUnitUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Unit GetByName(string Name)
        {
            //spUnitGetByName
            try
            {
                var output = sql.ReadingData<Unit, dynamic>("spUnitGetByName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

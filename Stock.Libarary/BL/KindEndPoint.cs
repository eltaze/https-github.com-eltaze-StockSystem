
using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class KindEndPoint : Reposit<Kind>, IKindEndPoint
    {
        private readonly ISqlDataAccess sql;

        public KindEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override void Delete(Kind t)
        {
            //spKindDelete
            try
            {
                sql.Execute<Kind, dynamic>("spKindDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override List<Kind> GetAll()
        {
            //spKindGetAll
            try
            {
                var output = sql.ReadingData<Kind, dynamic>("spKindGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Kind GetByID(int id)
        {
            //spKindGetById
            try
            {
                var output = sql.ReadingData<Kind, dynamic>("spKindGetAll", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override void Save(Kind t)
        {
            //spKindInsert
            try
            {
                sql.Execute<Kind, dynamic>("spKindInsert", new {Name=t.Name,Note=t.Note });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Kind Update(Kind t)
        {
            //spKindUpdate
            try
            {
                sql.Execute<Kind, dynamic>("spKindUpdate", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override Kind GetByName(string Name)
        {
            //spKindGetByName
            try
            {
                var output = sql.ReadingData<Kind, dynamic>("spKindGetByName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

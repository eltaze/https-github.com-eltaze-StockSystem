using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class DepartmentEndPoint : Reposit<department>, IDepartmentEndPoint
    {
        private readonly ISqlDataAccess sql;

        public DepartmentEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public override void Delete(department t)
        {
            //spDepartmentDelete
            try
            {
                sql.Execute<department, dynamic>("spDepartmentDelete", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override List<department> GetAll()
        {
            //spDepartmentGetAll
            try
            {
                var output = sql.ReadingData<department, dynamic>("spDepartmentGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override department GetByID(int id)
        {
            //spDepartmentGetById
            try
            {
                var output = sql.ReadingData<department, dynamic>("spDepartmentGetById", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override void Save(department t)
        {
            //spDepartmentInsert
            try
            {
                sql.Execute<department, dynamic>("spDepartmentInsert", t);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override department Update(department t)
        {
            //spDepartmentUpdate
            try
            {
                sql.Execute<department, dynamic>("spDepartmentGetById", t);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public override department GetByName(string Name)
        {
            //spDepartmentGetByName
            try
            {
                var output = sql.ReadingData<department, dynamic>("spDepartmentGetByName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

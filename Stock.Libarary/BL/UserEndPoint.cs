using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockSystem.Libarary.BL
{
    public class UserEndPoint : IUserEndPoint
    {
        private readonly ISqlDataAccess sql;

        public UserEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public void Delete(User t)
        {
            //[spUserDelete]
            try
            {
                sql.Execute<User, dynamic>("spUserDelete", new { id=t.Id,name=t.Name,password=t.Password });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<User> GetAll()
        {
            //[spUserGetAll]
            try
            {
                var output = sql.ReadingData<User, dynamic>("spUserGetAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public User GetByID(int id)
        {
            try
            {
                var output = sql.ReadingData<User, dynamic>("spUserGetId", new { id }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public User GetByName(string Name)
        {
            //[spUserGetName]
            try
            {
                var output = sql.ReadingData<User, dynamic>("spUserGetName", new { Name }).FirstOrDefault();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Save(User t)
        {
            //[spUserInsert]
            try
            {
                sql.Execute<User, dynamic>("spUserInsert", new { id=t.Id,name=t.Name,password=t.Password });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public User Update(User t)
        {
            //[spUserUpdate]
            try
            {
                sql.Execute<User, dynamic>("spUserUpdate", new { id =t.Id,name = t.Name,password=t.Password});
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

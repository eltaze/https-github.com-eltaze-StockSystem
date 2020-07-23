using StockSystem.Libarary.DataBase;
using StockSystem.Libarary.Interfaces;
using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSystem.Libarary.BL
{
    public class UserRightEndPoint : IUserRightEndPoint
    {
        private readonly ISqlDataAccess sql;

        public UserRightEndPoint(ISqlDataAccess sql)
        {
            this.sql = sql;
        }
        public User GetRight(int id)
        {
            try
            {
                //[spUserRights]
                var x = sql.ReadingData<User, dynamic>("spUserRights", new { id }).FirstOrDefault();
                var output = sql.ReadingData<Right, dynamic>("", new { id });
                x.Rights = output;
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<Right> GetRights()
        {
            try
            {
                //[[spGetRightAll]]
                var output = sql.ReadingData<Right, dynamic>("spGetRightAll", new { });
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Right GetUserPerRight(Right t)
        {
            try
            {
                //[spRightByUser]
                var output = sql.ReadingData<User, dynamic>("spRightByUser", new { t.Id });
                t.Users = output;
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

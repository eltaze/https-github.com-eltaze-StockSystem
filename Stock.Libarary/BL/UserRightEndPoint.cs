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
        /// <summary>
        /// This user must have one right to remove per time (only zone 0 active
        /// Rights[0].Id that is it
        /// </summary>
        /// <param name="t"></param>
        public void DeleteRight(User t)
        {
            //spRightByUserDelete
            try
            {
                sql.Execute<User, dynamic>("spRightByUserDelete", new { userid = t.Id, RightId = t.Rights[0].Id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void updateRight(User t)
        {
            //spRightByUserupdate
            try
            {
                sql.Execute<User, dynamic>("spRightByUserupdate", new
                {
                    userid = t.Id, RightId = t.Rights[0].Id ,
                    Read = t.Rights[0].Read, Edit = t.Rights[0].Edit , Delete = t.Rights[0].Delete});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void insertUserRight(User t)
        {
            //spRightByUserInsert
            try
            {
                sql.Execute<User, dynamic>("spRightByUserInsert", new
                {
                    userid = t.Id,
                    RightId = t.Rights[0].Id,
                    Read = t.Rights[0].Read,
                    Edit = t.Rights[0].Edit,
                    Delete = t.Rights[0].Delete
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public Right SelectUserRight(int userid,int rightid)
        {
            //spRightByUserInsert
            try
            {
                var x = sql.ReadingData<Right, dynamic>("spRightByUserselect", new { userid, rightid }).FirstOrDefault();
                return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public User GetRight(int id)
        {
            try
            {
                //[spUserGetId]
                //[spUserRights]
                var x = sql.ReadingData<User, dynamic>("spUserGetId", new { id }).FirstOrDefault();
               if(x == null)
                {
                    return x;
                }
                var output = sql.ReadingData<Right, dynamic>("spUserRights", new { id });
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

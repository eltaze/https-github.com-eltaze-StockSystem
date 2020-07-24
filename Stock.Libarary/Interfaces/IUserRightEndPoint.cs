using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IUserRightEndPoint
    {
        User GetRight(int id);
        List<Right> GetRights();
        Right GetUserPerRight(Right t);
        /// <summary>
        /// This user must have one right to remove per time (only zone 0 active
        /// Rights[0].Id that is it
        /// </summary>
        /// <param name="t"></param>
        void insertUserRight(User t);
        /// <summary>
        /// This user must have one right to remove per time (only zone 0 active
        /// Rights[0].Id that is it
        /// </summary>
        /// <param name="t"></param>
        void updateRight(User t);
        /// <summary>
        /// This user must have one right to remove per time (only zone 0 active
        /// Rights[0].Id that is it
        /// </summary>
        /// <param name="t"></param>
        void DeleteRight(User t);
        Right SelectUserRight(int userid, int rightid);
    }
}
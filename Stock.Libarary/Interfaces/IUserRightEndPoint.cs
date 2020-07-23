using StockSystem.Libarary.Model;
using System.Collections.Generic;

namespace StockSystem.Libarary.Interfaces
{
    public interface IUserRightEndPoint
    {
        User GetRight(int id);
        List<Right> GetRights();
        Right GetUserPerRight(Right t);
    }
}
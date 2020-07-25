using StockSystem.Libarary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockUI.Libarary.BL
{
   public class UserValidation
    {
        public User user { get; set; }

        public bool validateForm(string Name)
        {
            var x = user.Rights.FindIndex(b => b.Name == Name);
            if (x ==-1)
            {
                return false;
            }
            return true;
        }
        public bool validateEdit(string Name)
        {
            var x = user.Rights.FindIndex(b => b.Name == Name);
            if (user.Rights[x].Edit == true)
            {
                return true;
            }
            return false;
        }
        public bool validateDelete(string Name)
        {
            var x = user.Rights.FindIndex(b => b.Name == Name);
            if (user.Rights[x].Edit == true)
            {
                return true;
            }
            return false;
        }
    }
}

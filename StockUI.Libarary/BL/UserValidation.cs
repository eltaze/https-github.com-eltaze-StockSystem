using StockSystem.Libarary.Model;

namespace StockUI.Libarary.BL
{
    public class UserValidation
    {
        public User user { get; set; }

        public bool validateForm(string Name)
        {
            var x = user?.Rights?.FindIndex(b => b.Name == Name);
            if (x ==-1)
            {
                return false;
            }
            return true;
        }
        public bool validateEdit(string Name)
        {
            var x = user.Rights.FindIndex(b => b.Name == Name);
            if (x <0)
            {
                return false;
            }
            if (user.Rights[x]?.Edit == true)
            {
                return true;
            }
            return false;
        }
        public bool validateDelete(string Name)
        {
            var x = user.Rights.FindIndex(b => b.Name == Name);
            if (x < 0)
            {
                return false;
            }
            if (user.Rights[x].Edit == true)
            {
                return true;
            }
            return false;
        }
    }
}

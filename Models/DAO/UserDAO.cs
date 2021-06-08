using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entity;
namespace Models.DAO
{
    public class UserDAO
    {
        DBContext db = null;
        public UserDAO()
        {
            db = new DBContext();
        }
        public int Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserID;
        }

    }
}

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
        public User getUserById(int id)
        {
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            return user;
        }
        public int changeInformation(User user)
        {
            int id = user.UserID;
            var result = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if(result != null)
            {
                result.Fullname = user.Fullname;
                result.Password = user.Password;
                result.Phone = user.Phone;
                return 1;
            }
            return 0;
        }
        public List<User> getListUser()
        {
            return db.Users.ToList();
        }
        public User Login(string email , string password)
        {
            var user = db.Users.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            if(user != null)
            {
                return user;
            }
            return null;
        }

    }
}

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
            User result = db.Users.Where(m => m.Email == user.Email).FirstOrDefault();
            if (result == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.UserID;
            }
            else
            {
                return 0;
            }
        }
        public User getUserById(int id)
        {
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            return user;
        }
        public void changeInformation(User user)
        {
            int id = user.UserID;
            var result = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if (result != null)
            {
                result.Fullname = user.Fullname;
                result.Password = user.Password;
                result.Phone = user.Phone;
                db.SaveChanges();
            }

        }
        public void Status(int id)
        {
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if (user != null)
            {
                if (user.Status != 1)
                {
                    user.Status = 1;
                    db.SaveChanges();
                }
                else
                {
                    user.Status = 0;
                    db.SaveChanges();
                }
            }
        }
        public int Delete(int id)
        {
            if (id == 1)
            {
                return 0;
            }
            User user = db.Users.Where(m => m.UserID == id).FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public List<User> getListUser()
        {
            return db.Users.ToList();
        }
        public User Login(string email, string password)
        {
            var user = db.Users.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public void UploadAvatar(User user)
        {
            var user_id = user.UserID;
            var result = db.Users.Where(m => m.UserID == user_id).FirstOrDefault();
            result.Avatar = user.Avatar;
            db.SaveChanges();
        }
    }
}

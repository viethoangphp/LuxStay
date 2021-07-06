using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
using Models.Entity;

namespace LuxStay.Areas.Admin.Helper
{
    public class UserHelper
    {
        protected UserDAO dao = new UserDAO();
        public List<UserModel> getListUser()
        {
            var models = dao.getListUser();
            List<UserModel> listUser = new List<UserModel>();
            foreach(var item in models)
            {
                UserModel user = new UserModel();
                user.id = item.UserID;
                user.fullname = item.Fullname;
                user.email = item.Email;
                user.phone = item.Phone;
                user.status = (int)item.Status;
                user.avatar = item.Avatar;
                listUser.Add(user);
            }
            return listUser;
        }
        public UserModel getUserById(int id)
        {
            UserModel user = new UserModel();
            User model = dao.getUserById(id);
            if (model != null)
            {
                user.id = model.UserID;
                user.fullname = model.Fullname;
                user.phone = model.Phone;
                user.email = model.Email;
                user.avatar = model.Avatar;
                user.status = (int)model.Status;
                return user;
            }
            return null;
        }
        public int Insert(UserModel model)
        {
            User user = new User();
            user.Fullname = model.fullname;
            user.Email = model.email;
            user.Password = model.password;
            user.Phone = model.phone;
            user.Status = 0;
            var id = dao.Insert(user);
            return id;
        }
    }
}
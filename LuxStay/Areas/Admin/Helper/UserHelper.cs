using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
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
                user.avatar = item.Avatar;
                listUser.Add(user);
            }
            return listUser;
        }
    }
}
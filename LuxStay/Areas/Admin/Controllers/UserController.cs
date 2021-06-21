using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Data;
using Models.Entity;
using LuxStay.Areas.Admin.Helper;
namespace LuxStay.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        protected UserDAO dao = new UserDAO();

        public ActionResult Index()
        {
            List<User> listUser = new List<User>();
            listUser = dao.getListUser();
            return View(listUser);
        }
        [HttpPost]
        public JsonResult Add(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.password == null || model.password.Length < 6)
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }    
                User user = new User();
                user.Fullname = model.fullname;
                user.Email = model.email;
                user.Password = model.password;
                user.Phone = model.phone;
                var id = dao.Insert(user);
                if (id == 0)
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<UserModel> list = new UserHelper().getListUser();
                    return Json(list, JsonRequestBehavior.AllowGet);
                }

            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult View(int id)
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
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Delete(int userID)
        {
            int id = (int)Session["USER_ID"];
            if (id == userID)
            {
                return Json("duplicate", JsonRequestBehavior.AllowGet);
            }
            else
            {
                int result = dao.Delete(userID);
                if(result == 1)
                {
                    List<UserModel> list = new UserHelper().getListUser();
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public JsonResult Update(UserModel user)
        {
            User model = dao.getUserById(user.id);
            if(ModelState.IsValid)
            {
                model.Fullname = user.fullname;
                model.Phone = user.phone;
                model.Email = user.email;
                dao.changeInformation(model);
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

    }
}
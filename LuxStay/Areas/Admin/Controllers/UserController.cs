using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Data;
using Models.Entity;

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
            if(ModelState.IsValid)
            {
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
                    return Json(id, JsonRequestBehavior.AllowGet);
                }
                
            }    
            return Json("false", JsonRequestBehavior.AllowGet);
        }
    }
}
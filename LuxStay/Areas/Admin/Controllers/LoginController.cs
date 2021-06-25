using LuxStay.Areas.Admin.Data;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        protected UserDAO userDAO = new UserDAO();
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
       
        public JsonResult isLogin(AdminLogin login)
        {
            if (ModelState.IsValid)
            {
                var result = userDAO.Login(login.email, login.password);
                if (result !=null)
                {
                    Session.Add("USER_ID", result.UserID);
                    userDAO.Status(result.UserID);
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    
                    return Json("false", JsonRequestBehavior.AllowGet);
                }

            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            int id = (int)Session["USER_ID"];
            userDAO.Status(id);
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}
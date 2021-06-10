using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        protected int user_id;
        protected User user;
        public ActionResult Index()
        {
            user_id = (int)Session["USER_ID"];
            user = new UserDAO().getUserById(user_id);
            ViewBag.user = user;
            return View();
        }
        public JsonResult Change(InformationUser info)
        {
            user_id = (int)Session["USER_ID"];
            user = new UserDAO().getUserById(user_id);
            return Json("true", JsonRequestBehavior.AllowGet);

        }
    }
}
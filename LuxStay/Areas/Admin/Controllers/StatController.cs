using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Helper;
using System.IO;

namespace LuxStay.Areas.Admin.Controllers
{
    public class StatController : BaseController
    {
        StatHelper helper = new StatHelper();
        // GET: Admin/Stat
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Value(int length)
        {
            return Json(helper.totalValue(length),JsonRequestBehavior.AllowGet);
        }
    }
}
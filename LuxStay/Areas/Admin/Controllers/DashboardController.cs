using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        DashboardHelper helper = new DashboardHelper();
        public ActionResult Index()
        {
            return View(helper.getStat());
        }
        //Status: (0: Not Paid Yet) - (1: Already paid) - (-1: Cancelled)
        [HttpPost]
        public JsonResult StatByMonth()
        {
            return Json(helper.monthStat(), JsonRequestBehavior.AllowGet);
        }
    }
}
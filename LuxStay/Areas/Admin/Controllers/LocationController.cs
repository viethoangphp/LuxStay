using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        // GET: Admin/Location
        public ActionResult Index()
        {
            return View();
        }
    }
}
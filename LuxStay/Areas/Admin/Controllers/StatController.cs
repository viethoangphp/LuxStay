using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using LuxStay.Areas.Admin.Helper;
using System.IO;

namespace LuxStay.Areas.Admin.Controllers
{
    public class StatController : Controller
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
            StringWriter sw = new StringWriter();
            JsonWriter jw = new JsonTextWriter(sw);
            new JsonSerializer().Serialize(jw, helper.totalValue(length));
            string JSON = sw.ToString();
            return Json(JSON, JsonRequestBehavior.AllowGet);
        }
    }
}
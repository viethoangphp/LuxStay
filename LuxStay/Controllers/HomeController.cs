using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoctionParial()
        {
            var list = new LocationHeper().getListAll();
            return PartialView(list);
        }
        public ActionResult Location(int id)
        {
            ViewBag.Location = new LocationHeper().getById(id);
            // get List Room by location ID;
            var list = new RoomHepler().getListRoomByLocationId(id);
            return View(list);
        }
    }
}
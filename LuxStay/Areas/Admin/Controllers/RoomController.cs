using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Admin/Room
        LocationHeper heper = new LocationHeper();
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Location()
        {
            List<LocationModel> list = heper.getListAll();
            return PartialView(list);
        }
        
        public ActionResult Category()
        {
            List<CategoryModel> list = new CategoryHelper().getListAll();
            return PartialView(list);
        }
        public ActionResult Utility()
        {
            List<UtilityModel> list = new UtilityHelper().getListAll();
            return PartialView(list);
        }
    }
}
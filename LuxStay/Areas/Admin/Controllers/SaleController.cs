using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
namespace LuxStay.Areas.Admin.Controllers
{
    public class SaleController : Controller
    {
        // GET: Admin/Sale
        public ActionResult Index()
        {
            List<SaleModel> list = new SaleHeper().getListAll();
            return View(list);
        }
    }
}
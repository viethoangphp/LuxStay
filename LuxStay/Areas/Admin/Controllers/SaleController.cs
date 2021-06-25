using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Helper;
using Models.DAO;
namespace LuxStay.Areas.Admin.Controllers
{
    public class SaleController : BaseController
    {
        // GET: Admin/Sale
        SaleDAO dao = new SaleDAO();
        public ActionResult Index()
        {
            var list = new SaleHeper().getListAll();
            return View(list);
        }
    }
}
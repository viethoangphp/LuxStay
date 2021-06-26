using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using Models.DAO;
using Models.Entity;
namespace LuxStay.Areas.Admin.Controllers
{
    public class SaleController : Controller
    {
        // GET: Admin/Sale
        SaleHeper sale = new SaleHeper();
        public ActionResult Index()
        {
            var list = sale.getListAll();
            return View(list);
        }
        public JsonResult Add(SaleModel model)
        {
            if(ModelState.IsValid)
            {
                int result = sale.Insert(model);
                var list = sale.getListAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            int result = sale.Delete(id);
            if(result == 1)
            {
                var list = sale.getListAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
           return Json("false", JsonRequestBehavior.AllowGet);
        }
        public JsonResult View(int id)
        {
            SaleModel result = sale.getById(id);
            if (result != null) return Json(result, JsonRequestBehavior.AllowGet);
            return Json("false", JsonRequestBehavior.AllowGet);
        }
    }
}
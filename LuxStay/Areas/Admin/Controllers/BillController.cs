using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class BillController : BaseController
    {
        // GET: Admin/Bill
        BillHelper helper = new BillHelper();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadData()
        {
            return Json(helper.getListBill(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Get(int billid)
        {
            return Json(helper.getBill(billid),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetByCus(int id)
        {
            return Json(helper.getListBill(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ConfirmBill(int billid)
        {
            return Json(helper.confirmBill(billid,(int)Session["USER_ID"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Filter()
        {
            return Json("test", JsonRequestBehavior.AllowGet);
        }
    }
}
using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        ServiceHelper helper = new ServiceHelper();
        public ActionResult Index()
        {
            return View(helper.getListAll());
        }
        public JsonResult LoadData()
        {
            List<ServiceView> list = new ServiceHelper().getListAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get(int id)
        {
            ServiceView utl = new ServiceHelper().getUtility(id);
            if (utl == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            if(utl.status.Equals("Hiển thị"))
            {
                utl.status = "1";
            }
            else
            {
                utl.status = "0";
            }
            return Json(utl, JsonRequestBehavior.AllowGet);
        }

        //Thêm tiện ích
        [HttpPost]
        public JsonResult Add(ServiceView data)
        {
            if (ModelState.IsValid)
            {
                if (helper.AddUtility(data) == 0)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //Xóa tiện ích
        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (helper.DeleteUtility(id) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //Sửa tiện ích
        [HttpPost]
        public JsonResult Edit(ServiceView data)
        {
            if (ModelState.IsValid)
            {
                if (helper.EditUtility(data) == 1)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
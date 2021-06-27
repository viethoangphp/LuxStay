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
    public class ServiceController : Controller
    {
        protected ServiceDAO dao = new ServiceDAO();
        public ActionResult Index()
        {
            
            return View(dao.getListAll());
        }
        public JsonResult LoadData()
        {
            List<ServiceView> list = new ServiceHelper().getListUtility();
            var data = Json(list, JsonRequestBehavior.AllowGet);
            return data;
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
                int st = Convert.ToInt32(data.status);
                Utility utl = new Utility()
                {
                    Name = data.name,
                    ParentID = data.parentid,
                    Icon = data.icon,
                    Status = st
                };
                int id = dao.Add(utl);
                if (id == 0)
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(LoadData(), JsonRequestBehavior.AllowGet);
                }

            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        //Xóa tiện ích
        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (dao.Delete(id) == 1)
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
            int st = Convert.ToInt32(data.status);
            Utility utl = new Utility()
            {
                UtilityID = data.id,
                Name = data.name,
                ParentID = data.parentid,
                Icon = data.icon,
                Status = st
            };
            if (dao.Edit(utl) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
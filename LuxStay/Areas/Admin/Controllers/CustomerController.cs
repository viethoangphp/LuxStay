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
    public class CustomerController : BaseController
    {
        CustomerHelper helper = new CustomerHelper();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadData()
        {
            List<CustomerView> list = helper.getListCustomer();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get(int id)
        {
            CustomerView cus = helper.getCustomer(id);
            if (cus == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            if (cus.gender == "Nam")
            {
                cus.gender = "1";
            }
            else
            {
                cus.gender = "0";
            }
            return Json(cus,JsonRequestBehavior.AllowGet);
        }
        //Thông tin khách hàng

        //Thêm khách hàng
        [HttpPost]
        public JsonResult Add(CustomerView data)
        {
            if(ModelState.IsValid)
            {
                if(helper.AddCustomer(data) == 0)
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

        //Xóa khách hàng
        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (helper.DeleteCustomer(id) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //Sửa khách hàng
        [HttpPost]
        public JsonResult Edit(CustomerView data)
        {
            if (ModelState.IsValid)
            {
                if(helper.EditCustomer(data) == 1)
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
        //----------------------------------------------------------------------------------------
    }
}
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
        // GET: Admin/Customer
        protected CustomerDAO dao = new CustomerDAO();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadData()
        {
            List<CustomerView> list = new CustomerHelper().getListCustomer();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get(int id)
        {
            CustomerView cus = new CustomerHelper().getCustomer(id);
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
                int gd = 0;
                if(data.gender == "1")
                {
                    gd = 1;
                }
                Customer cus = new Customer()
                {
                    FullName = data.fullname,
                    Email = data.email,
                    Phone = data.phone,
                    Gender = gd,
                    Address = data.address
                };
                int id = dao.Add(cus);
                if(id == 0)
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

        //Xóa khách hàng
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

        //Sửa khách hàng
        [HttpPost]
        public JsonResult Edit(CustomerView data)
        {
            if (ModelState.IsValid)
            {
                int gd = 0;
                if (data.gender == "1")
                {
                    gd = 1;
                }
                Customer cus = new Customer()
                {
                    CustomerID = data.id,
                    FullName = data.fullname,
                    Email = data.email,
                    Address = data.address,
                    Phone = data.phone,
                    Gender = gd
                };
                if (dao.Edit(cus) == 1)
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
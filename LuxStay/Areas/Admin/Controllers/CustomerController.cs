using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        protected CustomerDAO dao = new CustomerDAO();
        public ActionResult Index()
        {
            CustomerDAO dao = new CustomerDAO();
            List<Customer> list = dao.getListAll();
            return View(list);
        }
        public JsonResult DataTable() 
        {
            CustomerDAO dao = new CustomerDAO();
            List<Customer> list = dao.getListAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //Thông tin khách hàng

        //Thêm khách hàng
        [HttpPost]
        public JsonResult Add(CustomerView data)
        {
            if(ModelState.IsValid)
            {
                Customer cus = new Customer()
                {
                    FullName = data.fullname,
                    Email = data.email,
                    Phone = data.phone,
                    Gender = data.gender,
                    Address = data.address
                };
                int id = dao.Add(cus);
                if(id == 0)
                {
                    return Json("false", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(id, JsonRequestBehavior.AllowGet);
                }
                
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        //Xóa khách hàng
        public ActionResult Delete()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (dao.Delete(id) == 1)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
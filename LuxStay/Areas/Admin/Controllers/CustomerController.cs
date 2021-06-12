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
        //Thông tin khách hàng

        //Thêm khách hàng
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            int gender = Convert.ToInt32(form.Get("inputGender"));
            Customer cus = new Customer()
            {
                FullName = form.Get("inputFullName"),
                Email = form.Get("inputEmail"),
                Phone = form.Get("inputPhone"),
                Gender = gender,
                Address = form.Get("inputAddress")
            };
            dao.Add(cus);
            return RedirectToAction("Index");
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
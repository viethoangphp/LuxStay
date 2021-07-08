using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using LuxStay.Models.Data;

namespace LuxStay.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        CustomerHelper helper = new CustomerHelper();
        public ActionResult Login()
        {
            if (Session["USER"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            if (ModelState.IsValid)
            {
                CustomerModel cus = helper.authCustomer(data.email, data.password);
                if (cus != null)
                {
                    Session["USER"] = cus;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Error"] = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    return View();
                }
            }
            ViewData["Error"] = "Dữ liệu gửi lên máy chủ không hợp lệ";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterModel data)
        {
            if (ModelState.IsValid)
            {
                if (data.password != data.confirmpassword)
                {
                    ViewData["Error"] = "Hai mật khẩu không khớp nhau";
                    return View(data);
                }
                int code = helper.AddCustomer(data);
                if (code == 1)
                {
                    TempData["Message"] = "Đăng ký thành công! Bạn đã có thể đăng nhập";
                    return RedirectToAction("Login", "Account");
                }
                else if(code == 2)
                {
                    ViewData["Error"] = "Email đã tồn tại! Vui lòng chọn email khác";
                    data.email = null;
                    return View(data);
                }
                ViewData["Error"] = "Đã có lỗi xảy ra! Vui lòng thử lại";
                return View();
            }
            ViewData["Error"] = "Dữ liệu gửi lên máy chủ không hợp lệ";
            return View();
        }
        public ActionResult Logout()
        {
            Session["USER"] = null;
            return RedirectToAction("Index", "Home"); 
        }
    }
}
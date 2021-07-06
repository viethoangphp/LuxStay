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

        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            if (ModelState.IsValid)
            {
                CustomerModel cus = helper.authCustomer(data.email, data.password);
                if (cus != null)
                {
                    Session["USER"] = cus;
                    return RedirectToAction("Index", "Home"); // Need Update -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
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

        public ActionResult Register(RegisterModel data)
        {
            if (ModelState.IsValid)
            {
                if (data.password != data.confirmpassword)
                {
                    ViewData["Error"] = "Password doesn't match";
                    return View();
                }
                if (helper.AddCustomer(data) == 1)
                {
                    TempData["Message"] = "Đăng ký thành công! Bạn đã có thể đăng nhập";
                    return RedirectToAction("Login", "Account");
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
            return RedirectToAction("Index", "Home"); // Need Update -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        }
    }
}
﻿using Models.DAO;
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
        public ActionResult Index()
        {
            CustomerDAO dao = new CustomerDAO();
            List<Customer> list = dao.getListAll();
            return View(list);
        }
    }
}
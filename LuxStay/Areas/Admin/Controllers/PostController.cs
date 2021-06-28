using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }
    }
}
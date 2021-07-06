using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        PostHelper helper = new PostHelper();
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }
        //GET ALL DATA
        public JsonResult LoadData()
        {
            return Json(helper.getListPost(),JsonRequestBehavior.AllowGet);
        }
        //GET 1 DATA
        public JsonResult Get(int id)
        {
            return Json(helper.getPost(id), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Add(PostModel model)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = model.avatarFile;
                file.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + file.FileName);
                model.postAvatar = "/Assets/Admin/dist/img/" + file.FileName;
                model.Create_by = (int)Session["USER_ID"];
                if (helper.AddPost(model) == 1)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        //Delete
        public JsonResult Delete(int id)
        {
            if(helper.DeletePost(id) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        //Edit
        [ValidateInput(false)]
        public JsonResult Edit(PostModel model)
        {
            if(model.avatarFile != null)
            {
                HttpPostedFileBase file = model.avatarFile;
                file.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + file.FileName);
                model.postAvatar = "/Assets/Admin/dist/img/" + file.FileName;
            }

            if (helper.EditPost(model) == 1)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
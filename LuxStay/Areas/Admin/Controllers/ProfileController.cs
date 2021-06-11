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
    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        protected int user_id;
        protected User user;
        protected UserDAO dao = new UserDAO();
        public ActionResult Index()
        {
            user_id = (int)Session["USER_ID"];
            user = new UserDAO().getUserById(user_id);
            ViewBag.user = user;
            return View();
        }
        [HttpPost]
        public JsonResult Change(InformationUser info)
        {
            user_id = (int)Session["USER_ID"];
            user = dao.getUserById(user_id);
            if(info.fullname != null && info.phone != null)
            {
                user.Fullname = info.fullname;
                user.Phone = info.phone;
                dao.changeInformation(user);
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult PasswordChange(PasswordUser password)
        {
            user_id = (int)Session["USER_ID"];
            user = dao.getUserById(user_id);
            if(password.passwordOld !=user.Password.Trim())
            {
                return Json("false-pass", JsonRequestBehavior.AllowGet);
            }else if(password.passwordNew == password.confirmPassword && password.passwordNew !=null && password.confirmPassword!=null)
            {
                user.Password = password.passwordNew;
                dao.changeInformation(user);
                return Json("true", JsonRequestBehavior.AllowGet);
            }    
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        public JsonResult Upload()
        {
            user_id = (int)Session["USER_ID"];
            user = dao.getUserById(user_id);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; 
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + fileName);
                user.Avatar = "/Assets/Admin/dist/img/" + fileName;
                dao.UploadAvatar(user);
            }
            return Json("Uploaded Success !");
        }

    }
}
using LuxStay.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Entity;
using System.IO;

namespace LuxStay.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        // GET: Admin/Location
        private LocationDAO dao = new LocationDAO();
        public ActionResult Index()
        {
            List<Location> list = dao.getListAll();
            return View(list);
        }
        [HttpPost]
        public JsonResult Add()
        {
            string LocationName = Request.Form["LocationName"];
            if(LocationName =="" || Request.Files.Count == 0 )
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }    
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; 
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                file.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + fileName);
                Location location = new Location();
                location.LocationName = LocationName;
                location.RoomNumber = 0;
                location.Status = 1;
                location.Avatar = "/Assets/Admin/dist/img/" + fileName;
                dao.Insert(location);
            }
            return Json(true,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = dao.Delete(id);
            if(result == 1)
                return Json("true", JsonRequestBehavior.AllowGet);
            return Json("false", JsonRequestBehavior.AllowGet);

        }
    }
}
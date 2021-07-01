using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entity;
using Models.DAO;
namespace LuxStay.Areas.Admin.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Admin/Room
        LocationHeper heper = new LocationHeper();
        public ActionResult Index()
        {
            List<RoomModel> list = new RoomHepler().getListAll();
            return View(list);
        }

        public ActionResult Location()
        {
            List<LocationModel> list = heper.getListAll();
            return PartialView(list);
        }

        public ActionResult Category()
        {
            List<CategoryModel> list = new CategoryHelper().getListAll();
            return PartialView(list);
        }
        public ActionResult Utility()
        {
            List<UtilityModel> list = new UtilityHelper().getListAll();
            return PartialView(list);
        }
        [ValidateInput(false)]
        public ActionResult Add(RoomModel model)
        {
            if (ModelState.IsValid)
            {
                // Lưu avatar
                HttpPostedFileBase file = model.avatarFile;
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + fileName);
                model.avatar = "/Assets/Admin/dist/img/" + fileName;
                int saveRoom = new RoomHepler().Insert(model);
                // Lưu Ảnh Silder 
                for (int i = 0; i < model.slider.Count; i++)
                {
                    if(model.slider[i] != null)
                    {
                        ImageDAO imageDAO = new ImageDAO();
                        Image image = new Image();
                        HttpPostedFileBase temp = model.slider[i];
                        string url = temp.FileName;
                        //To save file, use SaveAs method
                        temp.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + url);
                        image.Url = "/Assets/Admin/dist/img/" + url;
                        image.RoomID = saveRoom;
                        image.Status = 1;
                        image.Type = 1;
                        imageDAO.Insert(image);
                    }    
                    
                }
                // Lưu Utility 
                if(model.utility.Count > 0)
                {
                    for (int i = 0; i < model.utility.Count; i++)
                    {
                        UtilityDetailDAO utilityDAO = new UtilityDetailDAO();
                        UtilityDetail utilityDetail = new UtilityDetail();
                        utilityDetail.RoomID = saveRoom;
                        utilityDetail.UtilityID = model.utility[i];
                        utilityDetail.Status = 1;
                        utilityDAO.Insert(utilityDetail);
                    }
                }    
                return RedirectToAction("Index", "Room");
            }
            return RedirectToAction("Index", "Room");
        }
    }
}
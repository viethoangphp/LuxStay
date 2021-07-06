using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entity;
using Models.DAO;
using System.IO;

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
        public ActionResult Sale()
        {
            var list = new SaleHeper().getListSaled();
            return PartialView(list);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Add(RoomModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.avatarFile != null)
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
                        if (model.slider[i] != null)
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
                    if (model.utility != null)
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
                    var listRoom = new RoomHepler().getListAll();
                    return Json(listRoom, JsonRequestBehavior.AllowGet);
                }    
               
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            RoomHepler hepler = new RoomHepler();
            if(hepler.Delete(id) == 1)
            {
                var list = hepler.getListAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        public JsonResult View(int id)
        {
            RoomModel model = new RoomHepler().getRoomById(id);
            if(model != null)
            {
                return Json(model,JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Update(RoomModel model)
        {
            RoomHepler roomHepler = new RoomHepler();
            if(ModelState.IsValid)
            {
                RoomModel roomUpdate = roomHepler.getRoomById(model.id);
                if(model.avatarFile == null)
                {
                    model.avatar = roomUpdate.avatar;
                }
                else
                {
                    HttpPostedFileBase fileAvatar = model.avatarFile;
                    String avatarFileName = fileAvatar.FileName;
                    fileAvatar.SaveAs(Server.MapPath("~/Assets/Admin/dist/img/") + avatarFileName);
                    model.avatar = "/Assets/Admin/dist/img/" + avatarFileName;
                }
                model.status = "Enable";
                roomHepler.Update(model);
                var list = roomHepler.getListAll();
                return Json(list, JsonRequestBehavior.AllowGet);
            }    
            return Json("false",JsonRequestBehavior.AllowGet);
        }
    }
}
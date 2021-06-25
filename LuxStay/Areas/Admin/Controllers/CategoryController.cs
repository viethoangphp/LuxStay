using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Entity;

namespace LuxStay.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        CategoryDAO dao = new CategoryDAO();
        public ActionResult Index()
        {
            var list = dao.getListAll();
            return View(list);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = dao.Delete(id);
            if (result == 1)
                return Json("true", JsonRequestBehavior.AllowGet);
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Add(string Category_add)
        {
            if (Category_add == "")
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            else
            {
                RoomCategory category = new RoomCategory();
                category.CatName = Category_add;
                category.Status = 1;
                dao.Insert(category);
                return Json("true", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult View(int id)
        {
            RoomCategory model = dao.GetCategoryById(id);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }
        public JsonResult Update(RoomCategory model)
        {
            if(model.CatName == "")
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            else
            {
                dao.Update(model);
                return Json("true", JsonRequestBehavior.AllowGet);
            }    
        }
      
    }
}
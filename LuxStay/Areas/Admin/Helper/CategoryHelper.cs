using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Helper
{
    public class CategoryHelper
    {
        CategoryDAO dao = new CategoryDAO();
        public List<CategoryModel> getListAll()
        {
            List<CategoryModel> result = new List<CategoryModel>();
            List<RoomCategory> list = dao.getListAll();
            foreach(var item in list)
            {
                CategoryModel model = new CategoryModel();
                model.id = item.CatID;
                model.categoryName = item.CatName;
                model.status =(int)item.Status;
                result.Add(model);
            }
            return result;
        }
    }
}
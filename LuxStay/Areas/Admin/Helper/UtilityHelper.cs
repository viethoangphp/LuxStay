using LuxStay.Areas.Admin.Data;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Helper
{
    public class UtilityHelper
    {
        UtilityDAO dao = new UtilityDAO();
        public List<UtilityModel> getListAll()
        {
            var listUtility = dao.getListAll();
            List<UtilityModel> result = new List<UtilityModel>();
            foreach(var item in listUtility)
            {
                UtilityModel model = new UtilityModel();
                model.id = item.UtilityID;
                model.parentID = (int)item.ParentID;
                model.utilityName = item.Name;
                model.status = (int)item.Status;
                result.Add(model);
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;

namespace LuxStay.Areas.Admin.Helper
{
    public class LocationHeper
    {
        LocationDAO dao = new LocationDAO();
        public List<LocationModel> getListAll()
        {
            List<Location> list = dao.getListAll();
            List<LocationModel> result = new List<LocationModel>();
            foreach(var item in list)
            {
                LocationModel model = new LocationModel();
                model.id = item.LocationID;
                model.LocationName = item.LocationName;
                model.avatar = item.Avatar;
                model.Status = (int)item.Status;
                result.Add(model);
            }
            return result;
        }
    }
}
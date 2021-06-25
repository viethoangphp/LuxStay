using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Helper
{
    public class ServiceHelper
    {
        protected ServiceDAO dao = new ServiceDAO();
        public List<ServiceView> getListUtility()
        {
            var models = dao.getListAll();
            List<ServiceView> list = new List<ServiceView>();
            foreach (var item in models)
            {
                string st = "Hiển thị";
                if (item.Status == 0)
                {
                    st = "Ẩn";
                }
                Utility parent = dao.getUtility((int)item.ParentID);
                string pName = "";
                if(parent == null) { pName = "Gốc"; } else { pName = parent.Name; }
                ServiceView utl = new ServiceView()
                {
                    id = item.UtilityID,
                    name = item.Name,
                    parentid = (int)item.ParentID,
                    parentname = pName,
                    icon = item.Icon,
                    status = st
                };
                list.Add(utl);
            }
            return list;
        }
        public ServiceView getUtility(int id)
        {
            var models = dao.getUtility(id);
            string st = "Hiển thị";
            if (models.Status == 0)
            {
                st = "Ẩn";
            }
            string parent = dao.getUtility((int)models.ParentID).Name;
            ServiceView view = new ServiceView()
            {
                id = models.UtilityID,
                name = models.Name,
                parentid = (int)models.ParentID,
                parentname = parent,
                icon = models.Icon,
                status = st,
            };
            return view;
        }
    }
}
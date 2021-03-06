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
        public List<ServiceModel> getListAll()
        {
            var models = dao.getListAll();
            List<ServiceModel> list = new List<ServiceModel>();
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
                ServiceModel utl = new ServiceModel()
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
        public List<ServiceModel> getListAll(int parentID)
        {
            var models = dao.getListAll(parentID);
            List<ServiceModel> list = new List<ServiceModel>();
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
                ServiceModel utl = new ServiceModel()
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
        public ServiceModel getUtility(int id)
        {
            var models = dao.getUtility(id);
            string st = "Hiển thị";
            if (models.Status == 0)
            {
                st = "Ẩn";
            }
            Utility parent = dao.getUtility((int)models.ParentID);
            string pName = "";
            if (parent == null) { pName = "Gốc"; } else { pName = parent.Name; }
            ServiceModel view = new ServiceModel()
            {
                id = models.UtilityID,
                name = models.Name,
                parentid = (int)models.ParentID,
                parentname = pName,
                icon = models.Icon,
                status = st,
            };
            return view;
        }
        public int AddUtility(ServiceModel data)
        {
            int st = Convert.ToInt32(data.status);
            Utility utl = new Utility()
            {
                Name = data.name,
                ParentID = data.parentid,
                Icon = data.icon,
                Status = st
            };
            return dao.Add(utl);
        }
        public int DeleteUtility(int id)
        {
            return dao.Delete(id);
        }
        public int EditUtility(ServiceModel data)
        {
            int st = Convert.ToInt32(data.status);
            Utility utl = new Utility()
            {
                UtilityID = data.id,
                Name = data.name,
                ParentID = data.parentid,
                Icon = data.icon,
                Status = st
            };
            return dao.Edit(utl);
        }
    }
}
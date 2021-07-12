using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Models.DAO;

namespace LuxStay.Areas.Admin.Helper
{
    public class StatHelper
    {
        public List<dynamic> totalValue(int length)
        {
            //Length: month
            List<dynamic> list = new List<dynamic>();
            for (int i = 0; i < length; i++)
            {
                dynamic item = new ExpandoObject();
                item.labels = DateTime.Now.AddMonths(-i).ToString("MM/yyyy");
                DateTime check = DateTime.Now.AddMonths(-i);
                item.value = (int)new BillDAO().getListBill().Where(m => (m.Create_At.Value.Month == check.Month && m.Create_At.Value.Year == check.Year)).Sum(m => m.Total);
                list.Add(item);
            }
            list.Reverse();
            return list;
        }
    }
}
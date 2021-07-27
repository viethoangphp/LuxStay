using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;

namespace LuxStay.Areas.Admin.Helper
{
    public class StatHelper
    {
        public List<StatModel> totalValue(int length)
        {
            //Length: month
            List<StatModel> list = new List<StatModel>();
            for (int i = 0; i < length; i++)
            {
                DateTime check = DateTime.Now.AddMonths(-i);
                StatModel model = new StatModel()
                {
                    labels = DateTime.Now.AddMonths(-i).ToString("MM/yyyy"),
                    values = (int)new BillDAO().getListBill().Where(m => (m.Create_At.Value.Month == check.Month && m.Create_At.Value.Year == check.Year && m.Status == 1)).Sum(m => m.Total)
                };
                list.Add(model);
            }
            list.Reverse();
            return list;
        }
    }
}
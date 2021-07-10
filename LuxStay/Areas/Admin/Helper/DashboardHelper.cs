using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
using System.Dynamic;

namespace LuxStay.Areas.Admin.Helper
{
    public class DashboardHelper
    {
        public DashboardModel getStat()
        {
            DashboardModel data = new DashboardModel()
            {
                totalCustomer = new CustomerDAO().getListAll().Count,
                totalOrder = new BillDAO().getListBill().Count,
                totalValue = (int)new BillDAO().getListBill().Where(m=>m.Status == 1).Sum(p => p.Total)
            };
            return data;
        }
        public List<List<int>> monthStat()
        {
            List<List<int>> stat = new List<List<int>>();
            List<int> success = new List<int>();
            List<int> cancel = new List<int>();
            for (int i=1; i<=12; i++)
            {
                success.Add(new BillDAO().getListByMonth(i, 1).Count);
                cancel.Add(new BillDAO().getListByMonth(i, -1).Count);
            }
            stat.Add(success);
            stat.Add(cancel);
            return stat;
        }
    }
}
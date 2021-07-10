using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class DashboardModel
    {
        public int totalOrder { get; set; }
        public int totalValue { get; set; }
        public int totalCustomer { get; set; }
        public int totalVisit { get; set; }
    }
}
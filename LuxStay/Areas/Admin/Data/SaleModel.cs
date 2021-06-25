using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class SaleModel
    {
        public int id { set; get; }
        public int persent { set; get; }
        public string check_in { set; get; }
        public string check_out { set; get; }
        public int status { set; get; }
        public string create_at { set; get; }
    }
}
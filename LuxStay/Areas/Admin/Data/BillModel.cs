using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class BillModel
    {
        public int billId { set; get; }
        public int roomId { set; get;}
        public string create_at { set; get;}
        public string check_in { set; get;}
        public string check_out { set; get;}
        public int total { set; get;}
        public int confirm_by { set; get;}
        public int create_by { set; get;}
        public int adult { set; get;}
        public int kid { set; get; }
        public int baby { set; get; }
        public int status { set; get;}
    }
}
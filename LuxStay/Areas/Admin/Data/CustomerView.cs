using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class CustomerView
    {
        public string fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int gender { get; set; }
        public string address { get; set; }
    }
}
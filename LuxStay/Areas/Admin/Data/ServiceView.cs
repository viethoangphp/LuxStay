using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class ServiceView
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
        public string parentname { get; set; }
        public int price { get; set; }
        public string icon { get; set; }
        public string status { get; set; }
    }
}
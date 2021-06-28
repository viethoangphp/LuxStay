using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class UtilityModel
    {
        public int id { set; get;}
        public String utilityName { set; get; }
        public int parentID { set; get;}
        public int status { set; get;}
    }
}
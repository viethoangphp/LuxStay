using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class PasswordUser
    {
        public string passwordOld { set; get; }
        public string passwordNew { set; get; }
        public string confirmPassword { set; get;}
    }
}
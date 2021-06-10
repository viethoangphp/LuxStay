using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class InformationUser
    {
        [Required]
        public string fullname { set; get;}
        [Required]
        public string phone { set; get;}
    }
}
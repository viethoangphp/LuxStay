using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class UserModel
    {
        [Required]
        public string fullname { set; get; }
        [Required]
        [EmailAddress]
        public string email { set; get; }
        [Required]
        public string password { set; get; }
        public string avatar { set; get; }
        [Required]
        public string phone { set; get; }
    }
}
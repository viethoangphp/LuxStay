using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class AdminLogin
    {
        [Required(ErrorMessage ="Không Được Để Trống Trường Này")]
        [EmailAddress(ErrorMessage ="Email Không Đúng Định Dạng")]
        public string email { set; get; }
        [Required(ErrorMessage = "Không Được Để Trống Trường Này")]
        public string password { set; get;}

    }
}
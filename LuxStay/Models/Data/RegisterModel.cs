using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Models.Data
{
    public class RegisterModel
    {
        [Required]
        public string fullname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }
        [Required]
        [MinLength(8)]
        public string confirmpassword { get; set; }
        [Required]
        public string phone { get; set; }

        public string address { get; set; }

        public string gender { get; set; }
    }
}
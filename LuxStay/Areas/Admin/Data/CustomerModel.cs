using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class CustomerModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        
        public string address { get; set; }
    }
}
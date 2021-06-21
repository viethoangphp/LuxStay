using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class CustomerView
    {
        [Required]
        public string fullname { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        public int gender { get; set; }
        [Required]
        public string address { get; set; }
    }
}
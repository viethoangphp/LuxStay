﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class CustomerView
    {
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        public string gender { get; set; }
        [Required]
        public string address { get; set; }
    }
}
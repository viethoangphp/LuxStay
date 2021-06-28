using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class ServiceView
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int parentid { get; set; }
        public string parentname { get; set; }
        public string icon { get; set; }
        [Required]
        public string status { get; set; }
    }
}
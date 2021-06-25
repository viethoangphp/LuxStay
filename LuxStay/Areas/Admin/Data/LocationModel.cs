using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class LocationModel
    {
        [Required(ErrorMessage ="Bạn Không Được Để Trống Tên Khu Vực")]
        public String LocationName { set; get; }
        [Required(ErrorMessage = "Bạn Không Được Để Trống Ảnh Khu Vực")]
        public String avatar {set; get;} 
        public int Status { get; set;}

    }
}
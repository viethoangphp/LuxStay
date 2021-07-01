using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class RoomModel
    {
        public int id { set; get; }
        public int saleID { set; get; }
        [Required]
        public int locationID { set; get; }
        [Required]
        public int categoryID { set; get; }
        [Required]
        public string roomName { set; get; }
        [Required]
        public int area { set; get; }
        public String content { set; get; }
        [Required]
        public int bedRoom { set; get; }
        [Required]
        public int bathRoom { set; get; }
        [Required]
        public int bedNumber { set; get; }
        [Required]
        public int peopleMax{set; get;}
        [Required]
        public String Address { set; get; }
        public string roomCategory { set; get; }
        public string roomLocation { set; get; }
        [Required]
        public int price { set; get; }
        public String priceShow { set; get; }
        public int status { set; get; }
        public string avatar { set; get; }
        [Required]
        public HttpPostedFileBase avatarFile { set; get;}
        public List<HttpPostedFileBase> slider { set; get;}
        public List<int> utility { set; get;}
    }
}
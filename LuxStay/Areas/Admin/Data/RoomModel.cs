using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class RoomModel
    {
        public int id { set; get; }
        public string roomName { set; get; }
        public string roomCategory { set; get; }
        public string roomLocation { set; get; }
        public int price { set; get; }
        public int status { set; get; }
        public string avatar { set; get; }
    }
}
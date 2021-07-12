using LuxStay.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Models.Data
{
    public class Checkout
    {
        public int id { set; get; }
        public string checkin { set; get;}
        public string checkout { set; get; }
        public RoomModel room { set; get;}
        public int stayNumber { set; get;}
        public string total { set; get; }
    }
}
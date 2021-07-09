using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class BillModel
    {
        public int billid { get; set; }
        public string roomname { get; set; }
        public string datecreate { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
        public int total { get; set; }
        public string status { get; set; }
    }
}
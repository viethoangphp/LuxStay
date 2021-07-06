using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Controllers
{
    public class RoomsController : Controller
    {
        // GET: Rooms
        public ActionResult Index(int id)
        {
            RoomHepler roomHepler = new RoomHepler();
            RoomModel room = roomHepler.getRoomById(id);
            ViewBag.listRoom = roomHepler.getListRoomByLocationId(room.locationID);
            return View(room);
        }
    }
}
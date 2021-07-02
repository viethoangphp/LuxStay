using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class RoomDAO
    {
        DBContext db = new DBContext();
        public int Insert(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return room.RoomID;
        }
        public List<Room> getListAll()
        {
            return db.Rooms.Where(m=>m.Status == "Enable").ToList();
        }
        public int Delete(int id)
        {
            Room room = db.Rooms.Find(id);
            if(room != null)
            {
                room.Status = "Disable";
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public List<Room> getListRoomByLocationId(int locationId)
        {
            return db.Rooms.Where(m => m.Status == "Enable" && m.LocationID == locationId).ToList();
        }
    }
}

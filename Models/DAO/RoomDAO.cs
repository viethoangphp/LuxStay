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
            return db.Rooms.ToList();
        }
    }
}

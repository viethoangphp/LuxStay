using Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
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
            return db.Rooms.Where(m => m.Status == "Enable").ToList();
        }
        public int Delete(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                room.Status = "Disable";
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public List<Room> getListRoomByLocationId(int locationId, int count = 0)
        {
            if (count == 0)
            {
                return db.Rooms.Where(m => m.Status == "Enable" && m.LocationID == locationId).ToList();
            }
            return db.Rooms.Where(m => m.Status == "Enable" && m.LocationID == locationId).Take(count).ToList();
        }
        public void Update(Room room)
        {
            Room update = db.Rooms.Find(room.RoomID);
            if (update != null)
            {
                update.RoomName = room.RoomName;
                update.CatID = room.CatID;
                update.SaleID = room.SaleID;
                update.LocationID = room.LocationID;
                update.SaleID = room.SaleID;
                update.Area = room.Area;
                update.Price = room.Price;
                update.ContentRoom = room.ContentRoom;
                update.Avatar = room.Avatar;
                update.BedNumber = room.BedNumber;
                update.BedRoom = room.BedRoom;
                update.BathRoom = room.BathRoom;
                update.PeopleMax = room.PeopleMax;
                update.Status = room.Status;
                update.Address = room.Address;
                db.SaveChanges();
            }
        }
        public Room getRoomById(int id)
        {
            return db.Rooms.Find(id);
        }
        public IEnumerable<Room> getListPagination(int page, int pageSize)
        {
            return db.Rooms.OrderBy(m => m.RoomID).ToPagedList(page, pageSize);
        }
    }
}

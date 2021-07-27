using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LocationDAO
    {
        DBContext db = new DBContext();
        public int Insert(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location.LocationID;
        }
        public List<Location> getListAll()
        {
            var list = db.Locations.ToList();
            foreach (var item in list)
            {
                item.RoomNumber = this.CoutRoomBeLongToLocation(item.LocationID);
            }
            return list;
        }
        public Location getByLocationId(int id)
        {
            Location item = db.Locations.Find(id);
            item.RoomNumber = this.CoutRoomBeLongToLocation(item.LocationID);
            return item;
        }
        public int Delete(int id)
        {
            Location location = db.Locations.Find(id);
            if (location != null)
            {
                db.Locations.Remove(location);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int CoutRoomBeLongToLocation(int locationID)
        {
            return db.Rooms.Where(m => m.LocationID == locationID && m.Status == "Enable").Count();
        }
    }
}

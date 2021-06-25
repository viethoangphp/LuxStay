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
            return db.Locations.ToList();
        }
        public int Delete(int id)
        {
            Location location = db.Locations.Find(id);
            if(location != null)
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
    }
}

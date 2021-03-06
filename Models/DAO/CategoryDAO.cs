using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models.DAO
{
    public class CategoryDAO
    {
        DBContext db = new DBContext();
        public List<RoomCategory> getListAll()
        {
            var list = db.RoomCategories.ToList();
            foreach (var item in list)
            {
                item.roomNumber = this.countRoomByCatId(item.CatID);
            }
            return list;
        }
        public int Insert(RoomCategory model)
        {
            db.RoomCategories.Add(model);
            db.SaveChanges();
            return model.CatID;
        }
        public int Delete(int id)
        {
            RoomCategory result = db.RoomCategories.Find(id);
            if (result != null)
            {
                db.RoomCategories.Remove(result);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public RoomCategory GetCategoryById(int id)
        {
            RoomCategory result = db.RoomCategories.Find(id);
            return result;
        }
        public void Update(RoomCategory model)
        {
            RoomCategory rom = db.RoomCategories.Find(model.CatID);
            if (rom != null)
            {
                rom.CatName = model.CatName;
                rom.Status = model.Status;
                db.SaveChanges();
            }
        }
        public int countRoomByCatId(int catId)
        {
            return db.Rooms.Where(m => m.CatID == catId).Count();
        }
    }
}

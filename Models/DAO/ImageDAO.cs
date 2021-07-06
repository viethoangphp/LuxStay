using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ImageDAO
    {
        DBContext db = new DBContext();
        public int Insert(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
            return image.ImageID;
        }
    }
}

using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PostDAO
    {
        DBContext db = null;
        public PostDAO()
        {
            db = new DBContext();
        }
        public List<Post> getListAll()
        {
            List<Post> list = new List<Post>();
            foreach(var item in db.Posts)
            {
                if(item.Status != -1)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public int Add(Post post)
        {
            try
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        public int Delete(int id)
        {
            try
            {
                Post post = db.Posts.Find(id);
                if (post != null)
                {
                    post.Status = -1;
                }
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UtilityDAO
    {
        DBContext db = new DBContext();
        public List<Utility> getListAll()
        {
            return db.Utilities.ToList();
        }
    }
}

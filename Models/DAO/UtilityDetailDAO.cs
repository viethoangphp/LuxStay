using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UtilityDetailDAO
    {
        DBContext db = new DBContext();
        public int Insert(UtilityDetail utilityDetail)
        {
            db.UtilityDetails.Add(utilityDetail);
            db.SaveChanges();
            return 1;
        }    
    }
}

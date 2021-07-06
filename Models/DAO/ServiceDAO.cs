using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ServiceDAO
    {
        DBContext db = null;
        public ServiceDAO()
        {
            db = new DBContext();
        }
        public List<Utility> getListAll()
        {
            List<Utility> list = db.Utilities.ToList();
            return list;
        }
        public Utility getUtility(int id)
        {
            Utility utl = db.Utilities.Find(id);
            return utl;
        }
        public int Add(Utility utl)
        {
            try
            {
                db.Utilities.Add(utl);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Delete(int id)
        {
            try
            {
                Utility utl = db.Utilities.Find(id);
                if (utl == null)
                {
                    return 0;
                }
                db.Utilities.Remove(utl);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Edit(Utility utl)
        {
            try
            {
                Utility result = db.Utilities.Find(utl.UtilityID);
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    result.UtilityID = utl.UtilityID;
                    result.Name = utl.Name;
                    result.ParentID = utl.ParentID;
                    result.Icon = utl.Icon;
                    result.Status = utl.Status;
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

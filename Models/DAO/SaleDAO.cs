using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entity;
namespace Models.DAO
{
    public class SaleDAO
    {
        DBContext db = new DBContext();
        public List<Sale> getListAll()
        {
            return db.Sales.ToList();
        }
        public int Insert(Sale sale)
        {
            db.Sales.Add(sale);
            db.SaveChanges();
            return sale.SaleID;
        }
        public int Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if(sale != null)
            {
                db.Sales.Remove(sale);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        
    }
}

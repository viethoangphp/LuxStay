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
            return db.Sales.OrderByDescending(m=>m.Create_At).ToList();
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
        public Sale getById(int id)
        {
            Sale result = db.Sales.Find(id);
            if (result != null) return result;
            return null;
        }
        public int Update(Sale sale)
        {
            Sale result = db.Sales.Find(sale.SaleID);
            if(result != null)
            {
                result.PercentSale = sale.PercentSale;
                result.Check_in = sale.Check_in;
                result.Check_out = sale.Check_out;
                result.Status = sale.Status;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}

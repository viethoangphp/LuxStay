using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entity;

namespace Models.DAO
{
    public class BillDAO
    {
        DBContext db = new DBContext();
        public List<Bill> getListBill()
        {
            return db.Bills.ToList();
        }
        public List<Bill> getListBill(int cusID)
        {
            return db.Bills.Where(p=>p.Customer.CustomerID == cusID).ToList();
        }
        public List<Bill> getListByMonth(int month,int status)
        {
            return db.Bills.Where(p=>p.Create_At.Value.Month == month && p.Status == status).ToList();
        }
    }
}

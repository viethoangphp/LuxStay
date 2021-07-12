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
        public int Insert(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill.BillID;
        }
    }
}

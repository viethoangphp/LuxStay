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
        public Bill getBill(int billid)
        {
            return db.Bills.FirstOrDefault(m=>m.BillID == billid);
        }
        public bool confirmBill(int billid,int confirmby)
        {
            try
            {
                Bill bill = db.Bills.FirstOrDefault(m => m.BillID == billid);
                if (bill == null)
                {
                    return false;
                }
                else
                {
                    bill.Status = 1;
                    bill.Confirm_by = confirmby;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

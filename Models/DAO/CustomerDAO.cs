using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entity;
namespace Models.DAO
{
    public class CustomerDAO
    {
        DBContext db = null;
        public CustomerDAO()
        {
            db = new DBContext();
        }
        public List<Customer> getListAll()
        {
            List<Customer> list = db.Customers.ToList();
            return list;
        }
        public string addCustomer(Customer cus)
        {
            string errstring = "";
            try
            {
                db.Customers.Add(cus);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errstring = ex.Message;
            }
            return errstring;
        }
    }
}

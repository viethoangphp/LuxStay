﻿using System;
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
        public int Add(Customer cus)
        {
            try
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                return cus.CustomerID;
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
                Customer cus = db.Customers.Find(id);
                if(cus == null)
                {
                    return 0;
                }
                db.Customers.Remove(cus);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
using Models.Entity;

namespace LuxStay.Areas.Admin.Helper
{
    public class CustomerHelper
    {
        protected CustomerDAO dao = new CustomerDAO();
        public List<CustomerView> getListCustomer()
        {
            var models = dao.getListAll();
            List<CustomerView> list = new List<CustomerView>();
            foreach (var item in models)
            {
                string gd = "Nam";
                if (item.Gender == 0) { gd = "Nữ"; }
                CustomerView cus = new CustomerView();
                cus.id = item.CustomerID;
                cus.fullname = item.FullName;
                cus.email = item.Email;
                cus.phone = item.Phone;
                cus.address = item.Address;
                cus.gender = gd;
                list.Add(cus);
            }
            return list;
        }
        public CustomerView getCustomer(int id)
        {
            var models = dao.getCustomer(id);
            string gd = "Nam";
            if(models.Gender == 0)
            {
                gd = "Nữ";
            }
            CustomerView view = new CustomerView()
            {
                id = models.CustomerID,
                fullname = models.FullName,
                email = models.Email,
                phone = models.Phone,
                address = models.Address,
                gender = gd
            };
            return view;
        }
        public int DeleteCustomer(int id)
        {
            return dao.Delete(id);
        }
        public int AddCustomer(CustomerView data)
        {
            int gd = 0;
            if (data.gender == "1")
            {
                gd = 1;
            }
            Customer cus = new Customer()
            {
                FullName = data.fullname,
                Email = data.email,
                Phone = data.phone,
                Gender = gd,
                Address = data.address
            };
            return dao.Add(cus);
        }
        public int EditCustomer(CustomerView data)
        {
            int gd = 0;
            if (data.gender == "1")
            {
                gd = 1;
            }
            Customer cus = new Customer()
            {
                CustomerID = data.id,
                FullName = data.fullname,
                Email = data.email,
                Address = data.address,
                Phone = data.phone,
                Gender = gd
            };
            return dao.Edit(cus);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
using Models.Entity;
using LuxStay.Models.Data;

namespace LuxStay.Areas.Admin.Helper
{
    public class CustomerHelper
    {
        protected CustomerDAO dao = new CustomerDAO();
        public List<CustomerModel> getListCustomer()
        {
            var models = dao.getListAll();
            List<CustomerModel> list = new List<CustomerModel>();
            foreach (var item in models)
            {
                string gd = "Nam";
                if (item.Gender == 0) { gd = "Nữ"; }
                CustomerModel cus = new CustomerModel();
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
        public CustomerModel getCustomer(int id)
        {
            var models = dao.getCustomer(id);
            string gd = "Nam";
            if (models.Gender == 0)
            {
                gd = "Nữ";
            }
            CustomerModel view = new CustomerModel()
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
        public CustomerModel authCustomer(string email, string pass)
        {
            Customer models = dao.Auth(email, pass);
            if(models != null)
            {
                string gd = "Nam";
                if (models.Gender == 0)
                {
                    gd = "Nữ";
                }
                CustomerModel view = new CustomerModel()
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
            return null;
        }
        public int DeleteCustomer(int id)
        {
            return dao.Delete(id);
        }
        public int AddCustomer(CustomerModel data)
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
                Address = data.address,
                Password = data.password
            };
            return dao.Add(cus);
        }
        public int AddCustomer(RegisterModel data)
        {
            Customer check = dao.getCustomer(data.email);
            if(check != null)
            {
                return 2;
            }
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
                Address = data.address,
                Password = data.password
            };
            return dao.Add(cus);
        }
        public int EditCustomer(CustomerModel data)
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

        public int TotalCustomer()
        {
            return dao.getListAll().Count;
        }
    }
}
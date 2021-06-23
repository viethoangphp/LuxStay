using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using LuxStay.Areas.Admin.Data;
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
    }
}
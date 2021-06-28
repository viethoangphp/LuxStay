using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;

namespace LuxStay.Areas.Admin.Helper
{
    public class SaleHeper
    {
        private SaleDAO dao = new SaleDAO();
        public List<SaleModel> getListAll()
        {
            var listSale = dao.getListAll();
            List<SaleModel> list = new List<SaleModel>();
            foreach(var item in listSale.Where(m=> m.PercentSale != 0))
            {
                SaleModel temp = new SaleModel();
                temp.check_in = String.Format("{0:dd/MM/yyyy}", item.Check_in);
                temp.check_out = String.Format("{0:dd/MM/yyyy}", item.Check_out);
                temp.create_at = String.Format("{0:dd/MM/yyyy}", item.Create_At);
                temp.id = item.SaleID;
                temp.status =(int)item.Status;
                temp.persent = (int)item.PercentSale;
                list.Add(temp);
            }
            return list;
        }
        public int Insert(SaleModel model)
        {
            Sale sale = new Sale();
            sale.PercentSale = model.persent;
            sale.Check_in = DateTime.ParseExact(model.check_in, "dd/MM/yyyy", null);
            sale.Check_out = DateTime.ParseExact(model.check_out, "dd/MM/yyyy", null);
            sale.Status = model.status;
            sale.Create_At = DateTime.Now;
            return dao.Insert(sale);
        }
        public SaleModel getById(int id)
        {
            Sale sale = dao.getById(id);
            if(sale != null)
            {
                SaleModel model = new SaleModel();
                model.id = sale.SaleID;
                model.persent = (int)sale.PercentSale;
                model.check_in = String.Format("{0:dd/MM/yyyy}", sale.Check_in);
                model.check_out = String.Format("{0:dd/MM/yyyy}", sale.Check_out);
                model.create_at = String.Format("{0:dd/MM/yyyy}", sale.Create_At);
                model.status = (int)sale.Status;
                return model;
            }
            return null;
        }
        public int Delete(int id)
        {
            int result = dao.Delete(id);
            if (result == 1) return 1;
            return 0;
        }
        public int Update(SaleModel model)
        {
            Sale sale = new Sale();
            sale.SaleID = model.id;
            sale.PercentSale = model.persent;
            sale.Check_in = DateTime.ParseExact(model.check_in, "dd/MM/yyyy", null);
            sale.Check_out = DateTime.ParseExact(model.check_out, "dd/MM/yyyy", null);
            sale.Status = model.status;
            var result = dao.Update(sale);
            if (result == 1) return 1;
            return 0;
        }
    }
    
}
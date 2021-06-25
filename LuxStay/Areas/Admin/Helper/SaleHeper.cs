using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using LuxStay.Areas.Admin.Data;
using Models.DAO;
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
    }
}
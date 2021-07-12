using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Helper
{
    public class BillHelper
    {
        BillDAO dao = new BillDAO();
        public int Insert(BillModel model)
        {
            Bill bill = new Bill();
            bill.Create_At = DateTime.Now;
            bill.RoomID = model.roomId;
            bill.Check_in = DateTime.ParseExact(model.check_in, "dd-mm-yyyy", null);
            bill.Check_out = DateTime.ParseExact(model.check_out, "dd-mm-yyyy", null);
            bill.Adult = model.adult;
            bill.Baby = model.baby;
            bill.Kid = model.kid;
            bill.Total = model.total;
            bill.Create_by = model.create_by;
            bill.Status = model.status;
            return dao.Insert(bill);
        }
        

    }
}
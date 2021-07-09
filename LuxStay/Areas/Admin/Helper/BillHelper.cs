using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;

namespace LuxStay.Areas.Admin.Helper
{
    public class BillHelper
    {
        BillDAO dao = new BillDAO();
        public List<BillModel> getListBill()
        {
            List<BillModel> view = new List<BillModel>();
            List<Bill> list = dao.getListBill();
            foreach (var item in list)
            {
                BillModel bill = new BillModel()
                {
                    billid = item.BillID,
                    checkin = item.Check_in.ToString(),
                    checkout = item.Check_out.ToString(),
                    datecreate = item.Create_At.ToString(),
                    roomname = item.Room.RoomName,
                    total = (int)item.Total
                };
                view.Add(bill);
            }
            return view;
        }
        public List<BillModel> getListBill(int cusID)
        {
            List<BillModel> view = new List<BillModel>();
            List<Bill> list = dao.getListBill(cusID);
            foreach (var item in list)
            {
                string st = "Chưa thanh toán";
                
                if(item.Status == 1)
                {
                    st = "Đã thanh toán";
                }
                BillModel bill = new BillModel()
                {
                    billid = item.BillID,
                    checkin = item.Check_in.ToString(),
                    checkout = item.Check_out.ToString(),
                    datecreate = item.Create_At.ToString(),
                    roomname = item.Room.RoomName,
                    total = (int)item.Total,
                    status = st
                };
                view.Add(bill);
            }
            return view;
        }
    }
}
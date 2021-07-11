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
                    billId = item.BillID,
                    adult = (int)item.Adult,
                    kid = (int)item.Kid,
                    baby = (int)item.Baby,
                    customername = item.Customer.FullName,
                    check_in = string.Format("{0:dd/MM/yyyy}", item.Check_in),
                    check_out = string.Format("{0:dd/MM/yyyy}", item.Check_out),
                    create_at = string.Format("{0:dd/MM/yyyy}", item.Create_At),
                    roomname = item.Room.RoomName,
                    total = ((int)item.Total).ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + " đ",
                    status = (int)item.Status
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
                BillModel bill = new BillModel()
                {
                    billId = item.BillID,
                    adult = (int)item.Adult,
                    kid = (int)item.Kid,
                    baby = (int)item.Baby,
                    customername = item.Customer.FullName,
                    check_in = string.Format("{0:dd/MM/yyyy}", item.Check_in),
                    check_out = string.Format("{0:dd/MM/yyyy}", item.Check_out),
                    create_at = string.Format("{0:dd/MM/yyyy}", item.Create_At),
                    roomname = item.Room.RoomName,
                    total = ((int)item.Total).ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + " đ",
                    status = (int)item.Status
                };
            }
            return view;
        }
        public BillModel getBill(int billid)
        {
            Bill item = dao.getBill(billid);
            BillModel bill = new BillModel()
            {
                billId = item.BillID,
                adult = (int)item.Adult,
                kid = (int)item.Kid,
                baby = (int)item.Baby,
                customername = item.Customer.FullName,
                check_in = string.Format("{0:dd/MM/yyyy}", item.Check_in),
                check_out = string.Format("{0:dd/MM/yyyy}", item.Check_out),
                create_at = string.Format("{0:dd/MM/yyyy}", item.Create_At),
                roomname = item.Room.RoomName,
                total = ((int)item.Total).ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + " đ",
                status = (int)item.Status
            };
            return bill;
        }
        public bool confirmBill(int id,int confirmby)
        {
            return dao.confirmBill(id,confirmby);
        }
    }
}
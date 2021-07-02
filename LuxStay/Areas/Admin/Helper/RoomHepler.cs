using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Helper
{
    public class RoomHepler
    {
        RoomDAO dao = new RoomDAO();
        public int Insert(RoomModel model)
        {
            Room room = new Room();
            room.CatID = model.categoryID;
            room.LocationID = model.locationID;
            room.SaleID = 1;
            room.Avatar = model.avatar;
            room.RoomName = model.roomName;
            room.Area = model.area;
            room.Price = model.price;
            room.ContentRoom = model.content;
            room.BedNumber = model.bedNumber;
            room.BathRoom = model.bathRoom;
            room.BedRoom = model.bedRoom;
            room.MaxStay = 30;
            room.PeopleMax = model.peopleMax;
            room.Status = "Enable";
            room.Address = model.Address;
            dao.Insert(room);
            return room.RoomID;
        }
        public List<RoomModel> getListAll()
        {
            var list = dao.getListAll();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            List<RoomModel> result = new List<RoomModel>();
            foreach(var item in list)
            {
                RoomModel model = new RoomModel();
                model.id = item.RoomID;
                model.roomName = item.RoomName;
                model.roomLocation = item.RoomCategory.CatName;
                model.roomCategory = item.Location.LocationName;
                model.Address = item.Address;
                model.area = (int)item.Area;
                model.avatar = item.Avatar;
                model.priceShow = double.Parse(item.Price.ToString()).ToString("#,###", cul.NumberFormat);
                model.bedNumber = (int)item.BedNumber;
                model.bedRoom = (int)item.BedRoom;
                model.bathRoom = (int)item.BathRoom;
                model.peopleMax = (int)item.PeopleMax;
                model.content = item.ContentRoom;
                model.status = item.Status;
                result.Add(model);
            }
            return result;
        }
        public int Delete(int id)
        {
            return dao.Delete(id);
        }
        public List<RoomModel> getListRoomByLocationId(int locationId)
        {
            var list = dao.getListRoomByLocationId(locationId);
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            List<RoomModel> result = new List<RoomModel>();
            foreach (var item in list)
            {
                RoomModel model = new RoomModel();
                model.id = item.RoomID;
                model.saleID = (int)item.SaleID;
                model.salePersent = (int)item.Sale.PercentSale;
                model.roomName = item.RoomName;
                model.roomCategory = item.RoomCategory.CatName;
                model.roomLocation = item.Location.LocationName;
                model.Address = item.Address;
                model.area = (int)item.Area;
                model.avatar = item.Avatar;
                model.priceShow = double.Parse(item.Price.ToString()).ToString("#,###", cul.NumberFormat);
                model.bedNumber = (int)item.BedNumber;
                model.bedRoom = (int)item.BedRoom;
                model.bathRoom = (int)item.BathRoom;
                model.peopleMax = (int)item.PeopleMax;
                model.content = item.ContentRoom;
                model.status = item.Status;
                result.Add(model);
            }
            return result;
        }
    }
}
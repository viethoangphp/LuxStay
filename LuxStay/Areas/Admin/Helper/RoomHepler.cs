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
            room.SaleID = model.saleID;
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
                model.categoryID = item.CatID;
                model.saleID = (int)item.SaleID;
                model.salePersent = (int)item.Sale.PercentSale;
                model.locationID = item.LocationID;
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
                model.utility = new List<int>();
                foreach(var utility in item.UtilityDetails.ToList())
                {
                    model.utility.Add(utility.UtilityID);
                }    
                model.sliderImages = new List<string>();
                foreach(var image in item.Images.ToList())
                {
                    model.sliderImages.Add(image.Url);
                }    
                result.Add(model);
            }
            return result;
        }
        public int Delete(int id)
        {
            return dao.Delete(id);
        }
        public List<RoomModel> getListRoomByLocationId(int locationId,int count = 0)
        {
            if(count == 0)
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
            else
            {
                var list = dao.getListRoomByLocationId(locationId,8);
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
        public void Update(RoomModel model)
        {
            Room update = new Room();
            update.RoomID = model.id;
            update.CatID = model.categoryID;
            update.SaleID = model.saleID;
            update.LocationID = model.locationID;
            update.RoomName = model.roomName;
            update.Area = model.area;
            update.Price = model.price;
            update.ContentRoom = model.content;
            update.Avatar = model.avatar;
            update.BedNumber = model.bedNumber;
            update.BedRoom = model.bedRoom;
            update.BathRoom = model.bathRoom;
            update.Status = model.status;
            update.PeopleMax = model.peopleMax;
            update.Address = model.Address;
            dao.Update(update);
        }
        public RoomModel getRoomById(int id)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            Room item = dao.getRoomById(id);
            RoomModel model = new RoomModel();
            model.id = item.RoomID;
            model.categoryID = item.CatID;
            model.locationID = item.LocationID;
            model.saleID = (int)item.SaleID;
            model.salePersent = (int)item.Sale.PercentSale;
            model.roomName = item.RoomName;
            model.roomLocation = item.RoomCategory.CatName;
            model.roomCategory = item.Location.LocationName;
            model.Address = item.Address;
            model.area = (int)item.Area;
            model.avatar = item.Avatar;
            model.price = (int)item.Price;
            model.priceShow = double.Parse(item.Price.ToString()).ToString("#,###", cul.NumberFormat);
            model.bedNumber = (int)item.BedNumber;
            model.bedRoom = (int)item.BedRoom;
            model.bathRoom = (int)item.BathRoom;
            model.peopleMax = (int)item.PeopleMax;
            model.content = item.ContentRoom;
            model.status = item.Status;
            model.status = item.Status;
            model.utility = new List<int>();
            foreach (var utility in item.UtilityDetails.ToList())
            {
                model.utility.Add(utility.UtilityID);
            }
            model.sliderImages = new List<string>();
            foreach (var image in item.Images.ToList())
            {
                model.sliderImages.Add(image.Url);
            }
            return model;
        }
    }
}
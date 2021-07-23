using LuxStay.Areas.Admin.Data;
using LuxStay.Areas.Admin.Helper;
using LuxStay.Models.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using LuxStay.Others;
using Newtonsoft.Json.Linq;

namespace LuxStay.Controllers
{
    public class CheckoutController : ClientController
    {
        // GET: Checkout
        public ActionResult Index()
        {
            Checkout checkout = new Checkout();
            checkout.checkin = Request.QueryString["checkin"];
            checkout.checkout = Request.QueryString["checkout"];
            int id = Int32.Parse(Request.QueryString["id"]);
            checkout.id = id;
            RoomModel room = new RoomHepler().getRoomById(id);
            checkout.room = room;
            DateTime checkin = DateTime.ParseExact(checkout.checkin, "dd-MM-yyyy", null);
            DateTime checkout1 = DateTime.ParseExact(checkout.checkout, "dd-MM-yyyy", null);
            checkout.stayNumber = (int)(checkout1 - checkin).TotalDays;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            if (room.salePersent != 0)
            {
                int price = room.priceSale1 * checkout.stayNumber;
                checkout.total = double.Parse(price.ToString()).ToString("#,###", cul.NumberFormat);
            }
            else
            {
                checkout.total = double.Parse((room.price * checkout.stayNumber).ToString()).ToString("#,###", cul.NumberFormat);
            }
            return View(checkout);
        }
        public ActionResult Payment()
        {
            Checkout checkout = new Checkout();
            checkout.checkin = Request.QueryString["checkin"];
            checkout.checkout = Request.QueryString["checkout"];
            int id = Int32.Parse(Request.QueryString["id"]);
            checkout.id = id;
            RoomModel room = new RoomHepler().getRoomById(id);
            checkout.room = room;
            DateTime checkin = DateTime.ParseExact(checkout.checkin, "dd-MM-yyyy", null);
            DateTime checkout1 = DateTime.ParseExact(checkout.checkout, "dd-MM-yyyy", null);
            checkout.stayNumber = (int)(checkout1 - checkin).TotalDays;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            checkout.total = double.Parse((room.price * checkout.stayNumber).ToString()).ToString("#,###", cul.NumberFormat);
            return View(checkout);
        }
        public ActionResult Success(Checkout model)
        {
            if (Request.Form["payment"] != null)
            {
                var payment = Int32.Parse(Request.Form["payment"]);
                if (payment == 0 || payment == 3)
                {
                    TempData["Message"] = "Phương thức này hiện tại chưa hỗ trợ vui lòng chọn 1 phương thức thanh toán khác . Cám ơn";
                    string url = "/Checkout/Payment?id=" + Request.Form["id"] + "&checkin=" + Request.Form["checkin"] + "&checkout=" + Request.Form["checkout"];
                    return Redirect(url);
                }
                if (payment == 1)
                {
                    // tạo đơn đặt phòng
                    // Tạo Bill 
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    BillModel bill = new BillModel();
                    bill.check_in = model.checkin;
                    bill.check_out = model.checkout;
                    bill.roomId = model.id;
                    var room = new RoomHepler().getRoomById(model.id);
                    var customer = (CustomerModel)Session["USER"];
                    bill.create_by = ((CustomerModel)Session["USER"]).id;
                    bill.kid = 1;
                    DateTime checkin = DateTime.ParseExact(model.checkin, "dd-MM-yyyy", null);
                    DateTime checkout1 = DateTime.ParseExact(model.checkout, "dd-MM-yyyy", null);
                    var stayNumber = (int)(checkout1 - checkin).TotalDays;
                    bill.total = stayNumber * (((100 - room.salePersent) * room.price) / 100);
                    bill.adult = 1;
                    bill.baby = 1;
                    bill.status = 0;
                    var total = double.Parse(bill.total.ToString()).ToString("#,###", cul.NumberFormat);
                    var insert = new BillHelper().Insert(bill);
                    string emailTo = customer.email;
                    string body = "<div style='font-family: monospace;'><div style='background: #f5f5f5; height: 100%;'><div style='width: 960px; margin: 0 auto; background-color: #fff;'><div style='padding: 1rem; display:flex;justify-content: space-between; '><div style='display: flex; align-items: center;'> <img src='https://ci4.googleusercontent.com/proxy/Qonyh7SGiugVCkOUcEl9Nri_rvJ1TEM4FJH846rwwNu2N6t3UCmmbzCdmES2TADenuXklmfpCdncrmE7dnMeqqKNUAigEg=s0-d-e1-ft#https://api.luxstay.com/images/emails/logo_dark.png' alt=''></div><div style='text-align: end;margin-left: auto'><p>Mã hóa đơn: <span>HOMESTAY00" + insert + "</span></p><p>Ngày đặt: <span>" + String.Format("{0:dd/MM/yyyy}", DateTime.Now) + "</span></p></div></div><div style='display:flex;justify-content: space-between;'><div style='width: 30%; background-color: #1ed760;'></div><h1 style='font-size: 3rem; text-transform: uppercase;margin: 0;'>Đặt phòng thành công</h1><div style='width: 10%; background-color: #1ed760;'></div></div>";
                    body += "<div style='margin-top: 1rem;padding: 1rem;'><div><h3 style='font-size: 1.725rem;'>Thông tin phòng</h3><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Người đặt:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'> " + customer.fullname + "</p></div><div style='width: 100%; display: flex'> <span style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Tên căn hộ: </span><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'>" + room.roomName + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Địa chỉ:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + room.Address + ", Việt Nam</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày nhận phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> " + model.checkin + " đến " + model.checkout + " (" + stayNumber + " đêm)</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày trả phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + model.checkout + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Khách:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> 3 người lớn, 2 trẻ em và 1 em bé</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Phương thức thanh toán:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> Chuyển khoản ngân hàng VietComBank</p></div><div style='width: 100%;margin: 2rem 0;border-top: 1px dashed;'></div><div style='display: flex;justify-content: space-between;text-align: center;'><h3 style='font-size: 1.725rem;margin:0'>Tổng tiền</h3> <span style='font-size: 1.725rem;margin-left: auto'>" + total + "đ</span></div><div style='width:70%;margin: 0 auto;'><h2 style='font-size: 1.125rem; text-align: center; margin-top:4rem;'>Cảm ơn " + customer.fullname + " đã sử dụng dịch vụ của Luxstay</h2></div></div></div></div></div></div>";
                    EmailService service = new EmailService();
                    service.Send(emailTo, body);
                    ///////

                    string url = ConfigurationManager.AppSettings["Url"];
                    string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
                    string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
                    string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

                    PayLib pay = new PayLib();
                    double amount = (double)bill.total * 100; //debug xem :v
                    pay.AddRequestData("vnp_Version", "2.0.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.0.0
                    pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
                    pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
                    pay.AddRequestData("vnp_Amount", amount.ToString()); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
                    pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
                    pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
                    pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
                    pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
                    pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
                    pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
                    pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
                    pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
                    pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn
                    string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

                    return Redirect(paymentUrl);
                }
                else
                {
                    // tạo đơn đặt phòng
                    // Tạo Bill 
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                    BillModel bill = new BillModel();
                    bill.check_in = model.checkin;
                    bill.check_out = model.checkout;
                    bill.roomId = model.id;
                    var room = new RoomHepler().getRoomById(model.id);
                    var customer = (CustomerModel)Session["USER"];
                    bill.create_by = ((CustomerModel)Session["USER"]).id;
                    bill.kid = 1;
                    DateTime checkin = DateTime.ParseExact(model.checkin, "dd-MM-yyyy", null);
                    DateTime checkout1 = DateTime.ParseExact(model.checkout, "dd-MM-yyyy", null);
                    var stayNumber = (int)(checkout1 - checkin).TotalDays;
                    bill.total = stayNumber * (((100 - room.salePersent) * room.price) / 100);
                    bill.adult = 1;
                    bill.baby = 1;
                    bill.status = 0;
                    var total = double.Parse(bill.total.ToString()).ToString("#,###", cul.NumberFormat);
                    var insert = new BillHelper().Insert(bill);
                    string emailTo = customer.email;
                    string body = "<div style='font-family: monospace;'><div style='background: #f5f5f5; height: 100%;'><div style='width: 960px; margin: 0 auto; background-color: #fff;'><div style='padding: 1rem; display:flex;justify-content: space-between; '><div style='display: flex; align-items: center;'> <img src='https://ci4.googleusercontent.com/proxy/Qonyh7SGiugVCkOUcEl9Nri_rvJ1TEM4FJH846rwwNu2N6t3UCmmbzCdmES2TADenuXklmfpCdncrmE7dnMeqqKNUAigEg=s0-d-e1-ft#https://api.luxstay.com/images/emails/logo_dark.png' alt=''></div><div style='text-align: end;margin-left: auto'><p>Mã hóa đơn: <span>HOMESTAY00" + insert + "</span></p><p>Ngày đặt: <span>" + String.Format("{0:dd/MM/yyyy}", DateTime.Now) + "</span></p></div></div><div style='display:flex;justify-content: space-between;'><div style='width: 30%; background-color: #1ed760;'></div><h1 style='font-size: 3rem; text-transform: uppercase;margin: 0;'>Đặt phòng thành công</h1><div style='width: 10%; background-color: #1ed760;'></div></div>";
                    body += "<div style='margin-top: 1rem;padding: 1rem;'><div><h3 style='font-size: 1.725rem;'>Thông tin phòng</h3><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Người đặt:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'> " + customer.fullname + "</p></div><div style='width: 100%; display: flex'> <span style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Tên căn hộ: </span><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'>" + room.roomName + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Địa chỉ:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + room.Address + ", Việt Nam</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày nhận phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> " + model.checkin + " đến " + model.checkout + " (" + stayNumber + " đêm)</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày trả phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + model.checkout + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Khách:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> 3 người lớn, 2 trẻ em và 1 em bé</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Phương thức thanh toán:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> Chuyển khoản ngân hàng VietComBank</p></div><div style='width: 100%;margin: 2rem 0;border-top: 1px dashed;'></div><div style='display: flex;justify-content: space-between;text-align: center;'><h3 style='font-size: 1.725rem;margin:0'>Tổng tiền</h3> <span style='font-size: 1.725rem;margin-left: auto'>" + total + "đ</span></div><div style='width:70%;margin: 0 auto;'><h2 style='font-size: 1.125rem; text-align: center; margin-top:4rem;'>Cảm ơn " + customer.fullname + " đã sử dụng dịch vụ của Luxstay</h2></div></div></div></div></div></div>";
                    EmailService service = new EmailService();
                    service.Send(emailTo, body);
                    ///////
                    //request params need to request to MoMo system
                    string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                    string partnerCode = "MOMOWQQR20210714";
                    string accessKey = "BrHZ5FBeYvQIhKgS";
                    string serectkey = "onrvsKEblZJXcnyKqgaSv259vnHyZzq3";
                    string orderInfo = "Thanh Toán Đơn Đặt Phòng Homestay00" + bill.billId;
                    string returnUrl = "https://it-hutech.com/Checkout/PaymentConfirm";
                    string notifyurl = "https://it-hutech.com/Checkout/PaymentConfirm"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

                    string amount = "10000";
                    string orderid = DateTime.Now.Ticks.ToString();
                    string requestId = DateTime.Now.Ticks.ToString();
                    string extraData = "";


                    //Before sign HMAC SHA256 signature
                    string rawHash = "partnerCode=" +
                        partnerCode + "&accessKey=" +
                        accessKey + "&requestId=" +
                        requestId + "&amount=" +
                        amount + "&orderId=" +
                        orderid + "&orderInfo=" +
                        orderInfo + "&returnUrl=" +
                        returnUrl + "&notifyUrl=" +
                        notifyurl + "&extraData=" +
                        extraData;
                    MoMoSecurity crypto = new MoMoSecurity();
                    //sign signature SHA256
                    string signature = crypto.signSHA256(rawHash, serectkey);

                    //build body json request
                    JObject message = new JObject
                    {
                        { "partnerCode", partnerCode },
                        { "accessKey", accessKey },
                        { "requestId", requestId },
                        { "amount", amount },
                        { "orderId", orderid },
                        { "orderInfo", orderInfo },
                        { "returnUrl", returnUrl },
                        { "notifyUrl", notifyurl },
                        { "extraData", extraData },
                        { "requestType", "captureMoMoWallet" },
                        { "signature", signature }
                    };

                    string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

                    JObject jmessage = JObject.Parse(responseFromMomo);

                    return Redirect(jmessage.GetValue("payUrl").ToString());
                }
            }
            else
            {
                TempData["Message"] = "Bạn Chưa Chọn Phương Thức Thanh Toán . Vui Lòng Chọn 1 trong 4 phương thức thanh toán . Cám Ơn";
                string url = "/Checkout/Payment?id=" + Request.Form["id"] + "&checkin=" + Request.Form["checkin"] + "&checkout=" + Request.Form["checkout"];
                return Redirect(url);
            }
            
        }
        
        public ActionResult PaymentConfirm()
        {
            ViewBag.Message = "Thanh Toán Thành Công";

            return View();
        }
    }
}
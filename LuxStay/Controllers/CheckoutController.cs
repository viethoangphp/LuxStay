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

namespace LuxStay.Controllers
{
    public class CheckoutController :ClientController
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
            checkout.total = double.Parse((room.price * checkout.stayNumber).ToString()).ToString("#,###", cul.NumberFormat);
            return View(checkout);
        }
        
        public ActionResult PaymentWithPayPal(string Cancel = null)
        {
            //getting the apiContext
            var check = Request.Form["momo"];
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal
                //Payer Id will be returned when payment proceeds or click to pay
                string payerId = Request.Params["PayerID"];

                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist
                    //it is returned by the create function call of the payment class

                    // Creating a payment
                    // baseURL is the url on which paypal sendsback the data.
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                "/Checkout/PaymentWithPayPal?";

                    //here we are generating guid for storing the paymentID received in session
                    //which will be used in the payment execution

                    var guid = Convert.ToString((new Random()).Next(100000));

                    //CreatePayment function gives us the payment approval url
                    //on which payer is redirected for paypal account payment

                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);

                    //get links returned from paypal in response to Create function call

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = null;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    // saving the paymentID in the key guid
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {

                    // This function exectues after receving all parameters for the payment

                    var guid = Request.Params["guid"];

                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                    //If executed payment failed then we will show payment failure message to user
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception)
            {

                return View("FailureView");
            }
            return View("SuccessView");
        }

        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {

            //create itemlist and add item objects to it
            var itemList = new ItemList() { items = new List<Item>() };

            //Adding Item Details like name, currency, price etc
            itemList.items.Add(new Item()
            {
                name = "The Galaxy Home",
                currency = "USD",
                price = "1",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };

            //Final amount with details
            var amount = new Amount()
            {
                currency = "USD",
                total = "3", // Total must be equal to sum of tax, shipping and subtotal.
                details = details
            };

            var transactionList = new List<Transaction>();
            // Adding description about the transaction
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = "your invoice number 123 nha", //Generate an Invoice No đây nè lêu lêu, đổi xem,invoice number không được trùng
                amount = amount,
                item_list = itemList
            });


            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
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
            bill.total = stayNumber * ((100 - room.salePersent) * room.price )/100;
            bill.adult = 1;
            bill.baby = 1;
            bill.status = 0;
            var total = double.Parse(bill.total.ToString()).ToString("#,###", cul.NumberFormat);
            var insert = new BillHelper().Insert(bill);
            string smtpUserName = "tranviethoang.nb@gmail.com";
            string smtpPassword = "Viethoang123";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 25;
            string emailTo = customer.email;
            string subject = "Xác Nhận Đặt Phòng Thành Công";
            string body = "<div style='font-family: monospace;'><div style='background: #f5f5f5; height: 100%;'><div style='width: 960px; margin: 0 auto; background-color: #fff;'><div style='padding: 1rem; display:flex;justify-content: space-between; '><div style='display: flex; align-items: center;'> <img src='https://ci4.googleusercontent.com/proxy/Qonyh7SGiugVCkOUcEl9Nri_rvJ1TEM4FJH846rwwNu2N6t3UCmmbzCdmES2TADenuXklmfpCdncrmE7dnMeqqKNUAigEg=s0-d-e1-ft#https://api.luxstay.com/images/emails/logo_dark.png' alt=''></div><div style='text-align: end;margin-left: auto'><p>Mã hóa đơn: <span>HOMESTAY00" + insert+"</span></p><p>Ngày đặt: <span>"+ String.Format("{0:dd/MM/yyyy}",DateTime.Now)+"</span></p></div></div><div style='display:flex;justify-content: space-between;'><div style='width: 30%; background-color: #1ed760;'></div><h1 style='font-size: 3rem; text-transform: uppercase;margin: 0;'>Đặt phòng thành công</h1><div style='width: 10%; background-color: #1ed760;'></div></div>";
            body += "<div style='margin-top: 1rem;padding: 1rem;'><div><h3 style='font-size: 1.725rem;'>Thông tin phòng</h3><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Người đặt:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'> " + customer.fullname + "</p></div><div style='width: 100%; display: flex'> <span style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;margin:0.625rem 0;'> Tên căn hộ: </span><p style='width: 50%; display: inline-block;font-size: 1.125rem;margin: 0.625rem 0;'>" + room.roomName + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Địa chỉ:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + room.Address + ", Việt Nam</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày nhận phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> " + model.checkin + " đến " + model.checkout + " (" + stayNumber + " đêm)</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Ngày trả phòng:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'>" + model.checkout + "</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Khách:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> 3 người lớn, 2 trẻ em và 1 em bé</p></div><div style='width: 100%; display: flex'><p style='width: 30%; display: inline-block; font-weight: bold;font-size: 1.125rem;'> Phương thức thanh toán:</p><p style='width: 50%; display: inline-block;font-size: 1.125rem;'> Chuyển khoản ngân hàng VietComBank</p></div><div style='width: 100%;margin: 2rem 0;border-top: 1px dashed;'></div><div style='display: flex;justify-content: space-between;text-align: center;'><h3 style='font-size: 1.725rem;margin:0'>Tổng tiền</h3> <span style='font-size: 1.725rem;margin-left: auto'>" + total + "đ</span></div><div style='width:70%;margin: 0 auto;'><h2 style='font-size: 1.125rem; text-align: center; margin-top:4rem;'>Cảm ơn " + customer.fullname + " đã sử dụng dịch vụ của Luxstay</h2></div></div></div></div></div></div>";
            EmailService service = new EmailService();
            bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
            if (kq == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Home");
        }
    }
}
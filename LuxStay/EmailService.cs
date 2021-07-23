using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
namespace LuxStay
{
    public class EmailService
    {
        public void Send(string toEmail,string content)
        {
            MailAddress fromAddress = new MailAddress("tranviethoang.nb@gmail.com", "LuxStay");
            MailAddress toAddress = new MailAddress(toEmail);
            const string fromPassword = "nffegjqoaiucskcb";
            string subject = "LuxStay Thông Báo Đặt Phòng Thành Công";
            string body = content;

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })
            {
                smtp.Send(message);
            }
        }
}
}
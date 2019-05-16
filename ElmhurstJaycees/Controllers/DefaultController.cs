using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElmhurstJaycees.Models;

namespace ElmhurstJaycees.Controllers
{
    public class DefaultController : Controller
    {
        private ElmhurstJayceesEntities _db = new ElmhurstJayceesEntities();

        public ActionResult Photos()
        {
            var photos = _db.Files.Where(f => f.Photo && f.Public).OrderByDescending(p => p.FileID);
            return View(photos.ToList());
        }

        //[HttpPost]
        //public ActionResult PancakeOrder(PancakeOrder p)
        //{
        //    String serverName = "relay-hosting.secureserver.net";
        //    String emailFrom = "pancakeorder@elmhurstjaycees.com";
        //    //  string emailTo = "justin.r.smits@gmail.com,brianstalk@gmail.com,cherylmoore414@gmail.com";
        //    string emailTo = "justin.r.smits@gmail.com";
        //    string emailSubject = "Pancake Order";
        //    String body = "";
        //    body = "Name: " + p.Name +
        //        Environment.NewLine + "Email: " + p.Email +
        //     Environment.NewLine + "Phone: " + p.Phone;

        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(emailFrom, emailTo, emailSubject, body);
        //    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(serverName, 25);
        //    smtpClient.EnableSsl = false;
        //    smtpClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        //    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    smtpClient.Send(msg);
        //    return View("PancakeOrderPayPal");
        //}

        //[HttpPost]
        //public ActionResult MegaPassOrder(String Name, String Address, String Zip, String Email, String Phone, String NumberPasses,
        //    String ChildName1, String ChildAge1, String ChildName2, String ChildAge2, String ChildName3, String ChildAge3)
        //{
        //    String serverName = "relay-hosting.secureserver.net";
        //    String emailFrom = "megaPass@elmhurstjaycees.com";
        //  //  string emailTo = "justin.r.smits@gmail.com,brianstalk@gmail.com,cherylmoore414@gmail.com";
        //    string emailTo = "justin.r.smits@gmail.com";
        //    string emailSubject = "Mega Pass Order";
        //    String body = "";
        //    body = "Name: " + Name +
        //        Environment.NewLine + "Address: " + Address +
        //        Environment.NewLine + "Zip: " + Zip +
        //        Environment.NewLine + "Email: " + Email +
        //        Environment.NewLine + "Phone: " + Phone +
        //        Environment.NewLine + "Number of Passes: " + NumberPasses +
        //        Environment.NewLine + "Child: " + ChildName1 + " Age: " + ChildAge1 +
        //        Environment.NewLine + "Child: " + ChildName2 + " Age: " + ChildAge2 +
        //        Environment.NewLine + "Child: " + ChildName3 + " Age: " + ChildAge3;

        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(emailFrom, emailTo, emailSubject, body);
        //    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(serverName, 25);
        //    smtpClient.EnableSsl = false;
        //    smtpClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        //    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    smtpClient.Send(msg);
        //    return View("MegaPassPaypal");
        //}
        public ActionResult Error()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Error = Session["LastException"].ToString();
            }
            else
            {
                ViewBag.Error = String.Empty;
            }
            return View();
        }
    }
}

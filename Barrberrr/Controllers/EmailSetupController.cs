using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Barrberrr.Models;
using System.Net;
using System.Net.Mail;


namespace Barrberrr.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Barrberrr.Models.Gmail model)
        {
            MailMessage mm = new MailMessage("phucnguyenthanhhong@gmail.com", model.Email);
            mm.Subject = model.Phone;
            mm.Body = model.Message;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("phucnguyenthanhhong@gmail.com", "pxbirdisnumber1");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sent Successfully";
            return View();
        }
        // GET: /EmailSetup/Complete
        public ActionResult Complete()
        {
            return View();
        }
    }
}
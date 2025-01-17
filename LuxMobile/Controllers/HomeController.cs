﻿using LuxMobile.Models;
using LuxMobile.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using LuxMobile.Areas.Identity.Pages.Account;
using System.Net.Mail;

namespace LuxMobile.Controllers
{
    public class HomeController : Controller
    {
        //ContactUs code came from https://www.codeproject.com/Tips/1081578/How-to-Implement-Contact-Us-Page-in-ASP-NET-MVC-AS
        //NOTE : sender's name is still not visible in mail and cannot reply to the sender yet --- to be continued

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactView vm)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();

                    //Email which you are getting from contact us page
                    msz.From = new MailAddress(vm.Email); 
                    
                    //Where mail will be sent 
                    msz.To.Add("lmb.ownerr@gmail.com");
                    
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = new System.Net.NetworkCredential("LMB.ContactUs@gmail.com", "Luxx2020");

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for contacting us. We'll get back to you as soon as possible.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }

        public IActionResult Error2()
        {
            return View();
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //original home page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LuxMobile.Data;
using LuxMobile.Models;

namespace LuxMobile.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext context1;

        public ServiceController(ApplicationDbContext context)
        {
            context1 = context;
        }

        public IActionResult Index()
        {
            var list = context1.Services.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            var list = context1.Services.ToList();
            return View(list);
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Services record)
        {
            var service = new Services()
            {
                ServiceName = record.ServiceName,
                Description = record.Description,
                Price = record.Price
            };

            context1.Services.Add(service);
            context1.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var service = context1.Services.Where(i => i.ServiceNo == id).SingleOrDefault();
            if (service == null)
            {
                return RedirectToAction("Index");
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Services record)
        {
            var service = context1.Services.Where(i => i.ServiceNo == id).SingleOrDefault();
            service.ServiceName = record.ServiceName;
            service.Description = record.Description;
            service.Price = record.Price;

            context1.Services.Update(service);
            context1.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var service = context1.Services.Where(i => i.ServiceNo == id).SingleOrDefault();
            if (service == null)
            {
                return RedirectToAction("Index");
            }

            context1.Services.Remove(service);
            context1.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

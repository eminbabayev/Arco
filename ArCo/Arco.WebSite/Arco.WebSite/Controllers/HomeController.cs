using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arco.WebSite.Models;

namespace Arco.WebSite.Controllers
{
    public class HomeController : Controller
    {
        ArcoEntities db = new ArcoEntities();
        public ActionResult Index()
        {
            ViewHome data = new ViewHome
            {
                Setting = db.Settings.FirstOrDefault(),
                Services = db.Services.ToList(),
                Skills = db.Skills.ToList(),
                Numbers = db.Numbers.ToList(),
                Categories = db.Categories.ToList(),
                Portfolios = db.Portfolios.ToList(),
                ChooesUs = db.ChooesUs.ToList(),
                Members = db.Members.ToList(),
                Packages = db.Packages.ToList(),
                Clients = db.Clients.ToList(),
                Testimonials = db.Testimonials.ToList()
                
            };

            return View(data);
        }

       
    }
}
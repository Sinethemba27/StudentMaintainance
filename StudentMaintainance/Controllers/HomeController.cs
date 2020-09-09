using StudentMaintainance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMaintainance.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index1");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("Index");
            }
            else if (User.IsInRole("Contractor"))
            {
                return RedirectToAction("Index4");
            }
            return View();
        }
        public ActionResult Index1()
        {
            return View(db.Maintainances.ToList());

        }
        public ActionResult Index3()
        {
            return View();

        }
        public ActionResult Index4()
        {
            return View();

        }
        public ActionResult About()
        {
           
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Residences()
        {
            var listres = db.Residences.Find(2);
            ViewBag.lat = listres.Latitude;
            ViewBag.log = listres.Longitude;

            var listres1 = db.Residences.Find(1);

            ViewBag.lat2 = listres1.Latitude;
            ViewBag.log2 = listres1.Longitude;

            var listres3 = db.Residences.Find(3);


            ViewBag.lat3 = listres3.Latitude;
            ViewBag.log3 = listres3.Longitude;


            var id = db.Residences.Select(x => x.ResId).Max();

            var list4 = db.Residences.Find(id);

            ViewBag.lat4 = list4.Latitude;
            ViewBag.log4 = list4.Longitude;
            return View();
        }

    }
}
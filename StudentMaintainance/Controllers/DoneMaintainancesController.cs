using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentMaintainance.Models;
using Microsoft.AspNet.Identity;

namespace StudentMaintainance.Controllers
{
    public class DoneMaintainancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoneMaintainances
        public ActionResult Index()
        {
            return View(db.DoneMaintainances.ToList());
        }
        public ActionResult Index2()
        {
            return View(db.DoneMaintainances.ToList().Where(p => p.StudentEmail == User.Identity.GetUserName()));
        }
        public ActionResult Index3()
        {
            return View(db.DoneMaintainances.ToList().Where(p => p.Contractor_EmailAddress == User.Identity.GetUserName()));
        }
        // GET: DoneMaintainances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoneMaintainance doneMaintainance = db.DoneMaintainances.Find(id);
            if (doneMaintainance == null)
            {
                return HttpNotFound();
            }
            return View(doneMaintainance);
        }

        // GET: DoneMaintainances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoneMaintainances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintainanceId,StudentNAme,StudentEmail,ReportDate,FixedDate,Comments,Contractor,ResName,Status,Contractor_EmailAddress,Image")] DoneMaintainance doneMaintainance)
        {
            if (ModelState.IsValid)
            {
                db.DoneMaintainances.Add(doneMaintainance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doneMaintainance);
        }

        // GET: DoneMaintainances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoneMaintainance doneMaintainance = db.DoneMaintainances.Find(id);
            if (doneMaintainance == null)
            {
                return HttpNotFound();
            }
            return View(doneMaintainance);
        }

        // POST: DoneMaintainances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintainanceId,StudentNAme,StudentEmail,ReportDate,FixedDate,Comments,Contractor,ResName,Status,Contractor_EmailAddress,Image")] DoneMaintainance doneMaintainance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doneMaintainance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doneMaintainance);
        }

        // GET: DoneMaintainances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoneMaintainance doneMaintainance = db.DoneMaintainances.Find(id);
            if (doneMaintainance == null)
            {
                return HttpNotFound();
            }
            return View(doneMaintainance);
        }

        // POST: DoneMaintainances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoneMaintainance doneMaintainance = db.DoneMaintainances.Find(id);
            db.DoneMaintainances.Remove(doneMaintainance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

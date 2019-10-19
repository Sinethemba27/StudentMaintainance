using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentMaintainance.Models;

namespace StudentMaintainance.Controllers
{
    public class MaintainancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maintainances
        public ActionResult Index()
        {
            return View(db.Maintainances.ToList());
        }

        // GET: Maintainances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            return View(maintainance);
        }

        // GET: Maintainances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintainances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintainanceId,StudentNAme,ReportDate,FixedDate,Comments,Contractor,Image")] Maintainance maintainance)
        {
            if (ModelState.IsValid)
            {
                db.Maintainances.Add(maintainance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintainance);
        }

        // GET: Maintainances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            return View(maintainance);
        }

        // POST: Maintainances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintainanceId,StudentNAme,ReportDate,FixedDate,Comments,Contractor,Image")] Maintainance maintainance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintainance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintainance);
        }

        // GET: Maintainances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            return View(maintainance);
        }

        // POST: Maintainances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintainance maintainance = db.Maintainances.Find(id);
            db.Maintainances.Remove(maintainance);
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

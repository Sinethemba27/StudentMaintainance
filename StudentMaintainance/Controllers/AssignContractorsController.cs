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
    public class AssignContractorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignContractors
        public ActionResult Index()
        {
            var assignContractors = db.AssignContractors.Include(a => a.Contractor).Include(a => a.Maintainance);
            return View(assignContractors.ToList());
        }

        // GET: AssignContractors/Details/5
        public ActionResult Details(int? id)
        {

            //
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignContractor assignContractor = db.AssignContractors.Find(id);
            if (assignContractor == null)
            {
                return HttpNotFound();
            }
            return View(assignContractor);
        }

        // GET: AssignContractors/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName");
            ViewBag.MaintainanceId = new SelectList(db.Maintainances, "MaintainanceId", "StudentNAme");
            return View();
        }

        // POST: AssignContractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "acontract,ContractorId,MaintainanceId,Status")] AssignContractor assignContractor)
        {
            if (ModelState.IsValid)
            {
                db.AssignContractors.Add(assignContractor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", assignContractor.ContractorId);
            ViewBag.MaintainanceId = new SelectList(db.Maintainances, "MaintainanceId", "StudentNAme", assignContractor.MaintainanceId);
            return View(assignContractor);
        }

        // GET: AssignContractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignContractor assignContractor = db.AssignContractors.Find(id);
            if (assignContractor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", assignContractor.ContractorId);
            ViewBag.MaintainanceId = new SelectList(db.Maintainances, "MaintainanceId", "StudentNAme", assignContractor.MaintainanceId);
            return View(assignContractor);
        }

        // POST: AssignContractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "acontract,ContractorId,MaintainanceId,Status")] AssignContractor assignContractor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignContractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", assignContractor.ContractorId);
            ViewBag.MaintainanceId = new SelectList(db.Maintainances, "MaintainanceId", "StudentNAme", assignContractor.MaintainanceId);
            return View(assignContractor);
        }

        // GET: AssignContractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignContractor assignContractor = db.AssignContractors.Find(id);
            if (assignContractor == null)
            {
                return HttpNotFound();
            }
            return View(assignContractor);
        }

        // POST: AssignContractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignContractor assignContractor = db.AssignContractors.Find(id);
            db.AssignContractors.Remove(assignContractor);
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

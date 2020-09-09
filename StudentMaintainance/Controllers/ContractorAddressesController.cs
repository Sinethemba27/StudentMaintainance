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
    public class ContractorAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContractorAddresses
        public ActionResult Index()
        {
            var contractorAddresses = db.ContractorAddresses.Include(c => c.con);
            return View(contractorAddresses.ToList());
        }

        // GET: ContractorAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorAddresses contractorAddresses = db.ContractorAddresses.Find(id);
            if (contractorAddresses == null)
            {
                return HttpNotFound();
            }
            return View(contractorAddresses);
        }

        // GET: ContractorAddresses/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName");
            return View();
        }

        // POST: ContractorAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConID,Latitude,Longitude,ContractorId")] ContractorAddresses contractorAddresses)
        {
            if (ModelState.IsValid)
            {
                db.ContractorAddresses.Add(contractorAddresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", contractorAddresses.ContractorId);
            return View(contractorAddresses);
        }

        // GET: ContractorAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorAddresses contractorAddresses = db.ContractorAddresses.Find(id);
            if (contractorAddresses == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", contractorAddresses.ContractorId);
            return View(contractorAddresses);
        }

        // POST: ContractorAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConID,Latitude,Longitude,ContractorId")] ContractorAddresses contractorAddresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractorAddresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractorId = new SelectList(db.Contractors, "ContractorId", "ContractorName", contractorAddresses.ContractorId);
            return View(contractorAddresses);
        }

        // GET: ContractorAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractorAddresses contractorAddresses = db.ContractorAddresses.Find(id);
            if (contractorAddresses == null)
            {
                return HttpNotFound();
            }
            return View(contractorAddresses);
        }

        // POST: ContractorAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractorAddresses contractorAddresses = db.ContractorAddresses.Find(id);
            db.ContractorAddresses.Remove(contractorAddresses);
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

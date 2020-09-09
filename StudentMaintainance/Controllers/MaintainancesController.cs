using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentMaintainance.Models;
using System.IO;
using Microsoft.AspNet.Identity;

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
        public ActionResult Index2()
        {
            return View(db.Maintainances.ToList().Where(p=>p.StudentEmail==User.Identity.GetUserName()));
        }
        public ActionResult Index3()
        {
            return View(db.Maintainances.ToList().Where(p => p.Contractor_EmailAddress == User.Identity.GetUserName()));
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
        public ActionResult CheckInn(int? id)
        {
            return RedirectToAction("Create", "AssignContractors", new { id = id });            
        }

        public ActionResult Done(int? id)
        {
            Maintainance maintainance = db.Maintainances.Find(id);
            DoneMaintainance dm = new DoneMaintainance();
            dm.MaintainanceId = maintainance.MaintainanceId;
            dm.Comments = maintainance.Comments;
            dm.Contractor = maintainance.Contractor;
            dm.Contractor_EmailAddress = maintainance.Contractor_EmailAddress;
            dm.FixedDate = System.DateTime.Now;
            dm.Image = maintainance.Image;
            dm.ReportDate = maintainance.ReportDate;
            dm.ResName = maintainance.ResName;
            dm.Status = "Completed";
            dm.StudentEmail = maintainance.StudentEmail;
            dm.StudentNAme = maintainance.StudentNAme;
            db.DoneMaintainances.Add(dm);
            db.Maintainances.Remove(maintainance);
            db.SaveChanges();
            return RedirectToAction("Index3");
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
        public ActionResult Create([Bind(Include = "MaintainanceId,StudentNAme,ReportDate,FixedDate,Comments,Contractor,Image,ResName,Status")] Maintainance maintainance, HttpPostedFileBase file)
        {
            string currentUserId = User.Identity.GetUserName();
            var getStudent = db.Students.Where(p => p.Email == currentUserId).Select(p => p.Name).FirstOrDefault();
            var getRes = db.Students.Where(p => p.Email == currentUserId).Select(p => p.ResName).FirstOrDefault();

            if (file != null && file.ContentLength > 0)
            {
                maintainance.Image = ConvertToBytes(file);
            }
            if (ModelState.IsValid)
            {               
       
                maintainance.StudentNAme = getStudent;

                maintainance.ReportDate = DateTime.Now;
                maintainance.StudentEmail =User.Identity.GetUserName();

                maintainance.ResName = getRes;
                maintainance.Status = "Awaiting";

                db.Maintainances.Add(maintainance);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }

            return View(maintainance);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            BinaryReader reader = new BinaryReader(file.InputStream);
            return reader.ReadBytes((int)file.ContentLength);
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

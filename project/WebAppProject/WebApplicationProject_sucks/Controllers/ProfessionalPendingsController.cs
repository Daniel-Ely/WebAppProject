using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks.Controllers
{
    public class ProfessionalPendingsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: ProfessionalPendings
        public ActionResult Index()
        {
            var professionalPendings = db.ProfessionalPendings.Include(p => p.Profession).Include(p => p.User);
            return View(professionalPendings.ToList());
        }

        // GET: ProfessionalPendings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPending professionalPending = db.ProfessionalPendings.Find(id);
            if (professionalPending == null)
            {
                return HttpNotFound();
            }
            return View(professionalPending);
        }

        // GET: ProfessionalPendings/Create
        public ActionResult Create()
        {
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: ProfessionalPendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Profession_Name,Description")] ProfessionalPending professionalPending,string[] selectedOptions,HttpPostedFileBase[] applyFiles)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM relationship
                    //TODO: figure out if we need more adding (to the icollection)
                    db.PendingToCategories.Add(new PendingToCategory(professionalPending.UserName, selectedOptions[i]));
                }

                //formatting our files            
                for (int i = 0; i < applyFiles.Length; i++)
                {//converting each file to a byte array
                    MemoryStream target = new MemoryStream();
                    applyFiles[i].InputStream.CopyTo(target);
                    byte[] content=target.ToArray();
                    //TODO: check if we need more manipulation before saving the byte array                             
                    PendingFile file = new PendingFile(db.PendingFiles.Count(), content, professionalPending.UserName);
                    db.PendingFiles.Add(file);
                }

                //sealing  and adding pending-professional to the DB
                db.ProfessionalPendings.Add(professionalPending);
                db.SaveChanges();

                return RedirectToAction("../HomePage/Home");
            }

          //  ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionalPending.Profession_Name);
          //ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professionalPending.UserName);
            return View(professionalPending);

        }

        // GET: ProfessionalPendings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPending professionalPending = db.ProfessionalPendings.Find(id);
            if (professionalPending == null)
            {
                return HttpNotFound();
            }
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionalPending.Profession_Name);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professionalPending.UserName);
            return View(professionalPending);
        }

        // POST: ProfessionalPendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,Profession_Name,Description")] ProfessionalPending professionalPending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalPending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionalPending.Profession_Name);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professionalPending.UserName);
            return View(professionalPending);
        }

        // GET: ProfessionalPendings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPending professionalPending = db.ProfessionalPendings.Find(id);
            if (professionalPending == null)
            {
                return HttpNotFound();
            }
            return View(professionalPending);
        }

        // POST: ProfessionalPendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProfessionalPending professionalPending = db.ProfessionalPendings.Find(id);
            db.ProfessionalPendings.Remove(professionalPending);
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

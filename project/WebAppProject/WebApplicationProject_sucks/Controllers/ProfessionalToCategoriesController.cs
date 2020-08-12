using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks.Controllers
{
    public class ProfessionalToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: ProfessionalToCategories
        public ActionResult Index()
        {
            var professionalToCategories = db.ProfessionalToCategories.Include(p => p.Category).Include(p => p.Professional);
            return View(professionalToCategories.ToList());
        }

        // GET: ProfessionalToCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalToCategory professionalToCategory = db.ProfessionalToCategories.Find(id);
            if (professionalToCategory == null)
            {
                return HttpNotFound();
            }
            return View(professionalToCategory);
        }

        // GET: ProfessionalToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.P_UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: ProfessionalToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_UserName,CategoryName")] ProfessionalToCategory professionalToCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionalToCategories.Add(professionalToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", professionalToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.Users, "UserName", "FirstName", professionalToCategory.P_UserName);
            return View(professionalToCategory);
        }

        // GET: ProfessionalToCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalToCategory professionalToCategory = db.ProfessionalToCategories.Find(id);
            if (professionalToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", professionalToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.Users, "UserName", "FirstName", professionalToCategory.P_UserName);
            return View(professionalToCategory);
        }

        // POST: ProfessionalToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_UserName,CategoryName")] ProfessionalToCategory professionalToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", professionalToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.Users, "UserName", "FirstName", professionalToCategory.P_UserName);
            return View(professionalToCategory);
        }

        // GET: ProfessionalToCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalToCategory professionalToCategory = db.ProfessionalToCategories.Find(id);
            if (professionalToCategory == null)
            {
                return HttpNotFound();
            }
            return View(professionalToCategory);
        }

        // POST: ProfessionalToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProfessionalToCategory professionalToCategory = db.ProfessionalToCategories.Find(id);
            db.ProfessionalToCategories.Remove(professionalToCategory);
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

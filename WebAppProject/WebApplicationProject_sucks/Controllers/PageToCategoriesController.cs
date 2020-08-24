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
    public class PageToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: PageToCategories
        public ActionResult Index()
        {
            var pageToCategories = db.PageToCategories.Include(p => p.Category).Include(p => p.ProfessionalPage);
            return View(pageToCategories.ToList());
        }

        // GET: PageToCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageToCategory pageToCategory = db.PageToCategories.Find(id);
            if (pageToCategory == null)
            {
                return HttpNotFound();
            }
            return View(pageToCategory);
        }

        // GET: PageToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage");
            return View();
        }

        // POST: PageToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessionalPageID,CategoryName")] PageToCategory pageToCategory)
        {
            if (ModelState.IsValid)
            {
                db.PageToCategories.Add(pageToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pageToCategory.CategoryName);
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", pageToCategory.ProfessionalPageID);
            return View(pageToCategory);
        }

        // GET: PageToCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageToCategory pageToCategory = db.PageToCategories.Find(id);
            if (pageToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pageToCategory.CategoryName);
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", pageToCategory.ProfessionalPageID);
            return View(pageToCategory);
        }

        // POST: PageToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessionalPageID,CategoryName")] PageToCategory pageToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pageToCategory.CategoryName);
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", pageToCategory.ProfessionalPageID);
            return View(pageToCategory);
        }

        // GET: PageToCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageToCategory pageToCategory = db.PageToCategories.Find(id);
            if (pageToCategory == null)
            {
                return HttpNotFound();
            }
            return View(pageToCategory);
        }

        // POST: PageToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageToCategory pageToCategory = db.PageToCategories.Find(id);
            db.PageToCategories.Remove(pageToCategory);
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

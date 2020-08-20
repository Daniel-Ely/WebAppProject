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
    public class ProfessionToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: ProfessionToCategories
        public ActionResult Index()
        {
            var professionToCategories = db.ProfessionToCategories.Include(p => p.Category).Include(p => p.Profession);
            return View(professionToCategories.ToList());
        }

        // GET: ProfessionToCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionToCategory professionToCategory = db.ProfessionToCategories.Find(id);
            if (professionToCategory == null)
            {
                return HttpNotFound();
            }
            return View(professionToCategory);
        }

        // GET: ProfessionToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Name", "Name");
            ViewBag.ProfessionID = new SelectList(db.Professions, "Profession_Name", "Profession_Name");
            return View();
        }

        // POST: ProfessionToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,ProfessionID")] ProfessionToCategory professionToCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionToCategories.Add(professionToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Name", "Name", professionToCategory.CategoryID);
            ViewBag.ProfessionID = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionToCategory.ProfessionID);
            return View(professionToCategory);
        }

        // GET: ProfessionToCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionToCategory professionToCategory = db.ProfessionToCategories.Find(id);
            if (professionToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Name", "Name", professionToCategory.CategoryID);
            ViewBag.ProfessionID = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionToCategory.ProfessionID);
            return View(professionToCategory);
        }

        // POST: ProfessionToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,ProfessionID")] ProfessionToCategory professionToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Name", "Name", professionToCategory.CategoryID);
            ViewBag.ProfessionID = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professionToCategory.ProfessionID);
            return View(professionToCategory);
        }

        // GET: ProfessionToCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionToCategory professionToCategory = db.ProfessionToCategories.Find(id);
            if (professionToCategory == null)
            {
                return HttpNotFound();
            }
            return View(professionToCategory);
        }

        // POST: ProfessionToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProfessionToCategory professionToCategory = db.ProfessionToCategories.Find(id);
            db.ProfessionToCategories.Remove(professionToCategory);
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

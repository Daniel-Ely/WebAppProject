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
    public class PendingToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: PendingToCategories
        public ActionResult Index()
        {
            var pendingToCategories = db.PendingToCategories.Include(p => p.Category).Include(p => p.ProfessionalPending);
            return View(pendingToCategories.ToList());
        }

        // GET: PendingToCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingToCategory pendingToCategory = db.PendingToCategories.Find(id);
            if (pendingToCategory == null)
            {
                return HttpNotFound();
            }
            return View(pendingToCategory);
        }

        // GET: PendingToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.P_UserName = new SelectList(db.ProfessionalPendings, "UserName", "Profession_Name");
            return View();
        }

        // POST: PendingToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_UserName,CategoryName")] PendingToCategory pendingToCategory)
        {
            if (ModelState.IsValid)
            {
                db.PendingToCategories.Add(pendingToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pendingToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.ProfessionalPendings, "UserName", "Profession_Name", pendingToCategory.P_UserName);
            return View(pendingToCategory);
        }

        // GET: PendingToCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingToCategory pendingToCategory = db.PendingToCategories.Find(id);
            if (pendingToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pendingToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.ProfessionalPendings, "UserName", "Profession_Name", pendingToCategory.P_UserName);
            return View(pendingToCategory);
        }

        // POST: PendingToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_UserName,CategoryName")] PendingToCategory pendingToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pendingToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", pendingToCategory.CategoryName);
            ViewBag.P_UserName = new SelectList(db.ProfessionalPendings, "UserName", "Profession_Name", pendingToCategory.P_UserName);
            return View(pendingToCategory);
        }

        // GET: PendingToCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingToCategory pendingToCategory = db.PendingToCategories.Find(id);
            if (pendingToCategory == null)
            {
                return HttpNotFound();
            }
            return View(pendingToCategory);
        }

        // POST: PendingToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PendingToCategory pendingToCategory = db.PendingToCategories.Find(id);
            db.PendingToCategories.Remove(pendingToCategory);
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

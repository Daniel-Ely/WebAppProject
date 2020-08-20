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
    public class UserToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: UserToCategories
        public ActionResult Index()
        {
            var userToCategories = db.UserToCategories.Include(u => u.Category).Include(u => u.User);
            return View(userToCategories.ToList());
        }

        // GET: UserToCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToCategory userToCategory = db.UserToCategories.Find(id);
            if (userToCategory == null)
            {
                return HttpNotFound();
            }
            return View(userToCategory);
        }

        // GET: UserToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: UserToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,CategoryName")] UserToCategory userToCategory)
        {
            if (ModelState.IsValid)
            {
                db.UserToCategories.Add(userToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", userToCategory.CategoryName);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToCategory.UserName);
            return View(userToCategory);
        }

        // GET: UserToCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToCategory userToCategory = db.UserToCategories.Find(id);
            if (userToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", userToCategory.CategoryName);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToCategory.UserName);
            return View(userToCategory);
        }

        // POST: UserToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,CategoryName")] UserToCategory userToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", userToCategory.CategoryName);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToCategory.UserName);
            return View(userToCategory);
        }

        // GET: UserToCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToCategory userToCategory = db.UserToCategories.Find(id);
            if (userToCategory == null)
            {
                return HttpNotFound();
            }
            return View(userToCategory);
        }

        // POST: UserToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserToCategory userToCategory = db.UserToCategories.Find(id);
            db.UserToCategories.Remove(userToCategory);
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

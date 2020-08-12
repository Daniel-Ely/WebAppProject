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
    public class PostToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: PostToCategories
        public ActionResult Index()
        {
            var postToCategories = db.PostToCategories.Include(p => p.Category).Include(p => p.Post);
            return View(postToCategories.ToList());
        }

        // GET: PostToCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostToCategory postToCategory = db.PostToCategories.Find(id);
            if (postToCategory == null)
            {
                return HttpNotFound();
            }
            return View(postToCategory);
        }

        // GET: PostToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title");
            return View();
        }

        // POST: PostToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,CategoryName")] PostToCategory postToCategory)
        {
            if (ModelState.IsValid)
            {
                db.PostToCategories.Add(postToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", postToCategory.CategoryName);
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", postToCategory.PostID);
            return View(postToCategory);
        }

        // GET: PostToCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostToCategory postToCategory = db.PostToCategories.Find(id);
            if (postToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", postToCategory.CategoryName);
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", postToCategory.PostID);
            return View(postToCategory);
        }

        // POST: PostToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,CategoryName")] PostToCategory postToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", postToCategory.CategoryName);
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", postToCategory.PostID);
            return View(postToCategory);
        }

        // GET: PostToCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostToCategory postToCategory = db.PostToCategories.Find(id);
            if (postToCategory == null)
            {
                return HttpNotFound();
            }
            return View(postToCategory);
        }

        // POST: PostToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostToCategory postToCategory = db.PostToCategories.Find(id);
            db.PostToCategories.Remove(postToCategory);
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

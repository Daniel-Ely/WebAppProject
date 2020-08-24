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
    public class UserToPostRatingsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: UserToPostRatings
        public ActionResult Index()
        {
            var userToPostRatings = db.UserToPostRatings.Include(u => u.Post).Include(u => u.User);
            return View(userToPostRatings.ToList());
        }

        // GET: UserToPostRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToPostRating userToPostRating = db.UserToPostRatings.Find(id);
            if (userToPostRating == null)
            {
                return HttpNotFound();
            }
            return View(userToPostRating);
        }

        // GET: UserToPostRatings/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(db.Posts, "PostID", "Title");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: UserToPostRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,UserName,Rating")] UserToPostRating userToPostRating)
        {
            if (ModelState.IsValid)
            {
                db.UserToPostRatings.Add(userToPostRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Posts, "PostID", "Title", userToPostRating.PostId);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToPostRating.UserName);
            return View(userToPostRating);
        }

        // GET: UserToPostRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToPostRating userToPostRating = db.UserToPostRatings.Find(id);
            if (userToPostRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "PostID", "Title", userToPostRating.PostId);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToPostRating.UserName);
            return View(userToPostRating);
        }

        // POST: UserToPostRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,UserName,Rating")] UserToPostRating userToPostRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userToPostRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "PostID", "Title", userToPostRating.PostId);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", userToPostRating.UserName);
            return View(userToPostRating);
        }

        // GET: UserToPostRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToPostRating userToPostRating = db.UserToPostRatings.Find(id);
            if (userToPostRating == null)
            {
                return HttpNotFound();
            }
            return View(userToPostRating);
        }

        // POST: UserToPostRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserToPostRating userToPostRating = db.UserToPostRatings.Find(id);
            db.UserToPostRatings.Remove(userToPostRating);
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

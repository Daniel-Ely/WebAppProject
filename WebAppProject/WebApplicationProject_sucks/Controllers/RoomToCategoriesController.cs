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
    public class RoomToCategoriesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: RoomToCategories
        public ActionResult Index()
        {
            var roomToCategories = db.RoomToCategories.Include(r => r.Category).Include(r => r.QuestionRoom);
            return View(roomToCategories.ToList());
        }

        // GET: RoomToCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomToCategory roomToCategory = db.RoomToCategories.Find(id);
            if (roomToCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomToCategory);
        }

        // GET: RoomToCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name");
            ViewBag.QuestionRoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title");
            return View();
        }

        // POST: RoomToCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionRoomID,CategoryName")] RoomToCategory roomToCategory)
        {
            if (ModelState.IsValid)
            {
                db.RoomToCategories.Add(roomToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", roomToCategory.CategoryName);
            ViewBag.QuestionRoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title", roomToCategory.QuestionRoomID);
            return View(roomToCategory);
        }

        // GET: RoomToCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomToCategory roomToCategory = db.RoomToCategories.Find(id);
            if (roomToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", roomToCategory.CategoryName);
            ViewBag.QuestionRoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title", roomToCategory.QuestionRoomID);
            return View(roomToCategory);
        }

        // POST: RoomToCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionRoomID,CategoryName")] RoomToCategory roomToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "Name", "Name", roomToCategory.CategoryName);
            ViewBag.QuestionRoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title", roomToCategory.QuestionRoomID);
            return View(roomToCategory);
        }

        // GET: RoomToCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomToCategory roomToCategory = db.RoomToCategories.Find(id);
            if (roomToCategory == null)
            {
                return HttpNotFound();
            }
            return View(roomToCategory);
        }

        // POST: RoomToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomToCategory roomToCategory = db.RoomToCategories.Find(id);
            db.RoomToCategories.Remove(roomToCategory);
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

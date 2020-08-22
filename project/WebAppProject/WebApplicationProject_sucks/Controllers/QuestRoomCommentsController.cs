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
    public class QuestRoomCommentsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: QuestRoomComments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(q => q.QuestionRoom).Include(q => q.User);
            return View(comments.ToList());
        }

        // GET: QuestRoomComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestRoomComment questRoomComment = db.Comments.Find(id);
            if (questRoomComment == null)
            {
                return HttpNotFound();
            }
            return View(questRoomComment);
        }

        // GET: QuestRoomComments/Create
        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: QuestRoomComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestCommentID,RoomID,UserName,Date,Content")] QuestRoomComment questRoomComment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(questRoomComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

       
            return View(questRoomComment);
        }

        // GET: QuestRoomComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestRoomComment questRoomComment = db.Comments.Find(id);
            if (questRoomComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title", questRoomComment.RoomID);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", questRoomComment.UserName);
            return View(questRoomComment);
        }

        // POST: QuestRoomComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestCommentID,RoomID,UserName,Date")] QuestRoomComment questRoomComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questRoomComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.QuestionRooms, "QuestionRoomID", "Title", questRoomComment.RoomID);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", questRoomComment.UserName);
            return View(questRoomComment);
        }

        // GET: QuestRoomComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestRoomComment questRoomComment = db.Comments.Find(id);
            if (questRoomComment == null)
            {
                return HttpNotFound();
            }
            return View(questRoomComment);
        }

        // POST: QuestRoomComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestRoomComment questRoomComment = db.Comments.Find(id);
            db.Comments.Remove(questRoomComment);
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

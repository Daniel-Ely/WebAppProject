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
    public class QuestionRoomsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: QuestionRooms
        public ActionResult Index()
        {
            return View(db.QuestionRooms.ToList());
        }

        public ActionResult FromHome()
        {
            Session["Cancel"] = "/HomePage/Home";
            return Redirect("/QuestionRooms/Create");
        }

        // GET: QuestionRooms/Details/5
        [UserActivityFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionRoom questionRoom = db.QuestionRooms.Find(id);
            if (questionRoom == null)
            {
                return HttpNotFound();
            }
            return View(questionRoom);
        }

        // GET: QuestionRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,CreatorName")] QuestionRoom questionRoom, string[] selectedOptions)
        {

            if (ModelState.IsValid)
            {
                questionRoom.QuestionRoomID = db.QuestionRooms.Count();
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM of category-room relationship 

                    db.RoomToCategories.Add(new RoomToCategory(questionRoom.QuestionRoomID, selectedOptions[i]));
                }

                questionRoom.DatePublished = DateTime.Today;
                db.QuestionRooms.Add(questionRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionRoom);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(string RoomID, string CommentContent, string CommentCreator)
        {
            if (CommentContent != null)
            {
                int commentID = db.QustionRoomComments.Count();
                QuestRoomComment comment = new QuestRoomComment(commentID, Int32.Parse(RoomID), CommentContent, CommentCreator, DateTime.Today.Date);
                db.QustionRoomComments.Add(comment);
                db.SaveChanges();
            }

            return Redirect("../QuestionRooms/Details/" + Int32.Parse(RoomID));

        }


        // GET: QuestionRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionRoom questionRoom = db.QuestionRooms.Find(id);
            if (questionRoom == null)
            {
                return HttpNotFound();
            }
            return View(questionRoom);
        }

        // POST: QuestionRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionRoomID,Title,CreatorName")] QuestionRoom questionRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionRoom);
        }

        // GET: QuestionRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionRoom questionRoom = db.QuestionRooms.Find(id);
            if (questionRoom == null)
            {
                return HttpNotFound();
            }
            return View(questionRoom);
        }

        // POST: QuestionRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionRoom questionRoom = db.QuestionRooms.Find(id);
            db.QuestionRooms.Remove(questionRoom);
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

        public ActionResult DeleteQR([Bind(Include = "QuestionRoomID")] QuestionRoom qr)
        {
            MyDB db = new MyDB();
            if (qr.QuestionRoomID == 0)
                return Redirect("/QuestionRooms/Index");
            foreach (var item in db.QustionRoomComments.Where(d => d.RoomID == qr.QuestionRoomID).ToList())
            {
                db.QustionRoomComments.Remove(item);
            }
            QuestionRoom qR = db.QuestionRooms.Find(qr.QuestionRoomID);
            db.QuestionRooms.Remove(qR);
            db.SaveChanges();
            return Redirect("/QuestionRooms/Index");

        }
        public ActionResult Cancel()
        {
            if (Session["Cancel"] != null)
            {
                Session["Cancel"] = null;
                 return Redirect("/HomePage/Home");
            }
           
            return Redirect("/QuestionRooms/Index");
        }
    }
}


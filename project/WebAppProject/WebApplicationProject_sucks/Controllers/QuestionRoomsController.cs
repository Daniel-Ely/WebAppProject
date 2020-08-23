﻿using System;
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
        
        // GET: QuestionRooms/Details/5
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
        public ActionResult Create([Bind(Include = "Title,CreatorName")] QuestionRoom questionRoom,string[]selectedOptions)
        {
   
            if (ModelState.IsValid)
            {
                questionRoom.QuestionRoomID = db.QuestionRooms.Count();
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM of category-room relationship 
                    
                    db.RoomToCategories.Add(new RoomToCategory(questionRoom.QuestionRoomID, selectedOptions[i]));
                }


                db.QuestionRooms.Add(questionRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionRoom);
        }

        public ActionResult CreateComment(int QuestionRoomID,string CommentContent,string CommentCreator)
        {
            int commentID = db.Comments.Count();
            QuestRoomComment comment = new QuestRoomComment(commentID,QuestionRoomID,CommentContent,CommentCreator, DateTime.Today);
            db.Comments.Add(comment);
            db.SaveChanges();

            return View();

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
    }
}

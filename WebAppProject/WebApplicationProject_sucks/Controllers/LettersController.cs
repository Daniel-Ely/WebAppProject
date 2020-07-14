using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks;

namespace WebApplicationProject_sucks.Controllers
{
    public class LettersController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Letters
        public ActionResult Index()
        {
            return View(db.Letter.ToList());
        }

        // GET: Letters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letter.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // GET: Letters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LetterID,Color,Size,Font")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                db.Letter.Add(letter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(letter);
        }

        // GET: Letters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letter.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LetterID,Color,Size,Font")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(letter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(letter);
        }

        // GET: Letters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letter.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Letter letter = db.Letter.Find(id);
            db.Letter.Remove(letter);
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

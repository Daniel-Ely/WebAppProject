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
    public class ClipsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Clips
        public ActionResult Index()
        {
            return View(db.Clip.ToList());
        }

        // GET: Clips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clip clip = db.Clip.Find(id);
            if (clip == null)
            {
                return HttpNotFound();
            }
            return View(clip);
        }

        // GET: Clips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClipID,Size,Path")] Clip clip)
        {
            if (ModelState.IsValid)
            {
                db.Clip.Add(clip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clip);
        }

        // GET: Clips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clip clip = db.Clip.Find(id);
            if (clip == null)
            {
                return HttpNotFound();
            }
            return View(clip);
        }

        // POST: Clips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClipID,Size,Path")] Clip clip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clip);
        }

        // GET: Clips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clip clip = db.Clip.Find(id);
            if (clip == null)
            {
                return HttpNotFound();
            }
            return View(clip);
        }

        // POST: Clips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clip clip = db.Clip.Find(id);
            db.Clip.Remove(clip);
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

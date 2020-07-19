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
    public class HTMLScriptsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: HTMLScripts
        public ActionResult Index()
        {
            return View(db.HTMLScripts.ToList());
        }

        // GET: HTMLScripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HTMLScript hTMLScript = db.HTMLScripts.Find(id);
            if (hTMLScript == null)
            {
                return HttpNotFound();
            }
            return View(hTMLScript);
        }

        // GET: HTMLScripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HTMLScripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HTMLScriptID,Content")] HTMLScript hTMLScript)
        {
            if (ModelState.IsValid)
            {
                db.HTMLScripts.Add(hTMLScript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hTMLScript);
        }

        // GET: HTMLScripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HTMLScript hTMLScript = db.HTMLScripts.Find(id);
            if (hTMLScript == null)
            {
                return HttpNotFound();
            }
            return View(hTMLScript);
        }

        // POST: HTMLScripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HTMLScriptID,Content")] HTMLScript hTMLScript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hTMLScript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hTMLScript);
        }

        // GET: HTMLScripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HTMLScript hTMLScript = db.HTMLScripts.Find(id);
            if (hTMLScript == null)
            {
                return HttpNotFound();
            }
            return View(hTMLScript);
        }

        // POST: HTMLScripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HTMLScript hTMLScript = db.HTMLScripts.Find(id);
            db.HTMLScripts.Remove(hTMLScript);
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

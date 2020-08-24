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
    public class ProfessionalsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Professionals
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Professionals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = (Professional)db.Users.Find(id);
            if (professional == null)
            {
                return HttpNotFound();
            }
            return View(professional);
        }

        // GET: Professionals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,FirstName,Gender,BirthDay,Email,Password,Description,Score")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(professional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professional);
        }

        // GET: Professionals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = (Professional)db.Users.Find(id);
            if (professional == null)
            {
                return HttpNotFound();
            }
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,FirstName,Gender,BirthDay,Email,Password,Description,Score")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professional);
        }

        // GET: Professionals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = (Professional)db.Users.Find(id);
            if (professional == null)
            {
                return HttpNotFound();
            }
            return View(professional);
        }

        // POST: Professionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Professional professional = (Professional)db.Users.Find(id);
            db.Users.Remove(professional);
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

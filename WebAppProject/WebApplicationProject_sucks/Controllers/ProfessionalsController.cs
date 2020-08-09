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
            var professionals = db.Professionals.Include(p => p.Profession).Include(p => p.User);
            return View(professionals.ToList());
        }

        // GET: Professionals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = db.Professionals.Find(id);
            if (professional == null)
            {
                return HttpNotFound();
            }
            return View(professional);
        }

        // GET: Professionals/Create
        public ActionResult Create()
        {
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name");
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: Professionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Profession_Name,Description,Score")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                db.Professionals.Add(professional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professional.Profession_Name);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professional.UserName);
            return View(professional);
        }

        // GET: Professionals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = db.Professionals.Find(id);
            if (professional == null)
            {
                return HttpNotFound();
            }
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professional.Profession_Name);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professional.UserName);
            return View(professional);
        }

        // POST: Professionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,Profession_Name,Description,Score")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Profession_Name = new SelectList(db.Professions, "Profession_Name", "Profession_Name", professional.Profession_Name);
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professional.UserName);
            return View(professional);
        }

        // GET: Professionals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professional professional = db.Professionals.Find(id);
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
            Professional professional = db.Professionals.Find(id);
            db.Professionals.Remove(professional);
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

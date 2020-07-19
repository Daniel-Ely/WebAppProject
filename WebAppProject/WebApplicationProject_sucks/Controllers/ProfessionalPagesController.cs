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
    public class ProfessionalPagesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: ProfessionalPages
        public ActionResult Index()
        {
            return View(db.ProfessionalPages.ToList());
        }

        // GET: ProfessionalPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPage professionalPage = db.ProfessionalPages.Find(id);
            if (professionalPage == null)
            {
                return HttpNotFound();
            }
            return View(professionalPage);
        }

        // GET: ProfessionalPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessionalPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProffesionalPageID,NameOfPage,UserName")] ProfessionalPage professionalPage)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionalPages.Add(professionalPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professionalPage);
        }

        // GET: ProfessionalPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPage professionalPage = db.ProfessionalPages.Find(id);
            if (professionalPage == null)
            {
                return HttpNotFound();
            }
            return View(professionalPage);
        }

        // POST: ProfessionalPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProffesionalPageID,NameOfPage,UserName")] ProfessionalPage professionalPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professionalPage);
        }

        // GET: ProfessionalPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionalPage professionalPage = db.ProfessionalPages.Find(id);
            if (professionalPage == null)
            {
                return HttpNotFound();
            }
            return View(professionalPage);
        }

        // POST: ProfessionalPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessionalPage professionalPage = db.ProfessionalPages.Find(id);
            db.ProfessionalPages.Remove(professionalPage);
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

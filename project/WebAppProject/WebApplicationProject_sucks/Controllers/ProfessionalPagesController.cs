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
    public class ProfessionalPagesController : Controller
    {
        private MyDB db = new MyDB();

        // GET: ProfessionalPages
        public ActionResult Index()
        {
            var professionalPages = db.ProfessionalPages.Include(p => p.User);
            return View(professionalPages.ToList());
        }

        public ActionResult FromHome()
        {
            Session["Cancel"] = "/HomePage/Home";
            return Redirect("/ProfessionalPages/Create");
        }
        public ActionResult Cancel()
        {

            if (Session["Cancel"] != null)
            {
                Session["Cancel"] = null;
                return Redirect("/HomePage/Home");

            }
            else if (Session["FromMy"] != null)
            {
                if (Session["FromMy"].ToString() == "true")
                {
                    Session["FromMy"] = null;
                    return Redirect("/Shared/MyProfessionalPages");
                }
                else
                {
                    return Redirect("/ProfessionalPages/Index");
                }
            }
            else
            {
                return Redirect("/ProfessionalPages/Index");
            }
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
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName");
            return View();
        }

        // POST: ProfessionalPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessionalPageID,NameOfPage,UserName")] ProfessionalPage professionalPage, string[] selectedOptions)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionalPages.Add(professionalPage);
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM relationship
                    db.PageToCategories.Add(new PageToCategory(professionalPage.ProfessionalPageID, selectedOptions[i]));
                }
                db.SaveChanges();
                if (Session["FromMy"] != null)
                    if (Session["FromMy"].ToString() == "true")
                        return Redirect("/Shared/MyProfessionalPages");
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professionalPage.UserName);
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
            ViewBag.UserName = new SelectList(db.Users, "UserName", "FirstName", professionalPage.UserName);
            return View(professionalPage);
        }

        // POST: ProfessionalPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessionalPageID,NameOfPage")] ProfessionalPage professionalPage)
        {
            if (ModelState.IsValid)
            {
                ProfessionalPage p = db.ProfessionalPages.Where(d => d.ProfessionalPageID == professionalPage.ProfessionalPageID).ToList().ElementAt(0);
                p.NameOfPage = professionalPage.NameOfPage;
                db.SaveChanges();
                return RedirectToAction("Details/" + professionalPage.ProfessionalPageID);
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
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost([Bind(Include = "PostID,ProfessionalPageID")] Post p)
        {
            MyDB db = new MyDB();
            if (p.PostID == 0 || p.ProfessionalPageID == 0)
                return Redirect("../ProfessionalPages/Edit/" + p.ProfessionalPageID);
            foreach (var item in db.PostComments.Where(d => d.PostID == p.PostID).ToList())
            {
                var controller = DependencyResolver.Current.GetService<PostsController>();
                controller.DeleteComments(item);
            }
            foreach (var item in db.UserToPostRatings.Where(d => d.PostId == p.PostID).ToList())
            {
                db.UserToPostRatings.Remove(item);
            }
            Post post = db.Posts.Find(p.PostID);
            db.Posts.Remove(post);
            db.SaveChanges();
            return Redirect("../ProfessionalPages/Delete/" + p.ProfessionalPageID);

        }
        public ActionResult Search(string search)
        {
            Session["ListAfterSearchPP"] = db.ProfessionalPages.Where(d => d.NameOfPage.Contains(search)).ToList();
            return View();

        }
        public ActionResult SearchResualt()
        {
            return View("Search");
        }
    }
}

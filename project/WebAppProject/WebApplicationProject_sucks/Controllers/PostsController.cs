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
    public class PostsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.ProfessionalPage);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Date,Rating,NumOfRating,Description,PageID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("../../View/ProfessionalPages/Details");
            }

           return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", post.PageID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Date,Rating,NumOfRating,Description,PageID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", post.PageID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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



      /*  [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRating(string userName, int PostId, int Rating)
        {
            UserToPostRating rate = new UserToPostRating(userName, PostId, Rating);
            db.UserToPostRatings.Add(rate);
            db.SaveChanges();
            Post post = db.Posts.Where(d => d.PostID == PostId).ToList().ElementAt(0);
            post.NumOfRating += 1;
            db.SaveChanges();
            int sum = 0;
            foreach (var item in db.UserToPostRatings.Where(d => d.PostId == PostId).ToList())
                sum += item.Rating;
            post.Rating = sum / post.NumOfRating;
            db.SaveChanges();
            return Redirect("../Posts/Details/" + PostId);
        }*/
       

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(string PostID, string CommentContent, string CommentCreator)
        {
            int commentID = db.PostComments.Count();
            PostComment comment = new PostComment(commentID, Int32.Parse(PostID), CommentContent, CommentCreator, DateTime.Today);
            db.PostComments.Add(comment);
            db.SaveChanges();

            return Redirect("../Posts/Details/" + Int32.Parse(PostID));
        }
    }
}

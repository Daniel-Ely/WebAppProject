using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        public ActionResult Create([Bind(Include = "Title,Content,Description,ProfessionalPageID")] Post post, string[] selectedOptions)
        {
            if (ModelState.IsValid)
            {
                post.Date = DateTime.Today;
                db.Posts.Add(post);
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM relationship
                    db.PostToCategories.Add(new PostToCategory(post.PostID, selectedOptions[i]));
                }
                
                db.SaveChanges();
                return RedirectToAction("../ProfessionalPages/Details/"+post.ProfessionalPageID);
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
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProfessionalPageID", "NameOfPage", post.ProfessionalPageID);
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
            ViewBag.ProfessionalPageID = new SelectList(db.ProfessionalPages, "ProfessionalPageID", "NameOfPage", post.ProfessionalPageID);
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



      [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRating( [Bind(Include = "Rating,UserName,PostId")] UserToPostRating uTPR)
        {
            
            db.UserToPostRatings.Add(uTPR);
            db.SaveChanges();
            Post post = db.Posts.Where(d => d.PostID == uTPR.PostId).ToList().ElementAt(0);
            post.NumOfRating += 1;
            db.SaveChanges();
            int sum = 0;
            foreach (var item in db.UserToPostRatings.Where(d => d.PostId == uTPR.PostId).ToList())
                sum += item.Rating;
            post.Rating = sum / post.NumOfRating;
            db.SaveChanges();
            return Redirect("../Posts/Details/" + uTPR.PostId);
        }
       

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "PostID,PostCommentContent,UserName")] PostComment pC)
        {
            pC.Date = DateTime.Today;
            db.PostComments.Add(pC);
            db.SaveChanges();
            Session["PostCommentContent"] = null;
            return Redirect("../Posts/Details/" + pC.PostID);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCommentOrRate([Bind(Include = "PostID,PostCommentContent,UserName")] PostComment pC, [Bind(Include = "Rating,UserName,PostId")] UserToPostRating uTPR)
        {
            if (pC.PostID.ToString() != null && pC.PostCommentContent != null && pC.UserName != null)
               return CreateComment(pC);
            else
               return CreateRating(uTPR);
        }



       public FileContentResult ShowImage(string UserName)
       {
            byte[] image = db.Users.Where(d => d.UserName == UserName).ToList().ElementAt(0).ProfileImage;
            if (image == null)
            {
                image=System.IO.File.ReadAllBytes(Server.MapPath("../src/Owl.jpg"));               
            }           
                return File(image, "image/jpg");
            
        }
        
    }
}

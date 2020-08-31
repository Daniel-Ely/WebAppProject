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
    public class ProfileOfCreator
    {
        public int PostID { set; get; }
        public int ProfessionalPageID { set; get; }
        public string ProfessionalPageName { set; get; }
        public string FirstName { set; get; }
        public string UserName { set; get; }
        public byte[] ProfileImg { set; get; }


    }
    public class PostsController : Controller
    {
        private MyDB db = new MyDB();

        

        public void Profileofcreator()
        {
            IEnumerable<ProfileOfCreator> profileOfCreator;
            MyDB db = new MyDB();
            var users = db.Users.ToList();
            var professionalpages = db.ProfessionalPages.ToList();
            var posts = db.Posts.ToList();
            profileOfCreator = from post in posts
                               join pp in professionalpages on post.ProfessionalPageID equals pp.ProfessionalPageID into table1
                               from pp in table1.DefaultIfEmpty()
                               join user in users on pp.UserName equals user.UserName into table2
                               from user in table2.DefaultIfEmpty()
                               select new ProfileOfCreator
                               {
                                   PostID = post.PostID,
                                   ProfessionalPageID=pp.ProfessionalPageID,
                                   ProfessionalPageName=pp.NameOfPage,
                                   FirstName=user.FirstName,
                                   UserName=user.UserName,
                                   ProfileImg=user.ProfileImage
                           };
            ViewData["Profileofcreator"]= profileOfCreator.AsQueryable().ToList();


        }
        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.ProfessionalPage);
            return View(posts.ToList());
        }

        public ActionResult DeleteComments()
        {
            return View();
        }
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            Profileofcreator();
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
        public ActionResult Edit([Bind(Include = "PostID,Title,Description,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                Post p = db.Posts.Where(d => d.PostID == post.PostID).ToList().ElementAt(0);
                p.Title = post.Title;
                p.Description = post.Description;
                p.Content = post.Content;
                db.SaveChanges();
                return RedirectToAction("Details/" + post.PostID);
            }

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
            string postCreator = db.ProfessionalPages.Where(d => d.ProfessionalPageID == post.ProfessionalPageID).ToList().ElementAt(0).UserName;
            Professional pro = db.Professionals.Where(d => d.UserName == postCreator).ToList().ElementAt(0);
            var listOfPP = db.ProfessionalPages.Where(d => d.UserName == pro.UserName).ToList();
            double score=0;
            int sumOfPosts = 0;
            foreach(var pp in listOfPP)
            {
                foreach(var p in pp.Posts.ToList())
                {
                    sumOfPosts++;
                    score += p.Rating;
                }
            }
            pro.Score = score / sumOfPosts;
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
            if (pC.PostCommentContent != null)
                return CreateComment(pC);
            else if (uTPR.Rating.ToString() != null)
                return CreateRating(uTPR);
            else return Redirect("../Posts/Details/" + pC.PostID);
        }



       public FileContentResult ShowImage(string UserName)
       {
            byte[] image = db.Users.Where(d => d.UserName == UserName).ToList().ElementAt(0).ProfileImage;
            if (image == null)
            {
                image=System.IO.File.ReadAllBytes(Server.MapPath("../src/Owl.png"));               
            }           
                return File(image, "image/jpg");
            
        }

        public ActionResult DeleteComment([Bind(Include = "PostID,PostCommentID")] PostComment pC)
        {
            MyDB db = new MyDB();
            if (pC.PostCommentID == 0 || pC.PostID == 0)
                return Redirect("../Posts/Edit/" + pC.PostID);
            PostComment postC = db.PostComments.Find(pC.PostCommentID);
            db.PostComments.Remove(postC);
            db.SaveChanges();
            return Redirect("../Posts/Edit/" + pC.PostID);
           
        }


    }
}

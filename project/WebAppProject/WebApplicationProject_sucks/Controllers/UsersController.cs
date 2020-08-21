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
    public class UsersController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        
        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //this is going to take the boolean attribute as well since it matches with its name 
        //JS is going to execute accordingly before this action takes place.
        public ActionResult Create([Bind(Include = "UserName,FirstName,Gender,BirthDay,Email,Password")] User user,string isProfessional, string[] selectedOptions)
        {
   
            if (ModelState.IsValid)
            {//we just want to save the entry to the DB in both cases.  Process is the same 
                db.Users.Add(user);
                for (int i=0;i<selectedOptions.Length;i++)
                {//MtM relationship
                    db.UserToCategories.Add(new UserToCategory(user.UserName, selectedOptions[i]));
                }
                db.SaveChanges();


                if (isProfessional == "1")
                {
                    Session["UserName"] = user.UserName;//saves the user name for context
                    return View("../ProfessionalPendings/Create");//refer to the the additional               
                }

                else
                {
                    return RedirectToAction("Index");
                }

            }
            
            return View(user);
        }
        public ActionResult LogIn(string username,string password)
        {
            foreach (var user in db.Users)
            {
                if(user.UserName==username && user.Password==password)
                {//successful login
                    Session["UserName"] = username;
                   return Redirect("../Controllers/HomePage/Home");
                }
                else
                {//login failed
                 
                 //ModelState.AddModelError("password", "The user name or password provided is incorrect.");
                }
                
            }

            return View();
        }



  
        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,FirstName,Gender,BirthDay,Email,Password,isProfessional")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

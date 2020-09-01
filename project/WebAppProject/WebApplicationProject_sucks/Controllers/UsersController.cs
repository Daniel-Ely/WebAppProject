using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks;
using WebApplicationProject_sucks.Models;



namespace WebApplicationProject_sucks.Controllers
{
    public class UsersController : Controller
    {
        private static int MaxCategories = 10;
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

        public ActionResult ShowMap()
        {
            return View("../Admin/Map");
        }


        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //this is going to take the boolean attribute as well since it matches with its name 
        //JS is going to execute accordingly before this action takes place.
        public ActionResult Create([Bind(Include = "UserName,FirstName,Gender,BirthDay,Email,Password")] User user,string isProfessional, string[] selectedOptions, HttpPostedFileBase ProfileImage)
        {           
            if ((ModelState.IsValid)&&(selectedOptions!=null)&& (db.Users.Where(d=>d.UserName==user.UserName).Count()==0))
            {//we just want to save the entry to the DB in both cases.  Process is the same 
                byte[] salt = getSalt();
                user.salt = salt;
                user.Password = Convert.ToBase64String(GenerateSaltedHash(Encoding.ASCII.GetBytes(user.Password), salt));
                db.Users.Add(user);

                if (selectedOptions.Length > MaxCategories) // in case the user choose to much categories of intrest 
                {
                    return View(user);
                }

                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM relationship
                    db.UserToCategories.Add(new UserToCategory(user.UserName, selectedOptions[i]));
                }

                //converting each file to a byte array
                if (ProfileImage != null)
                {
                    MemoryStream target = new MemoryStream();
                    ProfileImage.InputStream.CopyTo(target);
                    byte[] content = target.ToArray();
                    user.ProfileImage = content;
                }
                db.SaveChanges();


                if (isProfessional == "1")
                {
                    Session["UserName"] = user.UserName;//saves the user name for context                   
                    return View("../ProfessionalPendings/Create");//refer to the the additional               
                }

                return RedirectToAction("../HomePage/Home");

            }
            
            return View(user);
        }
        public ActionResult LogIn(string username,string password)
        {
            if(username==null && password==null) return View();
            foreach (var user in db.Users)
            {
                string Submitedpassword = Convert.ToBase64String(GenerateSaltedHash(Encoding.ASCII.GetBytes(password), user.salt));
                if (user.UserName==username && Submitedpassword == user.Password)
                {//successful login
                    Session["UserName"] = username;
                    Session.Timeout = 10;//in minutues 
                    if (db.Users.Where(d => d.UserName == username).ToList().ElementAt(0).isAdmin)
                        return Redirect("../HomePage/ChoiseBetweenAdminToUser");
                    return Redirect("../HomePage/Home");
                }              
            }
            //login failed
            ViewBag.ErrorMessage = "The user name or password provided is incorrect.";
            //ModelState.AddModelError("", "The user name or password provided is incorrect.");


            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return Redirect("../HomePage/Home");
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
        //increase in 1 the NumOfVisits and updateds the LastTouched date
        public void categoryWasViewd(string CategoryName , string userName)
        {
            UserToCategory userCategory = db.UserToCategories.Where(d=> d.CategoryName == CategoryName && d.UserName == userName).ToList().ElementAt(0);
            userCategory.NumOfVisits++;
            userCategory.LastTouched = DateTime.Today;
            db.SaveChanges();
        }
        //
        public void newCategoryWasViewd(string categoryName , string userName)
        {
            db.UserToCategories.Add(new UserToCategory(userName, categoryName ,1));
            db.SaveChanges();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //
        //password mangmand methods
        //
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        private static byte[] getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            var max_length = 32;

            // Empty salt array
            var salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return salt;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks.Models;


namespace WebApplicationProject_sucks.Controllers
{
    public class AllContent
    {
        public string CreatorName { set; get; }
        public int AllContentID{set;get;}
        public string Title { set; get; }
        public string Content { set; get; }
        public DateTime Date { set; get; }
        public byte[] Img { set; get;}
        public virtual ICollection<RoomToCategory> QCategories { get; set; }
        public virtual ICollection<PostToCategory> PCategories { get; set; }

    }
    public class HomePageController : Controller
    {
        MyDB db = new MyDB();
        // GET: HomePage
        // [LogInFilter]
        public ActionResult Home()
        {
            if(ViewData["ContentList"] == null )
            {
                FilterdSearch("all" , "all" , "all");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult SearchPage()
        {
            return View();
        }
        public ActionResult FirstTimeInThisSystem()
        {
            return View();
        }
        public ActionResult ChoiseBetweenAdminToUser()
        {
            return View();
        }
        public ActionResult Choise()
        {
            if (Session["User"].ToString() == "true")
                return Redirect("../HomePage/Home");
            return Redirect("../HomePage/AdminHome");
        }



        public ActionResult FilterdSearch(string categoryName, string contentType , string creatorName)
        {
            List<AllContent> allContent = new List<AllContent>();
       
            //in case the user didnt choose to filter by ContentType(Post/ Question rom)
            if (contentType == "all" || contentType=="")
            {
                allContent = db.QuestionRooms.AsEnumerable().OrderBy(q => q.DatePublished).Select(q => new AllContent
                {
                    Title = "Question room",
                    Content = q.Title,
                    Date = q.DatePublished,
                    QCategories = q.Categories,
                    PCategories = new List<PostToCategory>(),
                    AllContentID = q.QuestionRoomID,
                    CreatorName=q.CreatorName
                }).Union(db.Posts.AsEnumerable().OrderBy(p => p.Date).Select(p => new AllContent
                {
                    Title = p.Title,
                    Content = p.Description,
                    Date = p.Date,
                    QCategories = new List<RoomToCategory>(),
                    PCategories = p.Categories,
                    Img = p.Thumbnail,
                    CreatorName = (db.ProfessionalPages.Where(p1 => p1.ProfessionalPageID == p.ProfessionalPageID)).ToArray()[0].UserName,
                    AllContentID = p.PostID
                })).ToList();

            }
            else if (contentType == "Question-rooms") // in Case the user choose ONLY question rooms
            {
                allContent = db.QuestionRooms.AsEnumerable().OrderBy(q => q.DatePublished).Select(q => new AllContent
                {
                    Title = "Question room",
                    Content = q.Title,
                    Date = q.DatePublished,
                    QCategories = q.Categories,
                    PCategories = new List<PostToCategory>(),
                    CreatorName = q.CreatorName,
                    AllContentID = q.QuestionRoomID
                }).ToList();
            }
            else // in case the user choose ONLY posts
            {
                allContent = db.Posts.AsEnumerable().OrderBy(p => p.Date).Select(p => new AllContent
                {
                    Title = p.Title,
                    Content = p.Description,
                    Date = p.Date,
                    QCategories = new List<RoomToCategory>(),
                    PCategories = p.Categories,
                    Img = p.Thumbnail,
                    CreatorName = db.ProfessionalPages.Find(p.ProfessionalPageID).UserName,
                    AllContentID = p.PostID
                }).ToList();
            }
            //
            var listByCategory = allContent;
            var listByCreator = allContent;
            //
            if (categoryName != "all" && categoryName != "")//in case the user choose a category
            {
                listByCategory = allContent.Where(q => (q.QCategories.Where(c => c.CategoryName == categoryName.ToString()).Count() > 0) || q.PCategories.Where(c => c.CategoryName == categoryName.ToString()).Count() > 0).ToList();
            }
            //
            if (creatorName != "all" && creatorName != "")//in case the user choose a creatorName
            {
                listByCreator = allContent.Where(q => q.CreatorName == creatorName.ToString()).ToList();
            }
            ViewData["ContentList"] = listByCategory.Where(c => listByCreator.Where(q => q.AllContentID == c.AllContentID).Count() > 0).ToList();
            return View("Home");
        }
       
    }
}
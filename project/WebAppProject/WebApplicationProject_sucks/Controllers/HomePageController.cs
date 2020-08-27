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
            FilterdSearch();
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
        /*public ActionResult FilterdSearch()
        {
            var category = Session["categoryName"];
            var contentType = Session["contentType"];
            var creatorName = Session["creatorName"];
            List<AllContent> allContent = null;
            List<AllContent> list = new List<AllContent>();
            AllContent[] ArrayallContent;

            //in case the user didnt choose to filter by ContentType(Post/ Question rom)
            if (contentType == null)
            {
                allContent = db.QuestionRooms.AsEnumerable().OrderBy(q => q.DatePublished).Select(q => new AllContent
                {
                    Title = "Question room",
                    Content = q.Title,
                    Date = q.DatePublished,
                    QCategories = q.Categories,
                    AllContentID = q.QuestionRoomID,
                    CreatorName=q.CreatorName
                }).Union(db.Posts.AsEnumerable().OrderBy(p => p.Date).Select(p => new AllContent
                {
                    Title = p.Title,
                    Content = p.Description,
                    Date = p.Date,
                    PCategories = p.Categories,
                    Img = p.Thumbnail,
                    CreatorName = (db.ProfessionalPages.Where(p1 => p1.ProfessionalPageID == p.ProfessionalPageID)).ToArray()[0].UserName,
                    AllContentID = p.PostID
                })).ToList();

            }
            else if (contentType.GetType().Equals(typeof(QuestionRoom))) // in Case the user choose ONLY question rooms
            {

                ArrayallContent = db.QuestionRooms.OrderBy(q => q.DatePublished).Select(q => new AllContent
                {
                    Title = "Question room",
                    Content = q.Title,
                    Date = q.DatePublished,
                    QCategories = q.Categories,
                    CreatorName = q.CreatorName,
                    AllContentID = q.QuestionRoomID
                }).ToArray();
            }
            else // in case the user choose ONLY posts
            {
                ArrayallContent = db.Posts.OrderBy(p => p.Date).Select(p => new AllContent
                {
                    Title = p.Title,
                    Content = p.Description,
                    Date = p.Date,
                    PCategories = p.Categories,
                    Img = p.Thumbnail,
                    CreatorName = db.ProfessionalPages.Find(p.ProfessionalPageID).UserName,
                    AllContentID = p.PostID
                }).ToArray();
            }
            //
            var listByCategory = allContent;
            var listByCreator = allContent;
            //
            if (category != null)//in case the user choose a category
            {
                listByCategory = allContent.Where(q => (q.QCategories.Where(c => c.CategoryName == category.ToString()).Count() > 0) || q.PCategories.Where(c => c.CategoryName == category.ToString()).Count() > 0).ToList();
            }
            //
            if (creatorName != null)//in case the user choose a creatorName
            {
                listByCreator = allContent.Where(q => q.CreatorName == creatorName.ToString()).ToList();
            }
            ViewData["ContentList"] = listByCategory.Where(c => listByCreator.Where(q => q.AllContentID == c.AllContentID).Count() > 0).ToList();
            return Redirect("../HomePage/UserHome");
        }
       
    }
}
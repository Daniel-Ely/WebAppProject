using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks.Models;


namespace WebApplicationProject_sucks.Controllers
{
 
    public class HomePageController : Controller
    {
        MyDB db = new MyDB();
        // GET: HomePage
       // [LogInFilter]
        public ActionResult Home()
        {
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
        public ActionResult FilterdSearch()
        {
            var category = Session["categoryName"].ToString();
            var contentType = Session["contentType"];
            var creatorName = Session["creatorName"].ToString();
            var listCategory = db.QuestionRooms.ToList();
            var listCreator = db.QuestionRooms.ToList();
            var listContent = db.QuestionRooms.ToList();
            //
            else if (category != null)
            {
                listCategory = db.QuestionRooms.Where(q=>q.Categories.Where(c=>c.CategoryName == category).Count() > 0).ToList();
            }
            else if (contentType != null)
            {
                listContent = db.QuestionRooms.Where(q => q.GetType().Equals(contentType.GetType())).ToList();
            }
            else if (creatorName != null)
            {
                listCreator = db.QuestionRooms.Where(q => q.CreatorName == creatorName).ToList();
            }
            ViewBag.data["QroomList"] = listCategory.Join(listContent, m => m.QuestionRoomID);
        }
       
    }
}
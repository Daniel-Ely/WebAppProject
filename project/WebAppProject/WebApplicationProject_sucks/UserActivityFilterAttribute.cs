using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks.Controllers;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks
{
    public class UserActivityFilterAttribute : ActionFilterAttribute
    {
        private MyDB db = new MyDB();
        public override void OnActionExecuting(ActionExecutingContext filterContext)//the fillter is activated after sending a comment to! -> comment increses the priority as well!!
        {
            UsersController usersController = new UsersController();
            //
            //getting the Qroom/Post id and the current user
            //
            var contentid = filterContext.Controller.ValueProvider.GetValue("Id").AttemptedValue;
            string userId = filterContext.HttpContext.Session["UserName"].ToString();
            User user = db.Users.Where(d=>d.UserName == userId).ToList().ElementAt(0);
            //
            //getting the controller in order to know if the user enterd a post or a Qroom
            //
            var controller = filterContext.Controller;
            //
            if (controller.GetType() == typeof(QuestionRoomsController)) // in case of QutionRoom
            {
                QuestionRoom questionRoom = db.QuestionRooms.Find(Int32.Parse(contentid));
                foreach (RoomToCategory c in questionRoom.Categories)
                {
                    //
                    //in case the catgory is alrady in the intrests list
                    //
                    if (user.Interests.Where(d=>d.CategoryName == c.CategoryName).Count() > 0)
                    {
                        usersController.categoryWasViewd(c.CategoryName , userId.ToString());
                    }
                    else
                    {// in case the user viewed this category for the first time in a sertion preiod of time
                        usersController.newCategoryWasViewd(c.CategoryName, userId.ToString());
                    }
                }
            }
            else //in case of post
            {
                Post post = db.Posts.Find(Int32.Parse(contentid));
                foreach (PostToCategory c in post.Categories)
                {
                    //
                    //in case the catgory is alrady in the intrests list
                    //
                    if (user.Interests.Where(d => d.CategoryName == c.CategoryName).Count() > 0)
                    {
                        usersController.categoryWasViewd(c.CategoryName, userId.ToString());
                    }
                    else
                    {// in case the user viewed this category for the first time in a sertion preiod of time
                        usersController.newCategoryWasViewd(c.CategoryName, userId.ToString());
                    }
                }
            }

        }
        
    }
}

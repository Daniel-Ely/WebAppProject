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
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //
            //getting the Qroom/Post id
            //
            var id = filterContext.Controller.ValueProvider.GetValue("Id").AttemptedValue;
            //
            //getting the controller in order to know if the user enterd a post or a Qroom
            //
            var controller = filterContext.Controller;
            if (controller.GetType() == typeof(QuestionRoomsController))
            {
                controller = (QuestionRoomsController)controller;
                QuestionRoom questionRoom = db.QuestionRooms.Find(id);
                foreach (RoomToCategory c in questionRoom.Categories)
                {
                    //
                    //in case the catgory is alrea
                    //
                }
            }

        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}

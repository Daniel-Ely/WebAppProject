using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks.Controllers;

namespace WebApplicationProject_sucks
{
    public class UserActivityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //
            //getting the Qroon/Post id
            //
            var test = filterContext.ActionParameters;
            //
            //getting the controller 
            //
            var controller = filterContext.Controller;
            if (controller.GetType() == typeof(QuestionRoomsController))
            {
                controller = (QuestionRoomsController)controller;
                
            }
            
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }
    }
}
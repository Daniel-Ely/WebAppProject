using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks
{
    public class LogInFilterAttribute : ActionFilterAttribute
    {
        private readonly int validity_Month = 1; 
        MyDB db = new MyDB();
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string userId = filterContext.HttpContext.Session["UserName"].ToString();
            User user = db.Users.Find(userId);
            if (user.Interests.Count > 10)
            {
                foreach (UserToCategory uTc in user.Interests)
                {
                    if (user.Interests.Count <= 10) break;
                    if (uTc.LastTouched.Month < (DateTime.Today.Month - validity_Month))
                    {
                        db.UserToCategories.Remove(uTc);
                        db.SaveChanges();
                    }
                }
            }

        }
    }
}
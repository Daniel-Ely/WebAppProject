using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult VerifyFirstAdmin(string First)
        {
            if(First==null)
                return Redirect("../HomePage/Home");
            if (First == "iamfirst")
            {
               return Redirect("../HomePage/FirstTimeInThisSystem");
            }

            return Redirect("../HomePage/Home");
        }
    }
}
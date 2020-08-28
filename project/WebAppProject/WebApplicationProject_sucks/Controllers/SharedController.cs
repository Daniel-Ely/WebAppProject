using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult MyProfessionalPages()
        {
            return View();
        }
        public ActionResult FromMy(string FromMy)
        {
            if (FromMy == null)
                return Redirect("/Shared/MyProfessionalPages");
            Session["FromMy"] = FromMy;
            return Redirect("/ProfessionalPages/Create");
        }
    }
}
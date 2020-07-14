using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}
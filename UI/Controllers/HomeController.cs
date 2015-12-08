using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["logged_in_user_obj"] != null) return RedirectToAction("Index", "Dashboard");
            return View();
        }

        public ActionResult About()
        {
            if (Session["logged_in_user_obj"] != null) return RedirectToAction("Index", "Dashboard");
            return View();
        }
    }
}
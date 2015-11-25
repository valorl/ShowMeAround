using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Message = Session["auth_token"];
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
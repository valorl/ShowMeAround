using Data;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Helpers;
using Utilities;
namespace UI.Controllers
{
    public class MatchingController : Controller
    {
        // GET: Matching
        public ActionResult Index()
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");
            return View();
        }

        public ActionResult Matching(string city, DateTime start, DateTime end)
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            var user = (User)Session["logged_in_user_obj"];
            //var city = (string)TempData["matching_city"];

            //var start = (DateTime)TempData["matching_start"];
            //var end = (DateTime)TempData["matching_end"];


            var client = new SMARestClient("MatchingService.svc");
            var matchesContent = client.Get<List<Match>>($"matches/{user.Id}?city={city}");

            ViewBag.MatchList = matchesContent.ToList<Match>();
            return View();
        }
    }
}
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Helpers;
using Utilities;


namespace UI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            var cClient = new SMARestClient("CountryService.svc");
            var countryContent = cClient.Get<List<Country>>("countries/");
            var countries = countryContent.ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString()
            }).ToList();
            ViewBag.CountryList = countries;

            ViewBag.User = Session["logged_in_user_obj"];

            ViewBag.Message = Session["auth_token"];
            return View();
        }

        public ActionResult Logout()
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            var user = (User)Session["logged_in_user_obj"];

            var client = new SMARestClient("SessionService.svc");
            client.AuthToken = (string)Session["auth_token"];
            client.Delete("/session", user.Id);

            Session["logged_in_user_obj"] = null;
            Session["auth_token"] = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult GetMatches(Models.MeetUpModel model)
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            //TempData["matching_city"] = model.City.Name;
            //TempData["matching_start"] = model.StartDate;
            //TempData["matching_end"] = model.EndDate;

            return RedirectToAction("Matching", "Matching", 
                new {city = model.City.Name, start = model.StartDate, end = model.EndDate});
        }

        
    }
}
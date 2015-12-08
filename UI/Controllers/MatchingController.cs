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

        [HttpGet]
        public ActionResult Matching(string city, DateTime start, DateTime end, int minAge, int maxAge)
        {
            // Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            var user = (User)Session["logged_in_user_obj"];
            //var city = (string)TempData["matching_city"];

            //var start = (DateTime)TempData["matching_start"];
            //var end = (DateTime)TempData["matching_end"];

            var client = new SMARestClient("MatchingService.svc");
            client.AuthToken = (string)Session["auth_token"];
            var matchesContent = client.Get<List<Match>>($"matches/{user.Id}?city={city}&minAge={minAge}&maxAge={maxAge}");

            ViewBag.MatchList = matchesContent.ToList<Match>();
            TempData["Matches"] = matchesContent;
            TempData["Start"] = start;
            TempData["End"] = end;
            TempData["City"] = city;
            ViewBag.City = city;
            return View();
        }

        [HttpPost]
        public ActionResult Matching(int id)
        {
            MeetUp meetUp = new MeetUp();
            List<Match> matches = (List<Match>)TempData["Matches"];
            meetUp.Guide = matches[id].Guide;
            meetUp.Traveler = matches[id].Traveler;
            meetUp.StartDate = (DateTime)TempData["Start"];
            meetUp.FinishDate = (DateTime)TempData["End"];
            meetUp.City = new City { Name = (string)TempData["City"] };
            meetUp.City_Name = meetUp.City.Name;
            meetUp.TravelerState = RequestState.Sent;
            meetUp.GuideState = RequestState.Received;

            var client = new SMARestClient("MeetUpService.svc");
            client.AuthToken = (string)Session["auth_token"];
            MeetUp createdMeetUp = client.Post<MeetUp>("meetups/", meetUp);
            

            if (createdMeetUp == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "MeetUp", new { area = "" });
            }
        }
    }
}
using Data;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Helpers;

namespace UI.Controllers
{
    public class MatchingController : Controller
    {
        // GET: Matching
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Matching()
        {
            //var sessionClient = new SMARestClient("SessionService.svc");
            //var token = Session["auth_token"];
            //Session session = sessionClient.Post<string,Session>($"session/", (string)token, "http://schemas.microsoft.com/2003/10/Serialization/");
            //var userid = session.UserID;
            var userid = "72";
            var city = "Coppenhagen";

            var client = new SMARestClient("MatchingService.svc");
            var matchesContent = client.Get<List<Match>>($"matches/{userid}?city={city}");

            ViewBag.MatchList = matchesContent.ToList<Match>();
            //var vm = new Models.Matching();

            //foreach (var item in matchesContent)
            //{
            //    vm.Matches.Add(new Models.MatchingModel { Match = item });
            //}
            
            return View();
        }
    }
}
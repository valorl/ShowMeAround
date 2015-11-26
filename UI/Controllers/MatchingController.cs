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
            //var client = new SMARestClient("UserService.svc");
            //var matchesContent = client.Get<List<Match>>("matches/");
            //var matches = matchesContent.ToList();

            //ViewBag.MatchesList = matchesContent;
            return View();
        }
    }
}
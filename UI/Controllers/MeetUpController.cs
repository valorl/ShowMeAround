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
    public class MeetUpController : Controller
    {
        // GET: Matching
        public ActionResult Index()
        {
            //Check if user is logged in
            if (!PageAuthorization.Authorize()) return RedirectToAction("Login", "Users");

            //User user = new User();
            //user.Id = 72;
            var user = (User)Session["logged_in_user_obj"];


            var client = new SMARestClient("MeetUpService.svc");
            var meetupContent = client.Get<List<MeetUp>>("meetups/").ToList();
            List<MeetUp> received = new List<MeetUp>();
            List<MeetUp> sent = new List<MeetUp>();

            foreach (var item in meetupContent)
            {
                if (item.Guide.Id == user.Id)
                {
                    received.Add(item);
                }
            }

            foreach (var item in meetupContent)
            {
                if (item.Traveler.Id == user.Id)
                {
                    sent.Add(item);
                }
            }

            ViewBag.ReceivedRequest = received;
            ViewBag.SentRequest= sent;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var client = new SMARestClient("MeetUpService.svc");
            client.AuthToken = (string)Session["auth_token"];
            //client.Delete("meetup/", id);

            //return RedirectToAction("Index", "MeetUp", new { area = "" });
            return View();
        }
    }
}
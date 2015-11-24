using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using UI.Helpers;
using DataAccess;
using System.Collections;

namespace UI.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
        }


        // to return the form on /Users/Register
        [HttpGet]
        public ActionResult Register()
        {

            //Languages
            var client = new SMARestClient("UserService.svc");
            var languageContent = client.Get<List<Language>>("languages/");
            var languages = languageContent.ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString(),
            }).ToList();

            ViewBag.LanguageList = languages;

            //Interest
            var interestContent = client.Get<List<Interest>>("interests/");
            var interests = interestContent.ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString(),
            }).ToList();

            var vm = new Models.Registration();
            
            foreach (var item in interestContent)
            {
                vm.Interests.Add(new Models.InterestModel { Interest = item });
            }


            var session = System.Web.HttpContext.Current.Session;
            return View(vm);
        }

        // to handle form submission 
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(Models.Registration registration)
        {
            registration.User.Languages.Add(new Language("English"));
            registration.User.Interests.Add(new Interest("String content 1"));

            var client = new SMARestClient("UserService.svc");
            User createdUser = client.Post<User>("users/", registration.User);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Session session)
        {
            var client = new SMARestClient("SessionService.svc");
            Session newsession = client.Post<Session>("/login", session);

            System.Web.HttpContext.Current.Session["anything"] = newsession.Token;

            return View();
        }
    }
}

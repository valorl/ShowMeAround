using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using UI.Helpers;
using DataAccess;
using System.Collections;
using Data.Utils;

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
            //registration.User.Languages.Add(new Language("English"));
            //registration.User.Interests.Add(new Interest("String content 1"));

            var selectedInterests = new List<Interest>();
            foreach (var model in registration.Interests)
            {
                if (model.IsSelected) selectedInterests.Add(model.Interest);
            }

            registration.User.Languages = registration.LanguageContainer;
            registration.User.Interests = selectedInterests;

            var client = new SMARestClient("UserService.svc");
            User createdUser = client.Post<User>("users/", registration.User);
            if(createdUser == null)
            {
                ViewBag.Message = "User registration failed. Please try again later.";
                return View();
            }
            else
            {
                TempData["successful_registration_message"] = "Your user account has been successfully created and you are now able to login!";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = TempData["successful_registration_message"];
            if(ViewBag.Message != null && ViewBag.Message.Length > 0)
            {
                ViewBag.MessageClass = "text-success";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginCredentials credentials)
        {
            var client = new SMARestClient("SessionService.svc");
            Session newSession = client.Post<LoginCredentials, Session>("/login", credentials);

            if(newSession == null)
            {
                ViewBag.Message = "Login failed.";
                return View();
            }
            else
            {
                System.Web.HttpContext.Current.Session["auth_token"] = newSession.Token;
                return RedirectToAction("Index", "Dashboard");
            }
            
        }
    }
}

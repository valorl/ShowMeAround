﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Utilities;
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
            if (Session["logged_in_user_obj"] != null) return RedirectToAction("Index", "Dashboard");
            //Languages
            var uClient = new SMARestClient("UserService.svc");
            var languageContent = uClient.Get<List<Language>>("languages/");
            var languages = languageContent.ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString(),
            }).ToList();

            ViewBag.LanguageList = languages;

            var cClient = new SMARestClient("CountryService.svc");
            var countryContent = cClient.Get<List<Country>>("countries/");
            var countries = countryContent.ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString()
            }).ToList();

            
            ViewBag.CountryList = countries;

            //Interest
            var interestContent = uClient.Get<List<InterestPopularity>>("interests/popular");
            var interests = interestContent.ToList().Select(i => new SelectListItem
            {
                Text = i.Interest.Name,
                Value = i.Interest.Name.ToString(),
            }).ToList();

            var vm = new Models.Registration();
            
            foreach (var item in interestContent)
            {
                vm.Interests.Add(new Models.InterestModel { Interest = item.Interest, Popularity = item.Popularity });
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
            if (Session["logged_in_user_obj"] != null) return RedirectToAction("Index", "Dashboard");

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
            Session newSession = null;

            try
            {
                newSession = client.Post<LoginCredentials, Session>("/login", credentials);
            }
            catch
            {
                newSession = null;
            }
             

            if(newSession == null)
            {
                ViewBag.Message = "Login failed. Please try again.";
                ViewBag.MessageClass = "text-danger";
                return View();
            }
            else
            {
                var user = new SMARestClient("UserService.svc").Get<User>($"/user/{newSession.UserID}");
                if (user != null) System.Web.HttpContext.Current.Session["logged_in_user_obj"] = user;
                System.Web.HttpContext.Current.Session["auth_token"] = newSession.Token;

                return RedirectToAction("Index", "Dashboard");
            }
            
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using UI.Helpers;
using DataAccess;

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
            return View();
        }

        // to handle form submission 
        [HttpPost]
        public ActionResult Register(User user)
        {
            var client = new UserService.UserServiceClient();
            var createdUser = client.CreateUser(user);
            if (createdUser == null) throw new Exception("UserService.CreateUser() failed.");
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
    }
}

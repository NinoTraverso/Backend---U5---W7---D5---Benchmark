using Inforno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inforno.Controllers
{
    public class HomeController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        //-------------------------------------------------- ADMIN LOG IN / LOG OUT --------------------------------------------------- //

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AdminLogin([Bind(Include = "Username, Password, Role")] Users users)
        {

            var user = db.Users.FirstOrDefault(u => u.Username == users.Username && u.Password == users.Password && u.Role == "Admin");

            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(users.Username, false);
                return RedirectToAction("ALogged", "Home");
            }

            return View();
        }

        //[Authorize(Roles="Admin")]
        public ActionResult ALogged()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //-------------------------------------------------- ADMIN LOG IN / LOG OUT --------------------------------------------------- //
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UserLogin([Bind(Include = "Username, Password, Role")] Users users)
        {

            var user = db.Users.FirstOrDefault(u => u.Username == users.Username && u.Password == users.Password && u.Role == "Admin" || u.Role == "Utent");

            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(users.Username, false);
                return RedirectToAction("ULogged", "Home");
            }

            return View();
        }

        //[Authorize(Roles="Admin")]
        public ActionResult ULogged()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Info()
        {
            return View();
        }


    }
}

using MBCFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MBCFM.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool success = false;
            User user = null;
            //log on to the database and check user credentials
            using (var db = new JobsContext())
            {
                //a user will only be returned if the username and password match; otherwise user will equal null.
                user = db.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
                success = user != null;
            }

            if (success)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
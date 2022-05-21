using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserManagement.Helper;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AuthController : Controller
    {
        UserManagementDbContext db = new UserManagementDbContext();
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                string passwordMD5 = user.Password.ToMD5();
                var theUser = db.Users.FirstOrDefault(f => f.Email == user.Email && f.Password == passwordMD5);
                if(theUser != null)
                {
                    FormsAuthentication.SetAuthCookie(theUser.Email, false);
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ViewBag.Message = "Email or password is incorrect!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}
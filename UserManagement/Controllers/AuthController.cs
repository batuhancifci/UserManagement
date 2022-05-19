using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AuthController : Controller
    {
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
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserManagement.Dtos;
using UserManagement.Helper;
using UserManagement.Models;
using static UserManagement.Dtos.UserDto;

namespace UserManagement.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UserManagementDbContext db = new UserManagementDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User user = new User();
            user.Role = Enums.Roles.User;
            return View(user);
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            var response = new GeneralDto.Response();
            if (ModelState.IsValid)
            {
                var existsUser = db.Users.FirstOrDefault(f => f.Email == user.Email);
                if (existsUser != null)
                {
                    response.Message = "This user already exists.";
                    response.Error = true;
                    return Json(response);
                }
                user.Password = user.Password.ToMD5();
                db.Users.Add(user);
                db.SaveChanges();
                response.Error = false;
                return Json(response);
            }

            response.Message = "Fill in all fields!";
            response.Error = true;
            return Json(response);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            EditDto editUser = new EditDto();
            editUser.user = user;
            return View(editUser);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditDto editUser)
        {
            if (ModelState.IsValid)
            {
                if (editUser.newPassword != null)
                    editUser.user.Password = editUser.newPassword.ToMD5();
                db.Entry(editUser.user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editUser);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            var response = new GeneralDto.Response();
            response.Error = false;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

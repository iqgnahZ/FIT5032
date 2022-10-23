using FIT5032Final.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032Final.Controllers
{
    public class UserRolesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager;

        public UserRolesController()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: UserRoles
        public ActionResult Index()
        {
            var roles = this.db.Roles.ToList();
            return View(roles);
        }


        // GET: UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                var newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = formCollection["RoleName"]
                };
                db.Roles.Add(newRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRoles/Delete
        public ActionResult Delete(string roleName)
        {
            var role = db.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: UserRoles/Edit
        public ActionResult Edit(string roleName)
        {
            var role = db.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserRoles/AddRole
        public ActionResult AddRole()
        {
            ViewBag.Roles = db.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            ViewBag.Users = db.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            return View();
        }

        // POST: UserRoles/AddRole
        [HttpPost]
        public ActionResult AddRole(string Email, string Role)
        {
            try
            {
                var user = userManager.FindByEmail(Email);
                userManager.AddToRole(user.Id, Role);
                ViewBag.Roles = db.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
                ViewBag.Users = db.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            }
            catch (Exception e)
            {
                ViewBag.Errormessage = e.Message;
            }
            return View();
        }

        // GET: UserRoles/GetRole
        public ActionResult GetRole()
        {
            ViewBag.Users = db.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            return View();
        }

        // PSOT: UserRoles/GetRole
        [HttpPost]
        public ActionResult GetRole(string Email)
        {
            try
            {
                ViewBag.Email = Email;
                var user = userManager.FindByEmail(Email);
                ViewBag.Roles = userManager.GetRoles(user.Id);
                ViewBag.Users = db.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            }
            catch (Exception e)
            {
                ViewBag.Errormessage = e.Message;
            }

            return View();
        }

        // GET: UserRoles/DeleteRole
        public ActionResult DeleteRole(string Email, string Role)
        {
            var user = userManager.FindByEmail(Email);
            if (this.userManager.IsInRole(user.Id, Role))
                this.userManager.RemoveFromRole(user.Id, Role);
            return RedirectToAction("Index");
        }

    }
}
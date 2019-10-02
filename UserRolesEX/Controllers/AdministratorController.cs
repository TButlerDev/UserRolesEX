using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserRolesEX.Models;

namespace UserRolesEX.Controllers
{
    public class AdministratorController : AppController
    {
        ApplicationDbContext context;

        public AdministratorController()
        {

        }

        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserForm(string id)
        {
            var user = _context.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user !=null)
            {
                var roles = UserManager.GetRoles(user.Id).ToList();
                ViewBag.Roles = new SelectList(_context.Roles, "Name", "Name", roles);
            }
            else
            {
                ViewBag.Roles = new SelectList(_context.Roles, "Name", "Name");
            }
            return View(user ?? new ApplicationUser());
        }

        [HttpPost]
        public async Task<ActionResult> UserForm(ApplicationUser model, FormCollection form)
        {
            var role = form["Roles"];
            var pw = form["Password"];
            var cpw = form["ConfirmPassword"];
            var user = UserManager.FindByEmail(model.Email);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MI = model.MI;

                var result = await UserManager.UpdateAsync(user);

                //Get roles of user
                var roles = UserManager.GetRoles(user.Id);

                //remove old roles
                UserManager.RemoveFromRoles(user.Id, roles.ToArray());

                //add new roles
                UserManager.AddToRole(user.Id, role);
            }
            else
            {
                var result = await UserManager.CreateAsync(model, pw);

                //add role
                UserManager.AddToRole(model.Id, role);
            }
            return RedirectToAction("UserForm", new { id = model.Id });
        }
    }
}
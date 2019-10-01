using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRolesEX.Models;

namespace UserRolesEX.Controllers
{
    public class AdministratorController : AppController
    {
        ApplicationDbContext context;

        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Routing;
using System.Security.Claims;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        OracleDbContext ctx = new OracleDbContext();

        public HomeController() {
            ctx.InitializeModel();
        }

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Dashboard()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            ViewBag.Email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
            return View("Dashboard");
        }
    }
}

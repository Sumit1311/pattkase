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
        //OracleDbContext ctx ew OracleDbContext();
        ApplicationDbContext user = new ApplicationDbContext();


        public HomeController() {
            //ctx.InitializeModel();
        }

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Dashboard()
        {
            
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            //ViewBag.Email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
            //ViewBag.Role = identity.HasClaim(ClaimTypes.Role,"Admin");
            return View("Dashboard");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Requesters()
        {
            var requesters = user.Requesters.ToList();
            ViewBag.requesters = requesters;
            return View("Requesters");        
        }
    }
}

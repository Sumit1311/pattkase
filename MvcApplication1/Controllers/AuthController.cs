using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Security.Policy;


namespace MvcApplication1.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        OracleDbContext ctx = new OracleDbContext();
        public AuthController() {
            ctx.InitializeModel();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pwd)
        {
            //System.Diagnostics.Debug.WriteLine("============"+db.Database.Connection.ConnectionString);
            try
            {
                Login login = ctx.Logins.Where(m => (m.Email == email && m.Password == pwd)).First<Login>();
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, email)
            },
            "ApplicationCookie");

                var ctx1 = Request.GetOwinContext();
                var authManager = ctx1.Authentication;

                authManager.SignIn(identity);
                //System.Diagnostics.Debug.WriteLine("============ Redirecting");
                return Redirect(Url.Action("Dashboard","Home")) ;
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine("User Does Not Exist");
                System.Diagnostics.Debug.WriteLine(e);
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult LogOut() {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

    }
}

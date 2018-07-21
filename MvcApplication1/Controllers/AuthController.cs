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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net.Mail;


namespace MvcApplication1.Controllers
{

    public class AuthController : Controller
    {
        //OracleDbContext ctx = new OracleDbContext();
        ApplicationDbContext user = new ApplicationDbContext();
        UserManager<Login> userManager;
        public AuthController()
        {
            //ctx.InitializeModel();
            userManager = new UserManager<Login>(new UserStore<Login>(user));
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(string userName, string pwd)
        {
            var ReturnUrl = Request.QueryString["ReturnUrl"];
            //System.Diagnostics.Debug.WriteLine("============"+db.Database.Connection.ConnectionString);
            try
            {
                //Login login = ctx.Logins.Where(m => (m.UserName == email)).First<Login>();
                Login login = userManager.FindByName(userName);

                bool checkPwd = userManager.CheckPassword(login, pwd);
                if (checkPwd)
                {
                    var ctx1 = Request.GetOwinContext();
                    var authManager = ctx1.Authentication;
                    ClaimsIdentity identity;
                    if (this.isAdmin(login))
                    {
                        identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Role, "Admin")
                        },
                        "ApplicationCookie"
                        );
                    }
                    else
                    {
                        identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Role, "User")
                        },
                        "ApplicationCookie"
                        );
                    }
                    authManager.SignIn(identity);
                    if (ReturnUrl != null && ReturnUrl != String.Empty){
                        return Redirect(ReturnUrl);
                    }
                    return Redirect(Url.Action("Dashboard", "Home"));
                }

            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine("User Does Not Exist");
                System.Diagnostics.Debug.WriteLine(e);
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Index", "Home"));
        }


        [HttpGet]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(System.Web.Mvc.FormCollection fc)
        {
            Requester req = new Requester();

            req.Id = Guid.NewGuid().ToString();
            req.Address = fc["address"].ToString();
            req.EmailId = fc["email"].ToString();
            req.FullName = fc["fullname"].ToString();
            req.NameOfOrganization = fc["organization"].ToString();
            req.Profession = Convert.ToInt32(fc["profession"]);
            req.Purpose = fc["purpose"].ToString();
            req.Status = 0;

            user.Requesters.Add(req);
            if (user.SaveChanges() > 0)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                //ViewBag.msg = "Failed to Save Data";
                return RedirectToAction("Register", "Auth");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ViewRequester()
        {
            var RequesterId = Request.QueryString["id"];
            Login login = user.Users.FirstOrDefault(r => r.RequesterRefId == RequesterId);
            Requester req = user.Requesters.FirstOrDefault(r => r.Id == RequesterId);
            ViewBag.requester = req;
            if (login == null)
            {
                ViewBag.userName = req.EmailId;
                ViewBag.password = "Default123";
            }
            else 
            {
                ViewBag.userName = login.UserName;
            }
            
            ViewBag.isApproved = req.Status == 0 ? false : true;
            return View("ViewRequester");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Approve(System.Web.Mvc.FormCollection fc)
        {
            var requesterId = fc["reqId"];
            var userName = fc["userName"];
            var password = fc["pwd"];
            var userLogin = new Login();
            Requester req = user.Requesters.FirstOrDefault(r => r.Id == requesterId);
            if (req.Status == 0)
            {
                userLogin.RequesterRefId = requesterId;
                userLogin.UserName = userName;
                var chkUser = userManager.Create(userLogin, password);
                req.Status = 1;
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRoles(userLogin.Id, "Member");
                    user.SaveChanges();
                }
                /*SmtpClient smtpClient = new SmtpClient("smtp.mailgun.org", 25);

                smtpClient.Credentials = new System.Net.NetworkCredential("postmaster@sandboxc22cd49475a84fb084112d1ae7fc171e.mailgun.org", "7d79211555e00c458bd6ca5bea33f527");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("sumittoshniwal92@gmail.com", "Test");
                mail.To.Add(new MailAddress("sumittoshniwal92@gmail.com"));
                //mail.CC.Add(new MailAddress("sumittoshniwal92@gmail.com"));

                smtpClient.Send(mail);*/

                //Response.Redirect("/Auth/ViewRequester?id=" + requesterId);
            }
            return RedirectToAction("Requesters","Home");
        }

        public bool isAdmin(Login user)
        {
            return userManager.IsInRole(user.Id, "Admin");
        }



    }

}

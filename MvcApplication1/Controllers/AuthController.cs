using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Security.Policy;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net.Mail;
using MvcApplication1.Models;
using MvcApplication1.Library;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MvcApplication1.Controllers
{
    public class AuthController : BaseController
    {
        //OracleDbContext ctx = new OracleDbContext();
        UserManager<Login> userManager;
        public AuthController()
        {
            //ctx.InitializeModel();
            userManager = new UserManager<Login>(new UserStore<Login>(user));
            var provider = new DpapiDataProtectionProvider("PattKase");
            userManager.UserTokenProvider = new DataProtectorTokenProvider<Login>(provider.Create("Pattkase"));
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn()
        {
            ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"];
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
                if(login == null)
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "User Doesnot Exist");
                }
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
                    if (!string.IsNullOrEmpty(ReturnUrl)){
                        return SendRedirectResponse(ReturnUrl);
                    }
                    return SendRedirectResponse(Url.Action("Dashboard", "Home"));
                } 
                else
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Userid or Password didn't match");
                }

            }
            catch (InvalidOperationException e)
            {
                //System.Diagnostics.Debug.WriteLine("User Does Not Exist");
                //System.Diagnostics.Debug.WriteLine(e);
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
        }


        [HttpGet]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            try
            {
                authManager.SignOut("ApplicationCookie");
                return SendRedirectResponse(Url.Action("Index", "Home"));
            }
            catch (Exception e)
            {
                Response.StatusCode=500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            

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
            req.Address = fc["address"];
            req.EmailId = fc["email"];
            req.FullName = fc["fullname"];
            req.NameOfOrganization = fc["organization"];
            req.Profession = Convert.ToInt32(fc["profession"]);
            req.Purpose = fc["purpose"];
            req.Status = 0;

            if (!TryValidateModel(req))
            {
                if (!ModelState.IsValid)
                {
                    string errors = "";
                    foreach(var val in ModelState.Values)
                    {
                        foreach(var err in val.Errors)
                        {
                            errors += "<br> - "+ err.ErrorMessage;
                        }
                    }
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Field Validation Failed : "+errors);
                }
            }


            try
            {
                var prevReq = user.Requesters.FirstOrDefault(r => r.EmailId == req.EmailId);

                if (prevReq != null)
                {
                    Response.StatusCode = 400;
                    if(prevReq.Status == 0)
                    {
                        return SendErrorResponse("Bad Request", "Request Already Submitted for this email id. Please wait till you get the valid login Id and password");
                    }
                    else
                    {
                        return SendErrorResponse("Bad Request", "Request Already Submitted for this email id. Please check your email for login id and Password");
                    }
                    
                }

                user.Requesters.Add(req);
                if (user.SaveChanges() > 0)
                {
                    //return GenericRedirect(Url.Action("Index", "Home"));
                    Response.StatusCode = 200;
                    return SendAjaxResponse("OK", new
                    {
                        message = "Request successfully sent to admin for approval. Once approved you will get an emailid and password by email."
                    });
                }
                else
                {
                    //ViewBag.msg = "Failed to Save Data";
                    return SendRedirectResponse(Url.Action("Register", "Auth"));
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ViewRequester()
        {
            var RequesterId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(RequesterId))
            {
                Response.StatusCode = 400;
                return SendErrorResponse("Bad Request", "id parameter required");
            }
            try 
            { 
                Login login = user.Users.FirstOrDefault(r => r.RequesterRefId == RequesterId);
                Requester req = user.Requesters.FirstOrDefault(r => r.Id == RequesterId);
                if (req == null)
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "No request found");
                }
                ViewBag.requester = req;
                if (login == null)
                {
                    ViewBag.userName = req.EmailId;
                    ViewBag.password = PasswordHelper.generatePassword();
                }
                else
                {
                    ViewBag.userName = login.UserName;
                }

                ViewBag.isApproved = req.Status == 0 ? false : true;
                return View("ViewRequester");
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async System.Threading.Tasks.Task<ActionResult> Approve(System.Web.Mvc.FormCollection fc)
        //    public ActionResult Approve(System.Web.Mvc.FormCollection fc)
        {
            var requesterId = fc["reqId"];
            var userName = fc["userName"];
            var password = fc["pwd"];
            var resend = Request.QueryString["resend"];
            if (string.IsNullOrEmpty(requesterId) || string.IsNullOrEmpty(userName))
            {
                Response.StatusCode = 400;
                return SendErrorResponse("Bad Request", "Required field validation failed. Please provide the required fields and try again.");
            }
            var userLogin = new Login();
            try 
            {
            Requester req = user.Requesters.FirstOrDefault(r => r.Id == requesterId);
            if (req == null)
            {
                Response.StatusCode = 400;
                return SendErrorResponse("Bad Request", "Request Id not found");
            }
            if (req.Status == 0)
            {
                if (string.IsNullOrEmpty(password))
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Required field validation failed. Please provide the required fields and try again.");
                }
                    await EmailHelpser.sendRegistrationEmail(userName, password);

                    userLogin.RequesterRefId = requesterId;
                userLogin.UserName = userName;
                var chkUser = userManager.Create(userLogin, password);
                req.Status = 1;
                if (chkUser.Succeeded)
                {
                        
                        var result1 = userManager.AddToRoles(userLogin.Id, "Member");
                    user.SaveChanges();
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
                }
                else
                {
                    Response.StatusCode = 500;
                    return SendErrorResponse("Internal Server Error", "User creation failed. Please try again later");
                }
                

                //Response.Redirect("/Auth/ViewRequester?id=" + requesterId);
            }
            else
            {
                if (resend == "true")
                {
                    userLogin = userManager.FindByName(userName);
                    if (userLogin == null)
                    {
                        Response.StatusCode = 400;
                        return SendErrorResponse("Bad Request", "User not found");
                    }
                        string pwd = PasswordHelper.generatePassword();
                        string token = userManager.GeneratePasswordResetToken(userLogin.Id);
                        await EmailHelpser.sendResetPasswordEmail(userName, pwd);
                        userManager.ResetPassword(userLogin.Id, token, pwd);
                    
                        /*SmtpClient smtpClient = new SmtpClient("smtp.mailgun.org", 25);

                        smtpClient.Credentials = new System.Net.NetworkCredential("postmaster@sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org", "5a414512ea6f51a56fbe009bd53fee77-a4502f89-4358403e");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = false;
                MailMessage mail = new MailMessage();
                mail.Subject = "Pattkase User Credentials";
                mail.Body = "User Name : " + userLogin.UserName + "  Password : " + pwd;

                //Setting From , To and CC
                mail.From = new MailAddress("postmaster@sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org", "Test");
                mail.To.Add(new MailAddress("sumittoshniwal92@gmail.com"));
                //mail.CC.Add(new MailAddress("sumittoshniwal92@gmail.com"));

                smtpClient.Send(mail);*/
                    }
                else { 
                //TODO : Handle this case when the user is already active
                Response.StatusCode = 400;
                return SendErrorResponse("Bad Request", "User already approved.");
                }
            }
            return SendRedirectResponse(Url.Action("Requesters","Home"));
                 }
            catch (Exception e)
            {
                Response.StatusCode=500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
        }

        public bool isAdmin(Login user)
        {
            try
            {
                return userManager.IsInRole(user.Id, "Admin");
            }
            catch (Exception)
            {
                //ViewBag.message = e.Message.ToString();
                return false;
            }
        }



    }

}

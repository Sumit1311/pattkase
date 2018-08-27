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
    public class HomeController : BaseController
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
            return SendRedirectResponse(Url.Action("Dashboard", "Home"));
        }
        

        public ActionResult Dashboard()
        {
            
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            //ViewBag.Email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
            //ViewBag.Role = identity.HasClaim(ClaimTypes.Role,"Admin");
            try
            {
                ViewBag.searchFields = user.SearchFields.Where(f => (f.Show == true)).ToList();
            }
            catch(Exception e){
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            
            return View("Dashboard");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Requesters()
        {
            var requesters = new List<Requester>();
            try
            {
                requesters = user.Requesters.ToList();
            }catch(Exception e){
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            
            ViewBag.requesters = requesters;
            return View("Requesters");        
        }
    }
}

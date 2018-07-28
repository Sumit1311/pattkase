using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext user = new ApplicationDbContext();
        public ActionResult SendRedirectResponse(string url)
        {
            if (Request.IsAjaxRequest())
            {
                Response.StatusCode = 200;
                return SendAjaxResponse("OK", new
                {
                    redirect = url
                });

            }
            else
            {
                return Redirect(url);
            }


        }

        public ActionResult SendAjaxResponse(string code, Object response)
        {
            if (Request.IsAjaxRequest())
            {
                var json = new JsonResult();

                json.Data = new
                {
                    code = code,
                    status = "" + (Response.StatusCode == 0 ? 200 : Response.StatusCode),
                    body = response
                };
                return json;

            }
            else
            {
                throw new Exception();
            }
        }

        public ActionResult SendErrorResponse(string message, string subMessage)
        {

            if (Request.IsAjaxRequest())
            {

                return SendAjaxResponse("Error", new
                {
                    message = message,
                    subMessage = subMessage
                });
            }
            else
            {

                ViewBag.message = message;
                ViewBag.subMessage = subMessage;
                return View("~/Views/Error-" + Response.StatusCode + ".aspx");
            }
        }
    }
}
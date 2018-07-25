using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization; 


namespace MvcApplication1.Library
{
    public class ResponseUtils
    {
        public static ActionResult Redirect(HttpRequestBase req, string actionName, string controllerName, Controller controller)
        {
            var url = new UrlHelper();
            if (req.IsAjaxRequest()) {
                var json = new JsonResult();
                
                json.Data = new {
                    code="OK",
                    status="200",
                    body=new {
                        redirect=url.Action(actionName, controllerName)
                    }
                };
                return json;
                
            } else 
            {
                return controller.Redirect(url.Action(actionName, controllerName));
            }
            
            
        }

        public static ActionResult Redirect(HttpRequestBase req, string url)
        {
            if (req.IsAjaxRequest())
            {
                var json = new JsonResult();
                json.Data = new
                {
                    code = "OK",
                    status = "200",
                    body = new
                    {
                        redirect = url
                    }
                };
                return json;

            }
            else
            {

            }


        }
    }
}
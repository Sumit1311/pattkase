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
        public ActionResult Redirect(HttpRequestBase req, UrlHelper url)
        {
            if (req.IsAjaxRequest()) {
                var json = new JsonResult();
                json.Data = new {
                    code="OK",
                    status="200",
                    body=new {
                        redirect=url
                    }
                };
                return  
                
            }
            else
            {

            }
            
        }
    }
}
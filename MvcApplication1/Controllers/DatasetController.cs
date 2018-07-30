using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DatasetController : BaseController
    {
        public DatasetController() : base() { 
            
        }
        // GET: Dataset
        [HttpGet]
        public ActionResult ModifySearchFields()
        {
            ViewBag.SearchFields = user.SearchFields.ToList();

            return View("EditSearchFields");
        }

        [HttpPost]
        public ActionResult ModifySearchFields(FormCollection fc) {
            string[] list = fc.AllKeys;
            try
            { 
            foreach(var key in SearchField.AllFields) {
                if(list.Contains(key)) {
                    var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key && e.Show == false));
                    if(f != null) {
                        f.Show = true;
                    }

                } else {
                    var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key && e.Show == true));
                    if(f != null) {
                        f.Show = false;
                    }
                }
            }
            user.SaveChanges();
                }
            catch (Exception e)
            {
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return SendAjaxResponse("ok", new 
            {
                message="Successfully Saved Data."
            });
        }

        [HttpGet]
        public ActionResult BirdEyeView()
        {
            ViewBag.Countries = CasePaper.Countries;
            ViewBag.Courts = CasePaper.Courts;
            ViewBag.Suits = CasePaper.Suits;
            ViewBag.Statuses = CasePaper.Statuses;
            return View("BirdEyeView");
        }
    }
}
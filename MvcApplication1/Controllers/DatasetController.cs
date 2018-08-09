using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.Entity;

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
            List<CasePaper> dataset = user.CasePapers.ToList();
            ViewBag.Countries = CasePaper.Countries;
            ViewBag.Courts = CasePaper.Courts;
            ViewBag.Suits = CasePaper.Suits;
            ViewBag.Statuses = CasePaper.Statuses;
            ViewBag.Dataset = dataset;
            return View("BirdEyeView");
        }

        [HttpPost]
        public ActionResult BirdEyeView(List<InputDatasetRequest> dataset)
        {
            for (var i = 0; i < dataset.Count; i++)
            {
                var data = dataset[i].data;
                if (dataset[i].type == "new" && data != null)
                {
                    for (var j = 0; j < data.Count; j++)
                    {
                        //user.CasePapers.Add(data[0]);
                        user.CasePapers.Add(data[j].ConvertToDatabaseModel());
                    }
                }
                if (dataset[i].type == "update" && data != null)
                {
                    for (var j = 0; j < data.Count; j++)
                    {
                        if (data[j].id != null)
                        {
                            var id = data[j].id;
                            var updatedCase = user.CasePapers.FirstOrDefault(c => c.Id == id);
                            if (updatedCase != null) { 
                            data[j].ConvertToDatabaseModel(updatedCase);
                            }
                        }
                    }
                }
                if (dataset[i].type == "delete" && data != null)
                {
                    for (var j = 0; j < data.Count; j++)
                    {
                        if (data[j].id != null)
                        {
                            var id = data[j].id;
                            user.CasePapers.RemoveRange(user.CasePapers.Where(e => e.Id == id));
                        }
                    }
                }
            }
            user.SaveChanges();
            return SendRedirectResponse("/Dataset/BirdEyeView");
        }

        [HttpPost]
        public ActionResult Search(FormCollection fc)
        {
            string searchStyle = fc["searchStyle"];
            if(searchStyle == "caseNo")
            {
                string caseNo = fc["caseNo"];
                var c = user.CasePapers.Where(cp => cp.CaseNo == caseNo).FirstOrDefault();
                if(c != null)
                {
                    ViewBag.cases = c;
                    return View("ViewCase");
                }
                
            }
            else if(searchStyle == "fielded")
            {
                var fields = user.SearchFields.Where(f => f.Show == true).ToList();
                List<InputSearchField> inputList = new List<InputSearchField>();
                var i = 0;
                for (i = 0; i < fields.Count;i++ )
                {
                    InputSearchField f = InputSearchFields.getInputSearchField(fields[i].FieldName, null, false);
                    if(fc[f.name] != null || fc[f.name] != "" || fc[f.name] != "0")
                    {
                        f.value = fc[f.name];
                        inputList.Add(f);
                    }
                    
                }
                SqlQuery q = InputSearchFields.getSqlQuery(inputList);
                var cases = user.CasePapers.SqlQuery(q.queryString, q.parameters.ToArray()).ToList();
                List<List<InputSearchField> > casesList = new List<List<InputSearchField> >();
                for(i = 0; i < cases.Count; i++)
                {
                    List<InputSearchField> t = new List<InputSearchField>();
                    for (var j = 0; j < fields.Count; j++)
                    {
                        InputSearchField f = InputSearchFields.getInputSearchField(fields[j].FieldName, cases[i], false);
                        t.Add(f);
                    }
                    casesList.Add(t);
                }
                ViewBag.caseResults = casesList;
                return View("SearchResults");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CaseInfo()
        {
            var CaseNumber = Request.QueryString["caseNo"];
            CasePaper c = user.CasePapers.FirstOrDefault(e => e.CaseNo == CaseNumber);
            if (c != null)
            {
                ViewBag.caseDetail = c;
                return View("ViewCaseInfo");
            }
            Response.StatusCode = 500;
            return SendErrorResponse("Internal Server Error", "Unknown Error Occured");
        }
    }
}
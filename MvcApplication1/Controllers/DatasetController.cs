using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using Microsoft.Office.Interop.Excel;
using MvcApplication1.Library;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MvcApplication1.Controllers
{
    public class DatasetController : BaseController
    {
        public DatasetController()
            : base()
        {

        }
        // GET: Dataset
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ModifySearchFields()
        {
            try
            { 
                ViewBag.SearchFields = user.SearchFields.ToList();
            }
            catch (Exception o)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", o.Message);
            }

            return View("EditSearchFields");
        }

        [HttpPost]
        public ActionResult ModifySearchFields(FormCollection fc)
        {
            string[] list = fc.AllKeys;
            try
            {
                foreach (var key in SearchField.AllFields)
                {
                    if (list.Contains(key))
                    {
                        var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key));
                        if (f != null)
                        {
                            if(f.Show == false)
                                f.Show = true;
                        }
                        else
                        {
                            Response.StatusCode = 400;
                            return SendErrorResponse("Bad Request", "The field Name doesnot exist.");
                        }

                    }
                    else
                    {
                        var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key));
                        if (f != null)
                        {

                            if (f.Show == true)
                            {
                                f.Show = false;
                            }
                            
                        }
                        else
                        {
                            Response.StatusCode = 400;
                            return SendErrorResponse("Bad Request", "The field Name doesnot exist.");
                        }
                    }
                }
                user.SaveChanges();
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return SendAjaxResponse("ok", new
            {
                message = "Successfully Saved Data."
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult BirdEyeView()
        {
            try { 
                List<CasePaper> dataset = user.CasePapers.ToList();
                ViewBag.Countries = CasePaper.Countries;
                ViewBag.Courts = CasePaper.Courts;
                ViewBag.Suits = CasePaper.Suits;
                ViewBag.Statuses = CasePaper.Statuses;
                ViewBag.Dataset = dataset;
            } 
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return View("BirdEyeView");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult BirdEyeView(List<InputDatasetRequest> dataset)
        {
            try
            {
                for (var i = 0; i < dataset.Count; i++)
                {
                    var data = dataset[i].data;
                    if (dataset[i].type == "new" && data != null)
                    {
                        for (var j = 0; j < data.Count; j++)
                        {
                            //user.CasePapers.Add(data[0]);
                            CasePaper c = data[j].ConvertToDatabaseModel();
                            if (!TryValidateModel(c))
                            {
                                if (!ModelState.IsValid)
                                {
                                    string errors = "";
                                    foreach (var val in ModelState.Values)
                                    {
                                        foreach (var err in val.Errors)
                                        {
                                            errors += "<br> - " + err.ErrorMessage;
                                        }
                                    }
                                    Response.StatusCode = 400;
                                    return SendErrorResponse("Bad Request", "Field Validation Failed for Case Number "+ c.CaseNo +" : " + errors);
                                }
                            }
                            else
                            {
                                ModelState.Clear();
                            }
                            user.CasePapers.Add(c);
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
                                if (updatedCase != null)
                                {
                                    data[j].ConvertToDatabaseModel(ref updatedCase);
                                }
                                else
                                {
                                    Response.StatusCode = 400;
                                    return SendErrorResponse("Bad Request", "Field Validation Failed for Case Number "+updatedCase.CaseNo);
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
                                var c = user.CasePapers.Where(e => e.Id == id);
                                if (c.ToList().Count == 0)
                                {
                                    Response.StatusCode = 400;
                                    return SendErrorResponse("Bad Request", "Field Validation Failed for Id : "+id);
                                }
                                user.CasePapers.RemoveRange(c);
                            }
                        }
                    }
                }
                user.SaveChanges();
            } catch(Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return SendRedirectResponse("/Dataset/BirdEyeView");
        }

        [HttpGet]
        public ActionResult Search()
        {
            try
            {
                var fc = Request.QueryString;
                //caseSearch compulsory
                string searchStyle = fc["searchStyle"];
                if (string.IsNullOrEmpty(searchStyle))
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Search Style field invalid");
                }
                if (fc["caseSearch"] == null)
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "caseSearch field is required");
                }
                string saveSearch = fc["saveSearch"];
                List<SearchField> fields = new List<SearchField>();
                /*fields.Add(new SearchField
                {
                    FieldName = "Case In Detail"
                });*/
                if (searchStyle == "caseNo")
                {
                    fields.Add(new SearchField
                    {
                        FieldName = "CaseNo"
                    });
                }
                else if (searchStyle == "fielded")
                {
                    List<SearchField> d = user.SearchFields.Where(f => f.Show == true).ToList();
                    fields.AddRange(d);
                }
                else
                {
            
                Response.StatusCode = 400;
                return SendErrorResponse("Bad Request", "Valiation of fields failed");
            
                }

                List<InputSearchField> inputList = new List<InputSearchField>();
                var i = 0;
                for (i = 0; i < fields.Count; i++)
                {
                    InputSearchField f = InputSearchFields.getInputSearchField(fields[i].FieldName, null, false, null);
                    if (f.name == "caseSearch" || (fc[f.name] != null))
                    {
                        f.value = fc[f.name];
                        inputList.Add(f);
                    }

                }
                SqlQuery q = InputSearchFields.getSqlQuery(inputList, fc);
                var cases = user.CasePapers.SqlQuery(q.queryString, q.parameters.ToArray()).ToList();
                /*List<List<InputSearchField>> casesList = new List<List<InputSearchField>>();
                for (i = 0; i < cases.Count; i++)
                {
                    List<InputSearchField> t = new List<InputSearchField>();
                    for (var j = 0; j < fields.Count; j++)
                    {
                        InputSearchField f = InputSearchFields.getInputSearchField(fields[j].FieldName, cases[i], false, null);
                        t.Add(f);
                    }
                    casesList.Add(t);
                }*/
                ViewBag.caseResults = cases;
                if (saveSearch != null && saveSearch == "1")
                {
                    var tempFc = HttpUtility.ParseQueryString(fc.ToString());
                    tempFc["saveSearch"] = "0";
                    var s = user.SearchHistory.OrderBy(x => x.SearchDate).ToList();
                    if (s.Count >= 9)
                    {
                        s[0].SearchString = tempFc.ToString();
                        s[0].SearchDate = DateHelper.getMillisecondsFromEpoch();
                    }
                    else
                    {
                        History h = new History();
                        h.Id = Guid.NewGuid().ToString();
                        h.SearchDate = DateHelper.getMillisecondsFromEpoch();
                        h.SearchString = tempFc.ToString();
                        user.SearchHistory.Add(h);
                    }
                    user.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return View("SearchResults");
        }
        

    [HttpGet]
        public ActionResult CaseInfo()
        {
            try
            {
                var CaseNumber = Request.QueryString["caseNo"];
                if (string.IsNullOrEmpty(CaseNumber))
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "caseNo required");
                }
                CasePaper c = user.CasePapers.FirstOrDefault(e => e.CaseNo == CaseNumber);

                if (c != null)
                {

                    ViewBag.caseDetail = c;
                    return View("ViewCaseInfo");
                } else
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Case number doesnot exist");
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CaseInfo(FormCollection fc)
        {
            try
            {
                var CaseNumber = Request.QueryString["caseNo"];
                if (string.IsNullOrEmpty(CaseNumber))
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "caseNo required");
                }
                CasePaper c = user.CasePapers.FirstOrDefault(e => e.CaseNo == CaseNumber);
                if (c != null)
                {
                    InputDataset i = new InputDataset(fc);
                    i.ConvertToDatabaseModel(ref c);
                    user.SaveChanges();
                } else
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Case number doesnot exist.");
                }

                return SendAjaxResponse("ok", new
                {
                    message = "Case Edited Successfully."
                });
            }
            catch(Exception e)
            { 
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
        }

        public ActionResult Download()
        {
            try
            {
                var CaseNumber = Request.QueryString["caseNo"];
                var fileType = Request.QueryString["format"];
                if (string.IsNullOrEmpty(CaseNumber) || string.IsNullOrEmpty(fileType))
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Required parameters missing");
                }
                var caseNoList = CaseNumber.Split(',');
                if (caseNoList.Length == 0)
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Bad parameters");
                }

                if (caseNoList.Length > 10)
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Please choose less than 10 files for downloading. Current download limit is restricted to 10.");
                }
                var caseList = user.CasePapers.Where(e => caseNoList.Contains(e.CaseNo)).ToList();
                string[] columns = {   "CaseNo", "Plaintiff", "Defendant","Country",
                                   "DateOfFiling", "CourtOfLaw","Sequel","JudgeName",
                                   "TypeOfSuit","RelatedTo", "UnderSection","PatentsAtIssue",
                                   "CaseSummary", "CourtInterpretation", "DateOfJudgement", "CaseDecision",
                                   "FurtherAppeals", "Status", "CaseInDetail"};
                string fileName = null;
                string absoluteFilePath = null;
                byte[] fileData = null;
                if (fileType == "xlsx")
                {
                    Application app = new Application();
                    Workbook workbook = null;
                    Worksheet worksheet = null;
                    //app.Visible = true;
                    workbook = app.Workbooks.Add(1);
                    worksheet = (Worksheet)workbook.Sheets[1];
                    for (var j = 0; j < columns.Length; j++)
                    {

                        worksheet.Cells[1, (j + 1)] = InputSearchFields.getInputSearchField(columns[j], null, false, null).label;
                    }

                    for (var i = 0; i < caseList.Count; i++)
                    {
                        for (var j = 0; j < columns.Length; j++)
                        {
                            InputSearchField f = InputSearchFields.getInputSearchField(columns[j], caseList[i], false, null);
                            string val;
                            if (j == 3)
                            {
                                val = CasePaper.Countries[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 4)
                            {
                                val = DateHelper.convertToDateTime(Convert.ToInt64(f.value)).ToLongDateString();
                            }
                            else if (j == 5)
                            {
                                val = CasePaper.Courts[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 8)
                            {
                                val = CasePaper.Suits[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 14)
                            {
                                val = DateHelper.convertToDateTime(Convert.ToInt64(f.value)).ToLongDateString();
                            }
                            else if (j == 17)
                            {
                                val = CasePaper.Statuses[Convert.ToInt32(f.value) - 1];
                            }
                            else
                            {
                                val = f.value;
                            }

                            worksheet.Cells[(i + 2), (j + 1)] = val;
                        }

                    }
                    fileName = DateHelper.getMillisecondsFromEpoch() + ".xlsx";
                    absoluteFilePath = absoluteFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                    workbook.SaveAs(absoluteFilePath);
                    workbook.Close();
                    fileData = System.IO.File.ReadAllBytes(absoluteFilePath);
                    System.IO.File.Delete(absoluteFilePath);
                }
                else if (fileType == "pdf")
                {
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    Paragraph para;
                    for (var i = 0; i < caseList.Count; i++)
                    {
                        for (var j = 0; j < columns.Length; j++)
                        {

                            InputSearchField f = InputSearchFields.getInputSearchField(columns[j], caseList[i], false, null);
                            string val;
                            if (j == 3)
                            {
                                val = CasePaper.Countries[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 4)
                            {
                                val = DateHelper.convertToDateTime(Convert.ToInt64(f.value)).ToLongDateString();
                            }
                            else if (j == 5)
                            {
                                val = CasePaper.Courts[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 8)
                            {
                                val = CasePaper.Suits[Convert.ToInt32(f.value) - 1];
                            }
                            else if (j == 14)
                            {
                                val = DateHelper.convertToDateTime(Convert.ToInt64(f.value)).ToLongDateString();
                            }
                            else if (j == 17)
                            {
                                val = CasePaper.Statuses[Convert.ToInt32(f.value) - 1];
                            }
                            else
                            {
                                val = f.value;
                            }
                            para = new Paragraph("");
                            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, false);

                            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12);
                            Chunk chunk = new Chunk("" + f.label, times);
                            para.Add(chunk);
                            bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
                            chunk = new Chunk(" : " + val, new iTextSharp.text.Font(bfTimes, 12));
                            para.Add(chunk);
                            document.Add(para);
                        }
                        document.NewPage();
                    } 


                    document.Close();
                    fileData = memoryStream.ToArray();
                    fileName = DateHelper.getMillisecondsFromEpoch() + ".pdf";
                    memoryStream.Close();
                }
                else
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Field validation failed. Please provide proper fields.");
                }

                if (fileData != null && fileName != null)
                {
                    return File(fileData, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                }
                else
                {
                    Response.StatusCode = 400;
                    return SendErrorResponse("Bad Request", "Error generating files.");
                }
            }
            catch(Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }


    }

        public ActionResult SearchHistory()
        {
            try
            {
                var history = user.SearchHistory.OrderByDescending(x => x.SearchDate).ToList();
                ViewBag.history = history;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return SendErrorResponse("Internal Server Error", e.Message);
            }
            return View("SearchHistory");
        }
    }
}
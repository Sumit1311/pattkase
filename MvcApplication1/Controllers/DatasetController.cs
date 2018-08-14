using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.Entity;
using System.Text;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using MvcApplication1.Library;
using iTextSharp.text;
using iTextSharp.text.pdf.fonts;
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
            ViewBag.SearchFields = user.SearchFields.ToList();

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
                        var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key && e.Show == false));
                        if (f != null)
                        {
                            f.Show = true;
                        }

                    }
                    else
                    {
                        var f = user.SearchFields.FirstOrDefault(e => (e.FieldName == key && e.Show == true));
                        if (f != null)
                        {
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
                message = "Successfully Saved Data."
            });
        }
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
                            if (updatedCase != null)
                            {
                                data[j].ConvertToDatabaseModel(ref updatedCase);
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

        [HttpGet]
        public ActionResult Search()
        {
            var fc = Request.QueryString;
            //caseSearch compulsory
            string searchStyle = fc["searchStyle"];
            string saveSearch = fc["saveSearch"];
            List<SearchField> fields = new List<SearchField>();
            fields.Add(new SearchField
            {
                FieldName = "Case In Detail"
            });
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
            List<List<InputSearchField>> casesList = new List<List<InputSearchField>>();
            for (i = 0; i < cases.Count; i++)
            {
                List<InputSearchField> t = new List<InputSearchField>();
                for (var j = 0; j < fields.Count; j++)
                {
                    InputSearchField f = InputSearchFields.getInputSearchField(fields[j].FieldName, cases[i], false, null);
                    t.Add(f);
                }
                casesList.Add(t);
            }
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
            return View("SearchResults");
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CaseInfo(FormCollection fc)
        {
            var CaseNumber = Request.QueryString["caseNo"];
            CasePaper c = user.CasePapers.FirstOrDefault(e => e.CaseNo == CaseNumber);
            if (c != null)
            {
                InputDataset i = new InputDataset(fc);
                i.ConvertToDatabaseModel(ref c);
                user.SaveChanges();
            }

            return SendAjaxResponse("ok", new
            {
                message = "Case Edited Successfully."
            });
        }

        public ActionResult Download()
        {
            var CaseNumber = Request.QueryString["caseNo"];
            var fileType = Request.QueryString["format"];
            var caseNoList = CaseNumber.Split(',');
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
                        para = new Paragraph("") ;
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
            if (fileData != null && fileName != null)
            {
                return File(fileData, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchHistory()
        {
            var history = user.SearchHistory.OrderByDescending(x => x.SearchDate).ToList();
            ViewBag.history = history;
            return View("SearchHistory");
        }
    }
}
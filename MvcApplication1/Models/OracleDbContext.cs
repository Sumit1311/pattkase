using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFramework.Functions;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcApplication1.Library;
using System.Globalization;

namespace MvcApplication1.Models
{
    public class InputDataset
    {
        public string id { get; set; }
        public string caseNo { get; set; }
        public string plaintiff { get; set; }
        public string defendant { get; set; }
        public int country { get; set; }
        public Int64 dateOfFiling { get; set; }
        public int courtOfLaw { get; set; }
        public string sequel { get; set; }
        public string judgeName { get; set; }
        public int typeOfSuit { get; set; }
        public string relatedTo { get; set; }
        public string underSection { get; set; }
        public string patentsAtIssue { get; set; }
        public string caseSummary { get; set; }
        public string courtInterpretation { get; set; }
        public Int64 dateOfJudgement { get; set; }
        public string caseDecision { get; set; }
        public string furtherAppeals { get; set; }
        public int status { get; set; }
        public string caseInDetail { get; set; }
        public string flowchart { get; set; }

        public InputDataset() : base() {
            
        }

        public InputDataset(FormCollection fc)
        {
            plaintiff = fc["plaintiff"];
        defendant = fc["defendant"];
         country = Convert.ToInt32(fc["country"]);
         dateOfFiling = DateHelper.getMillisecondsFromEpoch(fc["dateOfFiling"]);
         courtOfLaw = Convert.ToInt32(fc["courtOfLaw"]);
        sequel = fc["sequel"];
        judgeName = fc["judgeName"];
         typeOfSuit = Convert.ToInt32(fc["typeOfSuit"]);
        relatedTo = fc["relatedTo"];
        underSection = fc["underSection"];
        patentsAtIssue = fc["patentsAtIssue"];
        caseSummary = fc["caseSummary"] != null ? fc["caseSummary"].Replace("\r\n", " ") : fc["caseSummary"];
        courtInterpretation = fc["courtInterpretation"] != null ? fc["courtInterpretation"].Replace("\r\n", " ") : fc["courtInterpretation"];
            
        dateOfJudgement = DateHelper.getMillisecondsFromEpoch(fc["dateOfJudgement"]);
        caseDecision = fc["caseDecision"] != null ? fc["caseDecision"].Replace("\r\n", " ") : fc["caseDecision"];
        furtherAppeals = fc["furtherAppeals"];
        status = Convert.ToInt32(fc["status"]);
        caseInDetail = fc["caseInDetail"] != null ? fc["caseInDetail"].Replace("\r\n", " ") : fc["caseInDetail"];
        }

        public CasePaper ConvertToDatabaseModel()
        {
            CasePaper n = new CasePaper();
            n.Id = Guid.NewGuid().ToString();
            if (caseNo != null)
            {
                n.CaseNo = caseNo;
            }
            if(plaintiff != null)
            {
                n.Plaintiff = plaintiff;
            }
            if(defendant != null)
            {
                n.Defendant = defendant;
            }
            if (country != 0)
            {
                n.Country = country;
            }
            if (dateOfFiling != 0)
            {
                n.DateOfFiling = dateOfFiling;
            }
            if (courtOfLaw != 0)
            {
                n.CourtOfLaw = courtOfLaw;
            }
            if(sequel != null)
            {
                n.Sequel = sequel;
            }
            if(judgeName != null)
            {
                n.JudgeName = judgeName;
            }
            if (typeOfSuit != 0)
            {
                n.TypeOfSuit = typeOfSuit;
            }
            if (relatedTo != null)
            {
                n.RelatedTo = relatedTo;
            }
            if (underSection != null)
            {
                n.UnderSection = underSection;
            }
            if (patentsAtIssue != null)
            {
                n.PatentsAtIssue = patentsAtIssue;
            }
            if (caseSummary != null)
            {
                n.CaseSummary = caseSummary;
            }
            if (courtInterpretation != null)
            {
                n.CourtInterpretation = courtInterpretation;
            }
            if (dateOfJudgement != 0)
            {
                n.DateOfJudgement = dateOfJudgement;
            }
            if (caseDecision != null)
            {
                n.CaseDecision = caseDecision;
            }
            if(furtherAppeals != null)
            {
                n.FurtherAppeals = furtherAppeals;

            }
            if(status != 0)
            {
                n.Status = status;
            }
            if(caseInDetail != null)
            {
                n.CaseInDetail = caseInDetail;
            }
            if (flowchart != null)
            {
                n.FlowChart = flowchart;
            }
            return n;
        }

        public void ConvertToDatabaseModel(ref CasePaper n)
        {
            if (caseNo != null)
            {
                n.CaseNo = caseNo;
            }
            if(plaintiff != null)
            {
                n.Plaintiff = plaintiff;
            }
            if(defendant != null)
            {
                n.Defendant = defendant;
            }
            if (country != 0)
            {
                n.Country = country;
            }
            if (dateOfFiling != 0)
            {
                n.DateOfFiling = dateOfFiling;
            }
            if (courtOfLaw != 0)
            {
                n.CourtOfLaw = courtOfLaw;
            }
            if(sequel != null)
            {
                n.Sequel = sequel;
            }
            if(judgeName != null)
            {
                n.JudgeName = judgeName;
            }
            if (typeOfSuit != 0)
            {
                n.TypeOfSuit = typeOfSuit;
            }
            if (relatedTo != null)
            {
                n.RelatedTo = relatedTo;
            }
            if (underSection != null)
            {
                n.UnderSection = underSection;
            }
            if (patentsAtIssue != null)
            {
                n.PatentsAtIssue = patentsAtIssue;
            }
            if (caseSummary != null)
            {
                n.CaseSummary = caseSummary;
            }
            if (courtInterpretation != null)
            {
                n.CourtInterpretation = courtInterpretation;
            }
            if (dateOfJudgement != 0)
            {
                n.DateOfJudgement = dateOfJudgement;
            }
            if (caseDecision != null)
            {
                n.CaseDecision = caseDecision;
            }
            if(furtherAppeals != null)
            {
                n.FurtherAppeals = furtherAppeals;

            }
            if(status != 0)
            {
                n.Status = status;
            }
            if(caseInDetail != null)
            {
                n.CaseInDetail = caseInDetail;
            }
            if (flowchart != null)
            {
                n.FlowChart = flowchart;
            }
        }
    }
    public class InputDatasetRequest
    {
        public string type { get; set; }

        public IList<InputDataset> data { get; set; }
    }


    public class AppLogin : IdentityUserLogin { }

    public class AppRole : IdentityUserRole { }

    public class ApplicationRole : IdentityRole {
        public ApplicationRole()
            : base()
        {

            
        }

        public ApplicationRole(string name) : base(){
            
            this.Name = name;
        }
    }

    public class Login : IdentityUser
    {
        //[Key]       
        //public override string Id{ get; set; }
        //[StringLength(255, MinimumLength = 3, ErrorMessage = "My Error Message")]
        //public string UserName { get; set; }
        //[StringLength(255, MinimumLength = 3, ErrorMessage = "My Error Message")]
        //public string Password{ get; set; }
        [StringLength(255)]
        public string RequesterRefId { get; set; }
        public Requester Requester { get; set; }
        //public string Location { get; set; }
    }

    public class Requester {

        public static string[] Professions = 
        {
            "Profession A",
            "Profession B",
            "Profession C"
        };

        public static string[] statuses =
        {
            "Active",
            "Inactive"

        };
        const int numOfProfessions = 2, numOfStatuses = 1;
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50, ErrorMessage = "Fullname Length Exceeded. Max length 50")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address Length Exceeded. Max Length 100")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Name Of Organization is required.")]
        [StringLength(50, ErrorMessage = "Name of Organization Length Exceeded. Max Length 50")]
        public string NameOfOrganization { get; set; }
        [Required(ErrorMessage = "Email Id is required.")]
        [StringLength(100, ErrorMessage = "Email Id Length Exceeded. Max Length 100")]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Profession is required.")]
        [Range(0, numOfProfessions)]
        public int Profession { get; set; }
        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(200, ErrorMessage = "Purpose Length Exceeded. Max Length 200")]
        public string Purpose { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

        //public Login Login { get; set; }
        //[ForeignKey("RequesterRefId")]
        //public ICollection<Login> Logins {get; set;}
    }

    public class History
    {
        [Key]
        public string Id {get; set;}
        [Column(TypeName = "varchar2")]
        public string SearchString { get; set; }
        public Int64 SearchDate { get; set; }
    }

    public class CasePaper
    {
        public CasePaper() { }
        public static  string[] Countries = 
        {
          "India",
          "US",
          "Other"
        };
        public static string[] Courts = 
        {
            "District Court (DC)",
            "High Court (HC)",
            "Supreme Court (SC)"
        };
        public static string[] Suits =
        {
            "Patenting",
            "Novelty",
            "Subject Matter",
            "Obviousness"
        };
        public static string[] Statuses =
        {
               "Active",
               "Inactive"
        };
        const int numOfCountries = 3, numOfCourts = 3, numOfSuits = 4, numOfStatuses = 2;
        [Key]
        public string Id { get; set; }
        [StringLength(100, ErrorMessage = "Case Number Length Exceeded Limit. Max Length is 100")]
        public string CaseNo { get; set; }
        [StringLength(100,  ErrorMessage = "Plaintiff Length Exceeded Limit. Max Length is 100")]
        public string Plaintiff { get; set; }
        [StringLength(100,  ErrorMessage = "Defendant Length Exceeded Limit. Max Length is 100")]
        public string Defendant { get; set; }
        [Range(1, numOfCountries, ErrorMessage = "The country range is invalid.")]
        public int Country { get; set; }
        public Int64 DateOfFiling { get; set; }
        [Range(1, numOfCourts, ErrorMessage = "The court of law range is invalid.")]
        public int CourtOfLaw { get; set; }
        [StringLength(100, ErrorMessage = "Sequel length exceeded. Max length is 100")]
        public string Sequel { get; set; }
        [StringLength(100, ErrorMessage = "Judge Name length exceeded. Max length is 100")]
        public string JudgeName { get; set; }
        [Range(1, numOfSuits, ErrorMessage = "The type of suit range is invalid.")]
        public int TypeOfSuit { get; set; }
        [StringLength(500, ErrorMessage = "Related to length Exceeded. Max length is 500")]
        public string RelatedTo { get; set; }
        [StringLength(100, ErrorMessage = "Under section length exceeded. Max length is 100")]
        public string UnderSection { get; set; }
        [StringLength(500, ErrorMessage = "Patents at issue length exceeded. Max length is 500")]
        public string PatentsAtIssue { get; set; }
        [StringLength(2000, ErrorMessage = "Case Summary length exceeded. Max length is 2000")]
        public string CaseSummary { get; set; }
        [StringLength(1000, ErrorMessage = "Court Interpretation length exceeded. Max length is 1000")]
        public string CourtInterpretation { get; set; }
        public Int64 DateOfJudgement { get; set; }
        [StringLength(2000, ErrorMessage = "Case Decision length exceeded. Max length is 2000")]
        public string CaseDecision { get; set; }
        [StringLength(500, ErrorMessage = "Further Appeals length exceeded. Max length is 500")]
        public string FurtherAppeals { get; set; }
        [Range(1, numOfStatuses, ErrorMessage = "The status range is invalid.")]
        public int Status { get; set; }
        [Column(TypeName = "varchar2")]
        [MaxLength(4000, ErrorMessage = "Case In Detail length exceeded. Max length is 4000")]
        public string CaseInDetail { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string FlowChart { get; set; }
    }

    public class SearchField
    {
        public static string[] AllFields = 
        {
            "Plaintiff",
            "Defendant",
            "Date Of Filing",
            "Court Of Law",
            "Sequel",
            "Judge Name",
            "Type Of Suit",
            "Related To",
            "Under Section",
            "Patents At Issue",
            "Court Interpretation",
            "Date Of Judgement",
            //"Case Decision",
            "Further Appeals",
            "Status",
            "Keyword 1",
            "Keyword 2",
            "Country"
        };
        [Key]
        public string Id { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string FieldName { get; set; }
        public bool Show { get; set; }

       
    }

    

    public class InputSearchField
    {
        public string fieldType { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string element { get; set; }
        public bool isReadOnly { get; set; }
    }

    public class InputSearchFields
    {
        public static InputSearchField getInputSearchField(string field, CasePaper c, bool isReadOnly, string value)
        {
            InputSearchField f = new InputSearchField( );
            if (value != null)
            {
                f.value = value;
            }
            switch(field)
            {
                case "caseNo":
                case "CaseNo":
                    //f.element ="<input type=\"text\" class=\"form-control\" id=\"exampleInputEmail1\" aria-describedby=\"emailHelp\" name=\"plaintiff\" placeholder=\"Plaintiff\">";
                    f.fieldType = "text";
                    f.label = "Case Number";
                    f.name = "caseNo";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseNo;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "plaintiff":
                case "Plaintiff":
                    //f.element ="<input type=\"text\" class=\"form-control\" id=\"exampleInputEmail1\" aria-describedby=\"emailHelp\" name=\"plaintiff\" placeholder=\"Plaintiff\">";
                    f.fieldType = "text";
                    f.label = "Plaintiff";
                    f.name = "plaintiff";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Plaintiff;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "defendant":
                case "Defendant":
                    f.fieldType = "text";
                    f.label = "Defendant";
                    f.name = "defendant";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Defendant;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "dateOfFiling":
                case "DateOfFiling":
                case "Date Of Filing":
                    f.fieldType = "date";
                    f.label = "Date Of Filing";
                    f.name = "dateOfFiling";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.DateOfFiling.ToString();
                    }

                    f.element = getElementFromType(f);
                    break;
                case "courtOfLaw":
                case "CourtOfLaw":
                case "Court Of Law":
                    f.fieldType = "dropdown";
                    f.label = "Court Of Law";
                    f.name = "courtOfLaw";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Country.ToString();
                    }
                    f.element = getElementFromType(f);
                    break;
                case "sequel":
                case "Sequel":
                    f.fieldType = "text";
                    f.label = "Sequel";
                    f.name = "sequel";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Sequel;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "judgeName":
                case "JudgeName":
                case "Judge Name":
                    f.fieldType = "text";
                    f.label = "Judge Name";
                    f.name = "judgeName";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.JudgeName;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "typeOfSuit":
                case "TypeOfSuit":
                case "Type Of Suit":
                    f.fieldType = "dropdown";
                    f.label = "Type Of Suit";
                    f.name = "typeOfSuit";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.TypeOfSuit.ToString();
                    }
                    f.element = getElementFromType(f);
                    break;
                case "relatedTo":
                case "RelatedTo":
                case "Related To":
                    f.fieldType = "text";
                    f.label = "Related To";
                    f.name = "relatedTo";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.RelatedTo;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "underSection":
                case "UnderSection":
                case "Under Section":
                    f.fieldType = "text";
                    f.label = "Under Section";
                    f.name = "underSection";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.UnderSection;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "patentsAtIssue":
                case "PatentsAtIssue":
                case "Patents At Issue":
                    f.fieldType = "text";
                    f.label = "Patents At Issue";
                    f.name = "patentsAtIssue";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.PatentsAtIssue;
                    }
                    f.element = getElementFromType(f);
                    break;
                
                case "CourtInterpretation":
                    f.fieldType = "textarea";
                    f.label = "Court Interpretation";
                    f.name = "courtInterpretation";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CourtInterpretation;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "courtInterpretation":
                case "Court Interpretation":
                    f.fieldType = "text";
                    f.label = "Court Interpretation";
                    f.name = "courtInterpretation";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CourtInterpretation;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "dateOfJudgement":
                case "DateOfJudgement":
                case "Date Of Judgement":
                    f.fieldType = "date";
                    f.label = "Date Of Judgement";
                    f.name = "dateOfJudgement";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.DateOfJudgement.ToString();
                    }
                    f.element = getElementFromType(f);
                    break;
/*                case "Case Decision":
                    f.fieldType = "text";
                    f.label = "Case Decision";
                    f.name = "caseDecision";
                    if (c != null)
                    {
                        f.value = c.CaseDecision;
                    }
                    break;*/
                case "furtherAppeals":
                case "FurtherAppeals":
                case "Further Appeals":
                    f.fieldType = "text";
                    f.label = "Further Appeals";
                    f.name = "futherAppeals";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.FurtherAppeals;
                    }

                    f.element = getElementFromType(f);
                    break;
                case "status":
                case "Status":
                    f.fieldType = "dropdown";
                    f.label = "Status";
                    f.name = "status";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Status.ToString();
                    }
                    f.element = getElementFromType(f);
                    break;
                case "CaseSummary":
                    f.fieldType = "textarea";
                    f.label = "Case Summary";
                    f.name = "caseSummary";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseSummary;
                    }
                    f.element = getElementFromType(f);
                    break;
                case "caseSummary":
                case "Keyword 1":
                    f.fieldType = "text";
                    f.label = "Keyword 1";
                    f.name = "key1";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseSummary;
                    }
                    f.element = getElementFromType(f);
                    break;
                
                case "CaseDecision":
                    f.fieldType = "textarea";
                    f.label = "Case Decision";
                    f.name = "caseDecision";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseDecision;
                    }

                    f.element = getElementFromType(f);
                    break;
                case "caseDecision":
                case "Keyword 2":
                    f.fieldType = "text";
                    f.label = "Keyword 2";
                    f.name = "key2";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseDecision;
                    }

                    f.element = getElementFromType(f);
                    break;
                case "country":
                case "Country":
                    f.fieldType = "dropdown";
                    f.label = "Country";
                    f.name = "country";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.Country.ToString();
                    }
                    f.element = getElementFromType(f);
                    break;
                case "CaseInDetail":
                    f.fieldType = "textarea";
                    f.label = "Case In Detail";
                    f.name = "caseInDetail";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseInDetail;
                    }

                    f.element = getElementFromType(f);
                    break;
                case "caseSearch":
                case "Case In Detail":
                    f.fieldType = "text";
                    f.label = field == "caseSearch" ? "Case Search" : "Case In Detail";
                    f.name = "caseSearch";
                    f.isReadOnly = isReadOnly;
                    if (c != null)
                    {
                        f.value = c.CaseInDetail;
                    }

                    f.element = getElementFromType(f);
                    break;
                case "searchStyle":
                    f.fieldType = "text";
                    f.label = "Case Search Style";
                    f.name = "searchStyle";
                    f.isReadOnly = isReadOnly;
                    f.element = getElementFromType(f);
                    break;         
                /*default :
                    f = null;
                    break;*/
            }
            return f;
        }
        public static string getInputElement(string field)
        {
            InputSearchField f = InputSearchFields.getInputSearchField(field, null, false, null);
            return getElementFromType(f);
            
        }

        public static string getElementFromType(InputSearchField f)
        {
            string element;
            if (f.fieldType == "text")
            {
                element = "<input type=\"text\"" + (f.isReadOnly ? "class=\"form-control-plaintext\" readonly" : "class=\"form-control\"") + " name=\"" + f.name + "\" id=\"_nav_search_field_" + f.name + "\" placeholder=\"" + f.label + "\" value=\"" + f.value + "\">";

            }
            else if (f.fieldType == "dropdown")
            {
                element = "<select name =\"" + f.name + "\"" + (f.isReadOnly ? "class=\"form-control-plaintext\" readonly disabled" : " class=\"custom-select\"")+"> " +
                    "<option "+(f.value == "" ? "selected" : "" )+" value = \"0\"> Select " + f.label + "</option>";

                string[] c;
                if (f.name == "country")
                {
                    c = CasePaper.Countries;

                }
                else if (f.name == "typeOfSuit")
                {
                    c = CasePaper.Suits;
                }
                else if (f.name == "status")
                {
                    c = CasePaper.Statuses;
                }
                else if (f.name == "courtOfLaw")
                {
                    c = CasePaper.Courts;
                }
                else
                {
                    c = null;
                }
                if (c != null)
                {
                    for (var i = 0; i < c.Length; i++)
                    {
                        element += "<option "+ ((f.value != "" && Convert.ToInt32(f.value) == (i+1)) ? "selected " : "")+ "value=\"" + (i + 1) + "\">" + c[i] + "</option>";
                    }
                }
                element += "</select>";

            }
            else if (f.fieldType == "date")
            {
                string val = ((f.value != "" && f.value != null) ? DateHelper.convertToDateTime(Convert.ToInt64(f.value)).ToString(DateHelper.dateFormat) : "");
                element = "<input type=\"text\" "+ (f.isReadOnly ? "class=\"form-control-plaintext datepicker\" readonly disabled" : "class=\"form-control datepicker\"")+" name=\"" + f.name + "\" id=\"_nav_search_field_" + f.name + "\" placeholder=\"" + f.label + "\" value=\""+ val +"\">";
            }
            else if (f.fieldType == "textarea")
            {
                element = "<textarea " + (f.isReadOnly ? "class=\"form-control-plaintext\" readonly disabled" : "class=\"form-control\"") + " name=\"" + f.name + "\" id=\"_nav_search_field_" + f.name + "\" placeholder=\"" + f.label + "\">"+f.value+" </textarea>";
            }
            else
            {
                element = "";
            }
            return element;
        }

        public static SqlQuery getSqlQuery(List<InputSearchField> fields, NameValueCollection fc)
        {
            string selectClause = "SELECT * ";
            string fromClause = "FROM hr.\"CasePapers\"";
            string whereClause = "WHERE ";
            List<object> parameters = new List<object>();
            InputSearchField caseSearch = fields.Find(f => f.name == "caseSearch");
            whereClause += " UPPER(\"" + "CaseInDetail"+ "\")  LIKE '%' || :" + parameters.Count + "|| '%'";
            parameters.Add(caseSearch.value.ToUpper());
            for (var i = 0; i < fields.Count; i++)
            {
                InputSearchField f = fields[i];
                //InputSearchField f = InputSearchFields.getInputSearchField(fields[i].FieldName, null);
                if (f.name != "caseSearch" && (f.value != null))
                {
                    if (f.name == "caseNo")
                    {
                        if(f.value.Length >= 50)
                        {
                            throw new MvcApplication1.Library.ValidationException("Field validation failed. Case number max length is 50");
                        }
                        var columnName = "CaseNo";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator("1") + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%'";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "plaintiff")
                    {
                        if (f.value.Length >= 25)
                        {
                            throw new MvcApplication1.Library.ValidationException("Field validation failed. Plaintiff max length is 25");
                        }
                        
                        var columnName = "Plaintiff";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%'";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "defendant")
                    {
                        if (f.value.Length > 25)
                        {
                            throw new MvcApplication1.Library.ValidationException("Field validation failed. Defedant max length is 25");
                        }
                        var columnName = "Defendant";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \"" +columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "dateOfFiling")
                    {
                        if (f.value != "")
                        {
                            var columnName = "DateOfFiling";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(DateHelper.getMillisecondsFromEpoch(f.value));
                        }
                    }
                    else if (f.name == "courtOfLaw")
                    {
                        if (f.value != "" && f.value != "0" && Convert.ToInt32(f.value) < CasePaper.Courts.Length)
                        {
                            var columnName = "CourtOfLaw";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(Convert.ToInt32(f.value));
                        }
                        
                    }
                    else if (f.name == "sequel")
                    {
                        var columnName = "Sequel";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "judgeName")
                    {
                        if (f.value.Length > 50)
                        {
                            throw new MvcApplication1.Library.ValidationException("Field validation failed. Name Of Judge max length is 50");
                        }
                        var columnName = "JudgeName";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + " || '%'";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "typeOfSuit")
                    {
                        if (f.value != "" && f.value != "0" && Convert.ToInt32(f.value) < CasePaper.Suits.Length) 
                        { 
                            var columnName = "TypeOfSuit";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(Convert.ToInt32(f.value));
                        }
                    }
                    else if (f.name == "relatedTo")
                    {
                        var columnName = "RelatedTo";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "underSection")
                    {
                        var columnName = "UnderSection";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "patentsAtIssue")
                    {
                        var columnName = "PatentsAtIssue";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "courtInterpretation")
                    {
                        var columnName = "CourtInterpretation";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "dateOfJudgement")
                    {
                        if (f.value != "")
                        {
                            var columnName = "DateOfJudgement";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(DateHelper.getMillisecondsFromEpoch(f.value));
                        }
                        
                    }
                    else if (f.name == "caseDecision")
                    {
                        var columnName = "CaseDecision";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "furtherAppeals")
                    {
                        var columnName = "FutherAppeals";
                        //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + " UPPER(\"" + columnName + "\")  LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "status")
                    {
                        if (f.value != "" && f.value != "0" && Convert.ToInt32(f.value) < CasePaper.Statuses.Length)
                        {
                            var columnName = "Status";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(Convert.ToInt32(f.value));
                        }
                        
                    }
                    else if (f.name == "country")
                    {
                        if (f.value != "" && f.value != "0" && Convert.ToInt32(f.value) < CasePaper.Countries.Length)
                        {
                            var columnName = "Country";
                            //selectClause += (parameters.Count == 0 ? "" : "," )+" \""+columnName+"\"";
                            whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" = :" + parameters.Count + "";
                            parameters.Add(Convert.ToInt32(f.value));
                        }
                        
                    }
                    else if (f.name == "key1")
                    {
                        var columnName = "CaseSummary";
                        //selectClause += (parameters.Count == 0 ? "" : ",") + " \"" + columnName + "\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" LIKE '%' || :" + parameters.Count + " || '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    else if (f.name == "key2")
                    {
                        var columnName = "CaseDecision";
                        //selectClause += (parameters.Count == 0 ? "" : ",") + " \"" + columnName + "\"";
                        whereClause += (parameters.Count == 0 ? "" : " " + InputSearchFields.getOperator(fc["operator_" + f.name]) + " ") + "\"" + columnName + "\" LIKE '%' || :" + parameters.Count + "|| '%' ";
                        parameters.Add(f.value.ToUpper());
                    }
                    //Key1 and key2
                }
            }
            var query = selectClause + " " + fromClause + " " + whereClause;
                return new SqlQuery(query, parameters);
        }

        public static string getOperator(string option)
        {
            string[] opeartors = 
            {
                "AND",
                "OR",
                "NOT"
            };
            if (option == "0")
            {
                return "";
            }
            return opeartors[Convert.ToInt32(option) - 1];
        }




    }

    public class SqlQuery
    {
        public string queryString { get; private set; }
        public List<object> parameters { get; private set; }

        public SqlQuery(string query, List<object> paramList)
        {
            queryString = query; 
            parameters = paramList;
        }
    }
    
    public class ApplicationDbContext : IdentityDbContext<Login>
    {
        //public DbSet<Login> Logins { get; set; }
        public DbSet<Requester> Requesters { get; set; }
        public DbSet<CasePaper> CasePapers { get; set; }
        public DbSet<SearchField> SearchFields { get; set; }
        public DbSet<History> SearchHistory { get; set; }
         public ApplicationDbContext()
            : base()
        {
            foreach(var i in SearchField.AllFields)
            {
                var s = SearchFields.FirstOrDefault(e => (e.FieldName == i));
                if(s == null)
                {
                    SearchFields.Add(new SearchField
                    {
                        Id = Guid.NewGuid().ToString(),
                        FieldName = i,
                        Show = false
                    });
                }
            }
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<IdentityRole>().ToTable("AspIdentityRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspIdentityUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspIdentityUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspIdentityUserClaims");
            modelBuilder.Entity<Login>().ToTable("Logins");
            //modelBuilder.Entity<Login>().HasKey<string>(l => l.Id);
            //modelBuilder.Entity<Requester>().HasKey<string>(l => l.Id);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityUserRole>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.HasDefaultSchema("HR");
            /*modelBuilder.Entity<Requester>()
                .HasOne(a => a.Requester)
                .WithOne(b => b.Login)
                .HasForeignKey<Login>(b => b.RequesterRefId);*/
            base.OnModelCreating(modelBuilder);
        }
    }

    /*public class OracleDbContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Requester> Requesters { get; set; }
        public DbSet<AppLogin> AppLogins { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR");
            modelBuilder.Entity<Login>().HasKey<string>(l => l.Id);
            //modelBuilder.Entity<Requester>().HasKey<int>(r => r.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityRole>().ToTable("aspnetroles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetuserroles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetuserlogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetuserclaims");
            //modelBuilder.Entity<Login>().ToTable("aspnetroles");
            base.OnModelCreating(modelBuilder);

        }
        public void InitializeModel() {
            Login l = new Login
            {
                UserName = "admin@localhost.com",
                Password = "admin"
            };
            Logins.AddOrUpdate(h => h.UserName, l);
            this.SaveChanges();
        }
    }*/
}
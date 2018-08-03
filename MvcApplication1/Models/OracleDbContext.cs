using System;
using System.Collections.Generic;
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

namespace MvcApplication1.Models
{
    public class InputDataset
    {
        public string id { get; set; }
        public string caseNo { get; set; }
        public string plaintiff { get; set; }
        public string defendant { get; set; }
        public int country { get; set; }
        public int dateOfFiling { get; set; }
        public int courtOfLaw { get; set; }
        public string sequel { get; set; }
        public string judgeName { get; set; }
        public int typeOfSuit { get; set; }
        public string relatedTo { get; set; }
        public string underSection { get; set; }
        public string patentsAtIssue { get; set; }
        public string caseSummary { get; set; }
        public string courtInterpretation { get; set; }
        public int dateOfJudgement { get; set; }
        public string caseDecision { get; set; }
        public string furtherAppeals { get; set; }
        public int status { get; set; }
        public string caseInDetail { get; set; }
        public string flowchart { get; set; }

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

        public void ConvertToDatabaseModel(CasePaper n)
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

        [Key]
        public string Id { get; set; }

        [StringLength(255, ErrorMessage = "My Error Message")]
        public string FullName { get; set; }

        [StringLength(255, ErrorMessage = "My Error Message")]
        public string Address { get; set; }

        [StringLength(255, ErrorMessage = "My Error Message")]
        public string NameOfOrganization { get; set; }

        [StringLength(255, ErrorMessage = "My Error Message")]
        public string EmailId { get; set; }

        public int Profession { get; set; }

        [StringLength(255, ErrorMessage = "My Error Message")]
        public string Purpose { get; set; }

        public int Status { get; set; }

        //public Login Login { get; set; }
        //[ForeignKey("RequesterRefId")]
        //public ICollection<Login> Logins {get; set;}
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
        [Key]
        public string Id { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string CaseNo { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string Plaintiff { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string Defendant { get; set; }
        public int Country { get; set; }
        public Int64 DateOfFiling { get; set; }
        public int CourtOfLaw { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string Sequel { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string JudgeName { get; set; }
        public int TypeOfSuit { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string RelatedTo { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string UnderSection { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string PatentsAtIssue { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string CaseSummary { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string CourtInterpretation { get; set; }
        public Int64 DateOfJudgement { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string CaseDecision { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string FurtherAppeals { get; set; }
        public int Status { get; set; }
        [StringLength(10000, ErrorMessage = "My Error Message")]
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
            "Case Decision",
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
    }

    public class InputSearchFields
    {
        public static InputSearchField getInputSearchField(string field)
        {
            InputSearchField f = new InputSearchField( );
            switch(field)
            {
                case "Plaintiff":
                    //f.element ="<input type=\"text\" class=\"form-control\" id=\"exampleInputEmail1\" aria-describedby=\"emailHelp\" name=\"plaintiff\" placeholder=\"Plaintiff\">";
                    f.fieldType = "text";
                    f.label = "Plaintiff";
                    f.name = "plaintiff";
                    break;
                case "Defendant":
                    f.fieldType = "text";
                    f.label = "Defendant";
                    f.name = "defendant";
                    break;
                case "Date Of Filing":
                    f.fieldType = "date";
                    f.label = "Date Of Filing";
                    f.name = "dateOfFiling";
                    break;

                case "Court Of Law":
                    f.fieldType = "dropdown";
                    f.label = "Court Of Law";
                    f.name = "courtOfLaw";
                    break;
                case "Sequel":
                    f.fieldType = "text";
                    f.label = "Sequel";
                    f.name = "sequel";
                    break;
                case "Judge Name":
                    f.fieldType = "text";
                    f.label = "Judge Name";
                    f.name = "judgeName";
                    break;
                case "Type Of Suit":
                    f.fieldType = "dropdown";
                    f.label = "Type Of Suit";
                    f.name = "typeOfSuit";
                    break;
                case "Related To":
                    f.fieldType = "text";
                    f.label = "Related To";
                    f.name = "relatedTo";
                    break;
                case "Under Section":
                    f.fieldType = "text";
                    f.label = "Under Section";
                    f.name = "underSection";
                    break;
                case "Patents At Issue":
                    f.fieldType = "text";
                    f.label = "Patents At Issue";
                    f.name = "patentsAtIssue";
                    break;
                case "Court Interpretation":
                    f.fieldType = "text";
                    f.label = "Court Interpretation";
                    f.name = "courtInterpretation";
                    break;
                case "Date Of Judgement":
                    f.fieldType = "date";
                    f.label = "Date Of Judgement";
                    f.name = "dateOfJudgement";
                    break;
                case "Case Decision":
                    f.fieldType = "text";
                    f.label = "Case Decision";
                    f.name = "caseDecision";
                    break;
                case "Further Appeals":
                    f.fieldType = "text";
                    f.label = "Further Appeals";
                    f.name = "futherAppeals";
                    break;
                case "Status":
                    f.fieldType = "dropdown";
                    f.label = "Status";
                    f.name = "status";
                    break;
                   case "Keyword 1":
                    f.fieldType = "text";
                    f.label = "Keyword 1";
                    f.name = "key1";
                    break;
                case "Keyword 2":
                    f.fieldType = "text";
                    f.label = "Keyword 2";
                    f.name = "key2";
                    break;
                case "Country":
                    f.fieldType = "dropdown";
                    f.label = "Country";
                    f.name = "country";
                    break;
            }
            return f;
        }
        public static string getInputElement(string field)
        {
            InputSearchField f = InputSearchFields.getInputSearchField(field);
            string element;
            if(f.fieldType == "text")
            {
                element = "<input type=\"text\" class=\"form-control\" name=\""+f.name+"\" id=\"_nav_search_field_"+f.name+"\" placeholder=\""+f.label+"\">";

            } else if(f.fieldType == "dropdown")
            {
                element = "<select class=\"custom-select\"> " +
                    "<option selected value = \"0\"> Select " + f.label + "</option>";

                string[] c;
                if(f.name == "country")
                {
                    c = CasePaper.Countries;
                    
                } else if(f.name == "typeOfSuit")
                {
                    c = CasePaper.Suits;
                } else if(f.name == "status")
                {
                    c = CasePaper.Statuses;
                } else if(f.name == "courtOfLaw")
                {
                    c = CasePaper.Courts;
                } else
                {
                    c = null;
                }
                if(c != null) { 
                for (var i = 0; i < c.Length; i++)
                {
                    element += "<option value=\"" + (i + 1) + "\">" + c[i] + "</option>";
                }
                }
                element += "</select>";
       
            } else if(f.fieldType == "date")
            {
                element = "<input type=\"text\" class=\"form-control\" name=\"" + f.name + "\" id=\"_nav_search_field_" + f.name + "\" placeholder=\"" + f.label + "\">";
            } else
            {
                element = "";
            }
            return element;
        }

        public string getSqlQuery(List<SearchField> fields, FormCollection fc)
        {
            string selectClause = "SELECT ";
            string fromClause = "FROM hr.\"CasePapers\"";
            string whereClause = "WHERE ";
            List<object> parameters = new List<object>();
            for (var i = 0; i < fields.Count; i++)
            {
                InputSearchField f = InputSearchFields.getInputSearchField(fields[i].FieldName);
                if (fc[f.name] != null || fc[f.name] != "" || fc[f.name] != "0")
               
                    if (f.name == "caseNo")
                    {
                        var columnName ="CaseNo";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "plaintiff" ){
                        var columnName ="Plaintiff";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "defendant" ){
                        var columnName ="Defendant";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "dateOfFiling") {
                        var columnName = "DateOfFiling";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "courtOfLaw"){
                        var columnName = "CourtOfLaw";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(Convert.ToInt32(fc[f.name]));
                    } else if(f.name == "sequel"){
                        var columnName = "Sequel";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "judgeName") {
                        var columnName = "JudgeName";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "typeOfSuit") {
                        var columnName = "TypeOfSuit";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "relatedTo"){
                        var columnName = "RelatedTo";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "underSection"){
                        var columnName = "UnderSection";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "patentsAtIssue"){
                        var columnName = "PatentsAtIssue";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "courtInterpretation"){
                        var columnName = "CourtInterpretation";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "dateOfJudgement"){
                        var columnName = "DateOfJudgement";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "caseDecision"){
                        var columnName = "Casedecision";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    } else if(f.name == "furtherAppeals"){
                        var columnName = "FutherAppeals";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    }
                    else if(f.name == "status"){
                        var columnName = "Status";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(Convert.ToInt32(fc[f.name]));
                    }
                    else if(f.name == "country"){
                        var columnName = "Country";
                        selectClause += (parameters.Count == 0 ? "" : "," )+" \" "+columnName+"\"";
                        whereClause += "\""+columnName+"\" = {" + parameters.Count + "}";
                        parameters.Add(fc[f.name]);
                    }
                    //Key1 and key2
                }
                return "";
            }
        }
    
    public class ApplicationDbContext : IdentityDbContext<Login>
    {
        //public DbSet<Login> Logins { get; set; }
        public DbSet<Requester> Requesters { get; set; }
        public DbSet<CasePaper> CasePapers { get; set; }
        public DbSet<SearchField> SearchFields { get; set; }
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
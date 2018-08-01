using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            "Keyword 2"
        };
        [Key]
        public string Id { get; set; }
        [StringLength(255, ErrorMessage = "My Error Message")]
        public string FieldName { get; set; }
        public bool Show { get; set; }
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
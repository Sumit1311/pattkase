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

namespace MvcApplication1.Models
{
    public class Login
    {
        public int Id{ get; set; }
        [StringLength(255, MinimumLength = 3, ErrorMessage = "My Error Message")]
        public string Email { get; set; }
        [StringLength(255, MinimumLength = 3, ErrorMessage = "My Error Message")]
        public string Password{ get; set; }
        //public string Location { get; set; }
    }

    public class OracleDbContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR");
        }
        public void InitializeModel() {
            Login l = new Login
            {
                Email = "admin@localhost.com",
                Password = "admin"
            };
            Logins.AddOrUpdate(h => h.Email, l);
            this.SaveChanges();
        }
    }
}
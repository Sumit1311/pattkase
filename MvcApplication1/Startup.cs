using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcApplication1.Models;

namespace MvcApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdminUser();
        }

        public void CreateAdminUser() {
            var ctx = new ApplicationDbContext();

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(ctx));
            var userManager = new UserManager<Login>(new UserStore<Login>(ctx));

            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                roleManager.Create(new ApplicationRole("Admin"));

                //Here we create a Admin super user who will maintain the website                  

                var user = new Login();
                user.UserName = "admin";
                string userPWD = "admin123";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRoles(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Member"))
            {
                roleManager.Create(new ApplicationRole("Member"));
            }
        }
    }
}
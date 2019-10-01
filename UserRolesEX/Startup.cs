using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using UserRolesEX.Models;

[assembly: OwinStartupAttribute(typeof(UserRolesEX.Startup))]
namespace UserRolesEX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleandUsers();
        }
        
        public void CreateRoleandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //create first admin role and first default user
            if (!roleManager.RoleExists("Admin"))
            {
                //create admin role
                var role = new IdentityRole();
                    role.Name = "Admin";
                roleManager.Create(role);

                //now create Admin Super User
                var user = new ApplicationUser();
                user.UserName = "Troy";
                user.Email = "Troy.Butler@dynology.com";

                var userPWD = "Abc123!";
                var chkUser = UserManager.Create(user, userPWD);

                //set default user to admin role
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

            }
        }
    }
}

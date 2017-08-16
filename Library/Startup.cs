using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OperationsOnData.DAL;
using OperationsOnData.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.Startup))]
namespace Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            LibraryContext context = new LibraryContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    // first we create Admin rool    
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website                   

            //    var user = new User();
            //    user.UserName = "admin@gmail.com";
            //    user.Email = "admin@gmail.com";
            //    user.Name = "Admin";
            //    user.SecondName = "Admin";

            //    string userPWD = "1234Abcd@";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin    
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");
            //    }
            //}

            
        }
    }
}

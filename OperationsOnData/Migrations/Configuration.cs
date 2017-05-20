namespace OperationsOnData.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OperationsOnData.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OperationsOnData.DAL.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OperationsOnData.DAL.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedRoles(context);
            SeedUsers(context);
        }

        private void SeedRoles(OperationsOnData.DAL.LibraryContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(OperationsOnData.DAL.LibraryContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User { UserName = "Admin"};
                var adminResult = manager.Create(user, "12345678");

                if (adminResult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }            
        }
    }
}

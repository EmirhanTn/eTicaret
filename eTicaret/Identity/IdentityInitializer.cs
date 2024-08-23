using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eTicaret.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace eTicaret.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" }; ;
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "emirhantorun"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "emirhan", Surname = "torun", UserName = "emirhantorun", Email = "emirhan.torun@hotmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");

            }

            if (!context.Users.Any(i => i.Name == "elifaktas"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "elif", Surname = "aktas", UserName = "elifaktas", Email = "elif.aktas@hotmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }



            base.Seed(context);
        }
    }
}
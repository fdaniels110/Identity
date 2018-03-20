using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity
{
    public class MyDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>();
            var manager = new RoleManager<IdentityRole>(store);
            
            manager.Create(new IdentityRole() { Name = "Admin" });
            manager.Create(new IdentityRole() { Name = "User" });

            var uStore = new UserStore<ApplicationUser>(context);
            var uManager = new UserManager<ApplicationUser>(uStore);
            ApplicationUser admin = new ApplicationUser()
            {
                Email = "admin@admin.com",
                EmailConfirmed = true, 
                UserName = "admin@admin.com"
            };

            uManager.Create(admin, "TestPassword1@");
            uManager.AddToRole(admin.Id, "Admin");
            uManager.AddClaim(admin.Id, new System.Security.Claims.Claim("secret", "access"));

            base.Seed(context);

        }
    }
}
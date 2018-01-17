namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.BlogContext context)
        {
            #region CreateRoles
            context.Roles.AddOrUpdate(x=>x.Name,new IdentityRole(){Name = "Admin" });
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(){ Name = "Author" });
            #endregion

           
            if (context.Users.Count() == 0)
            { 
                #region CreateUsers
                UserStore<IdentityUser> us = new UserStore<IdentityUser>(context);
                UserManager<IdentityUser> um = new UserManager<IdentityUser>(us);

                IdentityUser user1 = new IdentityUser();
                user1.Email = "meryko@meryko.com";
                user1.UserName = "meryko@meryko.com";

                IdentityUser user2 = new IdentityUser();
                user2.Email = "author@meryko.com";
                user2.UserName = "author@meryko.com";

                IdentityUser user3 = new IdentityUser();
                user3.Email = "demo@meryko.com";
                user3.UserName = "demo@meryko.com";

                um.Create(user1, "User.72");
                um.Create(user2, "User.72");
                um.Create(user3, "User.72");
                #endregion
                #region AssignUsersToRoles
                um.AddToRole(user1.Id, "Admin");
                um.AddToRole(user2.Id, "Author");
                #endregion
            }
            
            

           

        }
    }
}

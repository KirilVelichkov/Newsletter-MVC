namespace NewsLetter.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsLetterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsLetterDBContext context)
        {
            this.RolesSeeder(context);
            this.AdminSeeder(context);
            this.CategoriesSeeder(context);
        }

        private void RolesSeeder(NewsLetterDBContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleAdmin = new IdentityRole() { Name = "Admin" };
            var roleRegular = new IdentityRole() { Name = "Regular" };


            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                roleManager.Create(roleAdmin);
            }

            if (!context.Roles.Any(role => role.Name == "Regular"))
            {
                roleManager.Create(roleRegular);
            }
        }

        private void AdminSeeder(NewsLetterDBContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    AvatarPictureUrl = "/Images/Static/admin-avatar.jpg"
                };

                userManager.Create(adminUser, "admin123");
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }

        private void CategoriesSeeder(NewsLetterDBContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var categories = new string[] { "Entertainment", "Sport", "Politics", "Health", "Technology" };

            foreach (var category in categories)
            {
                if (!context.Categories.Any(u => u.Name == category))
                {
                    context.Categories.AddOrUpdate(new Category()
                    {
                        Id = Array.FindIndex(categories, x => x == category),
                        Name = category
                    });
                }
            }

        }
    }
}

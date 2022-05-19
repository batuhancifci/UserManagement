namespace UserManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserManagement.Helper.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<UserManagement.Models.UserManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserManagement.Models.UserManagementDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new Models.User { Id = 1, Name = "UserName", Surname = "UserSurname", Email = "user@user.com", Password = "user123", BirthDate = new DateTime(1998, 10, 23), Phone = "+905542615182", Role = 1 },
                new Models.User { Id = 2, Name = "AdminName", Surname = "AdminSurname", Email = "admin@admin.com", Password = "admin123", BirthDate = new DateTime(1993, 10, 13), Phone = "+905542445132", Role = 2 });
        }
    }
}

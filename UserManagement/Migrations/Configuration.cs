namespace UserManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserManagement.Models.UserManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserManagement.Models.UserManagementDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new Models.User { Id = 1, Name = "UserName", Surname = "UserSurname", Email = "user@user.com", Password = "6ad14ba9986e3615423dfca256d04e3f", BirthDate = new DateTime(1998, 10, 23), Phone = "+905542615182", Role = Helper.Enums.Roles.User },
                new Models.User { Id = 2, Name = "AdminName", Surname = "AdminSurname", Email = "admin@admin.com", Password = "0192023a7bbd73250516f069df18b500", BirthDate = new DateTime(1993, 10, 13), Phone = "+905542445132", Role = Helper.Enums.Roles.Admin });
        }
    }
}

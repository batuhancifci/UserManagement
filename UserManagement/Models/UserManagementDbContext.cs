using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class UserManagementDbContext: DbContext
    {
        public UserManagementDbContext() : base("UserManagementDbContext")
        {
            //Disable initializer
            Database.SetInitializer<UserManagementDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Models;
using static UserManagement.Helper.Enums;

namespace UserManagement.Dtos
{
    public class UserDto
    {
        public class EditDto
        {
            public User user { get; set; }
            public Roles roles { get; set; }
            public string newPassword { get; set; }
        }
    }
}
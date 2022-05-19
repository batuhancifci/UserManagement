using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserManagement.Helper.Enums;

namespace UserManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Email Required!")]
        public string Email { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname Required!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Phone Required!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Birth Date Required!")]
        public DateTime BirthDate { get; set; }
        public int Role { get; set; }
    }
}
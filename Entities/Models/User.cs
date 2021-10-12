using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, ErrorMessage = "Username must contain maxim 30 characters")]
        [EmailAddress]
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must contain maxim 30 characters")]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

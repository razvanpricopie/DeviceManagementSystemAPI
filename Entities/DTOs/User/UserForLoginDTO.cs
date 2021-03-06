using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs.User
{
    public class UserForLoginDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must contain minimum 8 characters")]
        public string Password { get; set; }

        public string Name { get; set; }
        public ICollection<RoleDTO> Roles { get; set; }

        public DeviceDTO Device { get; set; }
    }
}

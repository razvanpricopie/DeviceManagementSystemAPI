using Entities.DTOs.Location;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, ErrorMessage = "Username must contain maxim 30 characters")]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<RoleDTO> Roles { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must contain maxim 30 characters")]
        public string Name { get; set; }

        public DeviceDTO Device { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, ErrorMessage = "Username must contain maxim 30 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must contain maxim 30 characters")]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}

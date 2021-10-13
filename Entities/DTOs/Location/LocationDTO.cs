using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Location
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public UserDTO User { get; set; }
    }
}

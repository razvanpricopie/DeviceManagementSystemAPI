using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Location
{
    public class LocationForCreationDTO
    {
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public int UserId { get; set; }
    }
}

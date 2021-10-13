using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Location
    {
        public int Id { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }

        public User user { get; set; }
    }
}

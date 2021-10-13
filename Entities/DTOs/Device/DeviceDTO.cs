using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public int Type { get; set; }
        public String OperatingSystem { get; set; }
        public String OsVersion { get; set; }
        public String Processor { get; set; }
        public String RamAmount { get; set; }
        public bool isAssigned { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystemAPI.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public String Type { get; set; }
        public String OperatingSystem { get; set; }
        public String OsVersion { get; set; }
        public String Processor { get; set; }
        public String RamAmount { get; set; }

    }
}

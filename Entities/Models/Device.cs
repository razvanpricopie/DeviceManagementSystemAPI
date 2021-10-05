using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("device")]
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

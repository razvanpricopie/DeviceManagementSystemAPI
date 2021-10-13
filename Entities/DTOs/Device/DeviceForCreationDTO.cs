using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class DeviceForCreationDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(20, ErrorMessage = "Manufacturer can't be longer than 20 characters")]
        public String Manufacturer { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(20, ErrorMessage = "Type can't be longer than 20 characters")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Operating system is required")]
        [StringLength(20, ErrorMessage = "Operating system can't be longer than 20 characters")]
        public String OperatingSystem { get; set; }

        [Required(ErrorMessage = "Operating system version is required")]
        [StringLength(20, ErrorMessage = "Operating system version can't be longer than 10 characters")]
        public String OsVersion { get; set; }

        [Required(ErrorMessage = "Processor is required")]
        [StringLength(20, ErrorMessage = "Processor can't be longer than 15 characters")]
        public String Processor { get; set; }

        [Required(ErrorMessage = "Ram Amount is required")]
        [StringLength(20, ErrorMessage = "Ram Amount can't be longer than 10 characters")]
        public String RamAmount { get; set; }
    }
}

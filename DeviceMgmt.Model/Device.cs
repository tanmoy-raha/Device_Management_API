using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IDevice
    {
        string ID { get; set; }
        string IMEI { get; set; }
        string Model { get; set; }
        int SIM_Card_Number { get; set; }
        bool Enabled { get; set; }
        DateTime Created_DateTime { get; set; }
        string CreatedBy { get; set; }
    }
    public class DeviceMgmt_Device : IDevice
    {
        [Key]        
        public string ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "IMEI cannot be longer than 20 characters.")]
        public string IMEI { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters.")]
        public string Model { get; set; }

        [Required]
        public int SIM_Card_Number { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Created_DateTime { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}

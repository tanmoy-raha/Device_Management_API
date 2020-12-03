using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IDeviceBackend
    {
        string ID { get; set; }
        string Device_ID { get; set; }
        string Backend_ID { get; set; }
        DateTime Mapped_DateTime { get; set; }
    }
    public class DeviceBackend : IDeviceBackend
    {
        [Key]
        public string ID { get; set; }


        [ForeignKey("Device_ID")]
        public Device Device { get; set; }
        public string Device_ID { get; set; }



        [ForeignKey("Backend_ID")]
        public Backend Backend { get; set; }
        public string Backend_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Mapped_DateTime { get; set; }
    }
}

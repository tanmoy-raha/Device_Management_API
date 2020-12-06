using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IDeviceBackend
    {
        Guid ID { get; set; }
        Guid Device_ID { get; set; }
        Guid Backend_ID { get; set; }
        DateTime Mapped_DateTime { get; set; }
    }
    public class DeviceMgmt_DeviceBackend : IDeviceBackend
    {
        [Key]
        public Guid ID { get; set; }


        [ForeignKey("Device_ID")]
        public DeviceMgmt_Device Device { get; set; }
        public Guid Device_ID { get; set; }



        [ForeignKey("Backend_ID")]
        public DeviceMgmt_Backend Backend { get; set; }
        public Guid Backend_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Mapped_DateTime { get; set; }
    }
}

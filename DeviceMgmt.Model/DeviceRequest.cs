using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IDeviceRequest
    {
        string ID { get; set; }
        string DeviceIMEI { get; set; }
        string Model { get; set; }
        string SIMCardNumber { get; set; }
        string Enabled { get; set; }
        string CreatedBy { get; set; }

        string Name { get; set; }
        string Address { get; set; }

    }

    public class DeviceRequest : IDeviceRequest
    {
        public string ID { get; set; }
        public string DeviceIMEI { get; set; }
        public string Model { get; set; }
        public string SIMCardNumber { get; set; }
        public string Enabled { get; set; }
        public string CreatedBy { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}

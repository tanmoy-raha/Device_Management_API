using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceMgmt.Model
{
    interface IDeviceBackendVM
    {
        string DeviceIMEI { get; set; }
        string Model { get; set; }
        int SIMCardNumber { get; set; }
        bool IsEnabled { get; set; }
        DateTime CreatedDateTime { get; set; }
        string CreatedBy { get; set; }

    }
    public class DeviceBackendVM : IDeviceBackendVM
    {
        public string DeviceIMEI { get; set; }
        public string Model { get; set; }
        public int SIMCardNumber { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
    }
}

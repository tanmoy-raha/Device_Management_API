using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IDeviceBackendVM
    {
        Guid ID { get; set; }
        string DeviceIMEI { get; set; }
        string Model { get; set; }
        decimal SIMCardNumber { get; set; }
        bool IsEnabled { get; set; }
        string CreatedDateTime { get; set; }
        string CreatedBy { get; set; }

        string Name { get; set; }
        string Address { get; set; }
        Guid BackEndID { get; set; }

    }
    public class DeviceBackendVM : IDeviceBackendVM
    {
        public Guid ID { get; set; }
        public string DeviceIMEI { get; set; }
        public string Model { get; set; }
        public decimal SIMCardNumber { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid BackEndID { get; set; }

    }
}

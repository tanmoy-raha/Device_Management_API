using DeviceMgmt.Model;
using DeviceMgmt.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceMgmt.Service
{
    public interface IDeviceBackendService
    {
        IEnumerable<DeviceBackendVM> DoGetAllDevices();
    }
}

using DeviceMgmt.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DeviceMgmt.Core
{
    public interface IDeviceCore
    {
        IEnumerable<DeviceBackendVM> DoFetchAllDevice(ref string str_catchmessage);

    }
}

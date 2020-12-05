using DeviceMgmt.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DeviceMgmt.Core
{
    public interface IDeviceCore
    {
        DataTable DoFetchAllDevice(ref string str_catchmessage);
        DataTable DoSaveDevice(ref string str_catchmessage, IDeviceRequest deviceRequest);
        DataTable DoFetchDevice(ref string str_catchmessage, string strID);
    }
}

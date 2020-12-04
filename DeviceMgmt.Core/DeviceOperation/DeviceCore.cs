using DeviceMgmt.Core.Utility;
using DeviceMgmt.DataLayer;
using DeviceMgmt.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DeviceMgmt.Core
{
    public class DeviceCore : IDeviceCore
    {
        public IEnumerable<DeviceBackendVM> DoFetchAllDevice(ref string str_catchmessage)
        {
            DataTable objDt = new DataTable();
            dynamic obj = null;
            try
            {

                using (var db = new ApplicationDBContext())
                {
                     obj = (from device in db.DeviceMgmt_Devices
                             select new DeviceBackendVM
                             {
                                 DeviceIMEI = device.IMEI,
                                 Model = device.Model,
                                 //SIMCardNumber = device.SIM_Card_Number,
                                 IsEnabled = device.Enabled,
                                 CreatedBy = device.CreatedBy,
                                 CreatedDateTime = device.Created_DateTime
                             }
                             ).ToList();
                }

            }
            catch (SqlException exp)
            {
                str_catchmessage = "[DeviceCore.cs]" + exp.Message;
            }
            catch (Exception expErr)
            {
                str_catchmessage = "[DeviceCore.cs]" + expErr.Message;
            }

            return obj;
        }

        

        
    }
}

using DeviceMgmt.Core;
using DeviceMgmt.Model;
using DeviceMgmt.Service.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DeviceMgmt.Service
{
    public class DeviceBackendService : IDeviceBackendService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(DeviceBackendService));      
        private readonly IDeviceCore _IDeviceCore;

        private string str_catchexception = string.Empty;
        /// <summary>
        /// DeviceBackendService is a constructor.Implement dependency injection with DataLayer
        /// </summary>      
        /// <param name="objIInvoice">DeviceCore is a class which contains all the Data logic for Device Backend operations</param>    
        /// 
        public DeviceBackendService(IDeviceCore objDeviceCore)
        {
            _log.Debug("In constructor");
            _IDeviceCore = objDeviceCore;
        }
        public IEnumerable<DeviceBackendVM> DoGetAllDevices()
        {
            _log.Debug("DoGetAllDevices process start");
            JSONResponse objJSONResponse = new JSONResponse();
            IEnumerable<DeviceBackendVM> lstObj = null;
            try
            {
                lstObj = _IDeviceCore.DoFetchAllDevice(ref str_catchexception);

                if(lstObj != null)
                {
                    objJSONResponse.status = true;
                    objJSONResponse.jsondata = JsonConvert.SerializeObject(lstObj);
                    
                }
                else
                {
                    objJSONResponse.status = false;
                }

                if (str_catchexception.Trim() != string.Empty)
                {
                    _log.Error($"DoGetAllDevices  done with exception -  {str_catchexception}");
                }

            }
            catch(Exception ex)
            {
                _log.Error($"DoGetAllDevices  has an exception - { ex.Message}");
            }
            finally
            {
                _log.Debug("DoGetAllDevices process end");
            }
            
           
            return lstObj;
        }
    }
}

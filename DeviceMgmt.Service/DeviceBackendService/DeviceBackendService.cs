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
        public JSONResponse DoGetAllDevices()
        {
            _log.Debug("DoGetAllDevices process start");
            JSONResponse objJSONResponse = new JSONResponse();
            IEnumerable<DeviceBackendVM> lstObj = null;
            try
            {
                DataTable dt = _IDeviceCore.DoFetchAllDevice(ref str_catchexception);

                if(dt != null && dt.Rows.Count > 0)
                {
                    objJSONResponse.status = true;
                    objJSONResponse.jsondata = JsonConvert.SerializeObject(dt);
                    
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
            
           
            return objJSONResponse;
        }

        public JSONResponse DoGetDevice(string strID)
        {
            _log.Debug("DoGetAllDevices process start");
            JSONResponse objJSONResponse = new JSONResponse();
            IEnumerable<DeviceBackendVM> lstObj = null;
            try
            {
                DataTable dt = _IDeviceCore.DoFetchDevice(ref str_catchexception, strID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    objJSONResponse.status = true;
                    objJSONResponse.jsondata = JsonConvert.SerializeObject(dt);

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
            catch (Exception ex)
            {
                _log.Error($"DoGetAllDevices  has an exception - { ex.Message}");
            }
            finally
            {
                _log.Debug("DoGetAllDevices process end");
            }


            return objJSONResponse;
        }

        public JSONResponse DoSaveDeviceDetails(IDeviceRequest deviceRequest)
        {
            _log.Debug("DoGetAllDevices process start");
            JSONResponse objJSONResponse = new JSONResponse();
            IEnumerable<DeviceBackendVM> lstObj = null;
            try
            {
                DataTable dt = _IDeviceCore.DoSaveDevice(ref str_catchexception, deviceRequest);

                if (dt != null && dt.Rows.Count > 0)
                {
                    objJSONResponse.status = true;
                    objJSONResponse.jsondata = JsonConvert.SerializeObject(dt);

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
            catch (Exception ex)
            {
                _log.Error($"DoGetAllDevices  has an exception - { ex.Message}");
            }
            finally
            {
                _log.Debug("DoGetAllDevices process end");
            }


            return objJSONResponse;
        }

        public JSONResponse DoDeleteDeviceDetails(IDeviceRequest deviceRequest)
        {
            _log.Debug("DoGetAllDevices process start");
            JSONResponse objJSONResponse = new JSONResponse();
            IEnumerable<DeviceBackendVM> lstObj = null;
            try
            {
                DataTable dt = _IDeviceCore.DoDeleteDeviceDetails(ref str_catchexception, deviceRequest);

                if (dt != null && dt.Rows.Count > 0)
                {
                    objJSONResponse.status = true;
                    objJSONResponse.jsondata = JsonConvert.SerializeObject(dt);

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
            catch (Exception ex)
            {
                _log.Error($"DoGetAllDevices  has an exception - { ex.Message}");
            }
            finally
            {
                _log.Debug("DoGetAllDevices process end");
            }


            return objJSONResponse;
        }
    }
}

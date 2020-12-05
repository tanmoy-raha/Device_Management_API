using DeviceMgmt.API.ValidateFilter;
using DeviceMgmt.Model;
using DeviceMgmt.Service;
using DeviceMgmt.Service.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeviceMgmt.API.Controllers.DeviceManagement
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class DeviceManageController : ControllerBase
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(DeviceManageController));       
        private readonly IDeviceBackendService _IDeviceBackendService;

        /// <summary>
        /// Constructor For Device Manage Controller. Implement dependency injection
        /// </summary>        
        /// <param name="objIDeviceBackendService">DeviceBackendService is a service class which contains all the business logic for Device Management</param>        
        public DeviceManageController(IDeviceBackendService objIDeviceBackendService)
        {
            _log.Debug("In constructor");
            _IDeviceBackendService = objIDeviceBackendService;
        }

        [HttpGet]       
        public object GetAllDeviceDetails()
        {
            _log.Debug("GetAllDeviceDetails process start");
            JSONResponse objJSONResponse = new JSONResponse();

            try
            {
                objJSONResponse = _IDeviceBackendService.DoGetAllDevices();
            }
            catch (Exception ex)
            {

                _log.Error($"GetAllDeviceDetails  has an exception - { ex.Message}");
            }

            _log.Debug("GetAllDeviceDetails process end");
            return objJSONResponse.jsondata;
        }


        [HttpPost]
        [ValidateFilter]
        public object GetDeviceDetails([FromBody] DeviceRequest obj)
        {
            _log.Debug("GetAllDeviceDetails process start");
            JSONResponse objJSONResponse = new JSONResponse();

            try
            {
                objJSONResponse = _IDeviceBackendService.DoGetDevice(obj.ID);
            }
            catch (Exception ex)
            {

                _log.Error($"GetAllDeviceDetails  has an exception - { ex.Message}");
            }

            _log.Debug("GetAllDeviceDetails process end");
            return objJSONResponse.jsondata;
        }

        [HttpPost]
        [ValidateFilter]
        public object SaveDeviceDetails([FromBody]DeviceRequest obj)
        {
            _log.Debug("SaveDeviceDetails process start");
            JSONResponse objJSONResponse = new JSONResponse();

            try
            {
                objJSONResponse = _IDeviceBackendService.DoSaveDeviceDetails(obj);
            }
            catch (Exception ex)
            {

                _log.Error($"SaveDeviceDetails  has an exception - { ex.Message}");
            }

            _log.Debug("SaveDeviceDetails process end");
            return objJSONResponse.jsondata;
        }
    }
}

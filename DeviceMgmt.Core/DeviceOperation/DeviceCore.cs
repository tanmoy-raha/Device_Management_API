using DeviceMgmt.Core.Utility;
using DeviceMgmt.DataLayer;
using DeviceMgmt.Model;
using Microsoft.EntityFrameworkCore;
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
        public DataTable DoFetchAllDevice(ref string str_catchmessage)
        {
            DataTable objDt = new DataTable();
            
            try
            {

                using (var db = new ApplicationDBContext())
                {
                    objDt = (from device in db.DeviceMgmt_Devices
                             select new DeviceBackendVM
                             {
                                 ID = device.ID,
                                 DeviceIMEI = device.IMEI,
                                 Model = device.Model,
                                 SIMCardNumber = device.SIM_Card_Number,
                                 IsEnabled = device.Enabled,
                                 CreatedBy = device.CreatedBy,
                                 CreatedDateTime = device.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss")
                             }
                             ).ToList().ToDataTable();
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

            return objDt;
        }

        public DataTable DoFetchDevice(ref string str_catchmessage, string strID)
        {
            DataTable objDt = new DataTable();
            
            try
            {

                using (var db = new ApplicationDBContext())
                {
                    objDt = (from device in db.DeviceMgmt_Devices
                             join dvBckEnd in db.DeviceMgmt_DeviceBackends on device.ID equals dvBckEnd.Device_ID into dvBckEndInfo
                             from dvBckEndLst in dvBckEndInfo.DefaultIfEmpty()
                             join bckEnd in db.DeviceMgmt_Backends on dvBckEndLst.Backend_ID equals bckEnd.ID into bckEndInfo
                             from bckEndLst in bckEndInfo.DefaultIfEmpty()
                             select new DeviceBackendVM
                             {
                                 ID =device.ID,
                                 DeviceIMEI = device.IMEI,
                                 Model = device.Model,
                                 SIMCardNumber = device.SIM_Card_Number,
                                 IsEnabled = device.Enabled,
                                 CreatedBy = device.CreatedBy,
                                 CreatedDateTime = device.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss"),
                                 Name = bckEndLst.Name,
                                 Address = bckEndLst.Address
                             }
                             )
                             .Where(x => x.ID == Guid.Parse(strID))                       
                             .ToList()
                             .ToDataTable();
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

            return objDt;
        }

        public DataTable DoSaveDevice(ref string str_catchmessage, IDeviceRequest deviceRequest)
        {
            DataTable objDt = new DataTable();
            
            try
            {

                using (var db = new ApplicationDBContext())
                {

                    if(deviceRequest != null)
                    {
                        DataTable dt = new DataTable();

                        if (!String.IsNullOrEmpty(deviceRequest.ID))
                        {
                            dt = (from device1 in db.DeviceMgmt_Devices
                                  join dvBckEnd in db.DeviceMgmt_DeviceBackends on device1.ID equals dvBckEnd.Device_ID into dvBckEndInfo
                                  from dvBckEndLst in dvBckEndInfo.DefaultIfEmpty()
                                  join bckEnd in db.DeviceMgmt_Backends on dvBckEndLst.Backend_ID equals bckEnd.ID into bckEndInfo
                                  from bckEndLst in bckEndInfo.DefaultIfEmpty()
                                  select new DeviceBackendVM
                                  {
                                      ID = device1.ID,
                                      DeviceIMEI = device1.IMEI,
                                      Model = device1.Model,
                                      SIMCardNumber = device1.SIM_Card_Number,
                                      IsEnabled = device1.Enabled,
                                      CreatedBy = device1.CreatedBy,
                                      CreatedDateTime = device1.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss"),
                                      Name = bckEndLst.Name,
                                      Address = bckEndLst.Address,
                                      BackEndID = bckEndLst.ID
                                  }
                             )
                             .Where(x => x.ID == Guid.Parse(deviceRequest.ID))
                             .ToList()
                             .ToDataTable();
                        }
                            


                        DeviceMgmt_Device device = new DeviceMgmt_Device();
                        DeviceMgmt_Backend backend = new DeviceMgmt_Backend();
                        DeviceMgmt_DeviceBackend deviceBackend = new DeviceMgmt_DeviceBackend();

                        device.CreatedBy = "T";
                        device.Created_DateTime = DateTime.Now;
                        device.IMEI = deviceRequest.DeviceIMEI;
                        device.Model = deviceRequest.Model;
                        device.SIM_Card_Number = Convert.ToDecimal( deviceRequest.SIMCardNumber);
                        device.Enabled = (deviceRequest.Enabled == "Enabled") ? true : false;
                        device.ID = (!String.IsNullOrEmpty(deviceRequest.ID)) ? Guid.Parse(deviceRequest.ID) : Guid.NewGuid();

                        backend.Name = deviceRequest.Name;
                        backend.Address = deviceRequest.Address;
                        backend.ID =(dt.Rows.Count > 0 && !String.IsNullOrEmpty(dt.Rows[0]["BackEndID"].ToString())) ? Guid.Parse(dt.Rows[0]["BackEndID"].ToString()) : Guid.NewGuid();

                        if (!String.IsNullOrEmpty(deviceRequest.ID))
                        {
                            db.Entry(device).State = EntityState.Modified;
                            db.SaveChanges();


                            db.Entry(backend).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.DeviceMgmt_Devices.Add(device);
                            db.SaveChanges();

                            db.DeviceMgmt_Backends.Add(backend);
                            db.SaveChanges();

                            deviceBackend.ID = Guid.NewGuid();
                            deviceBackend.Device_ID = device.ID;
                            deviceBackend.Backend_ID = backend.ID;
                            deviceBackend.Mapped_DateTime = DateTime.Now;

                            db.DeviceMgmt_DeviceBackends.Add(deviceBackend);
                            db.SaveChanges();

                        }                            
                       
                    }



                    objDt = (from device in db.DeviceMgmt_Devices
                             select new DeviceBackendVM
                             {
                                 ID = device.ID,
                                 DeviceIMEI = device.IMEI,
                                 Model = device.Model,
                                 SIMCardNumber = device.SIM_Card_Number,
                                 IsEnabled = device.Enabled,
                                 CreatedBy = device.CreatedBy,
                                 CreatedDateTime = device.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss")
                             }
                             ).ToList().ToDataTable();
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

            return objDt;
        }

        public DataTable DoDeleteDeviceDetails(ref string str_catchmessage, IDeviceRequest deviceRequest)
        {
            DataTable objDt = new DataTable();
            
            try
            {

                using (var db = new ApplicationDBContext())
                {

                    if (deviceRequest != null)
                    {
                        DataTable dt = new DataTable();

                        dt = (from device1 in db.DeviceMgmt_Devices
                              join dvBckEnd in db.DeviceMgmt_DeviceBackends on device1.ID equals dvBckEnd.Device_ID into dvBckEndInfo
                              from dvBckEndLst in dvBckEndInfo.DefaultIfEmpty()
                              join bckEnd in db.DeviceMgmt_Backends on dvBckEndLst.Backend_ID equals bckEnd.ID into bckEndInfo
                              from bckEndLst in bckEndInfo.DefaultIfEmpty()
                              select new DeviceBackendVM
                              {
                                  ID = device1.ID,
                                  DeviceIMEI = device1.IMEI,
                                  Model = device1.Model,
                                  SIMCardNumber = device1.SIM_Card_Number,
                                  IsEnabled = device1.Enabled,
                                  CreatedBy = device1.CreatedBy,
                                  CreatedDateTime = device1.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss"),
                                  Name = bckEndLst.Name,
                                  Address = bckEndLst.Address,
                                  BackEndID = bckEndLst.ID
                              }
                             )
                             .Where(x => x.ID == Guid.Parse(deviceRequest.ID))
                             .ToList()
                             .ToDataTable();


                 
                        if (!String.IsNullOrEmpty(deviceRequest.ID) && dt.Rows.Count > 0)
                        {
                            Guid deviceID = Guid.Parse(deviceRequest.ID);
                            Guid backendID = Guid.Parse(dt.Rows[0]["BackEndID"].ToString());

                            DeviceMgmt_DeviceBackend deviceBackend = db.DeviceMgmt_DeviceBackends.Where(x => x.Device_ID == deviceID
                                                                                                        && x.Backend_ID == backendID).FirstOrDefault();
                            db.DeviceMgmt_DeviceBackends.Remove(deviceBackend);
                            db.SaveChanges();

                            DeviceMgmt_Backend backend = db.DeviceMgmt_Backends.Find(backendID);
                            db.DeviceMgmt_Backends.Remove(backend);
                            db.SaveChanges();



                            DeviceMgmt_Device device = db.DeviceMgmt_Devices.Find(deviceID);
                            db.DeviceMgmt_Devices.Remove(device);
                            db.SaveChanges();

                            

                           
                            


                        }

                    }



                    objDt = (from device in db.DeviceMgmt_Devices
                             select new DeviceBackendVM
                             {
                                 ID = device.ID,
                                 DeviceIMEI = device.IMEI,
                                 Model = device.Model,
                                 SIMCardNumber = device.SIM_Card_Number,
                                 IsEnabled = device.Enabled,
                                 CreatedBy = device.CreatedBy,
                                 CreatedDateTime = device.Created_DateTime.ToString("dd/MMM/yyyy hh:mm:ss")
                             }).ToList().ToDataTable();
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

            return objDt;
        }
    }
}

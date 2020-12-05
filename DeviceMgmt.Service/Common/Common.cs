using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceMgmt.Service.Common
{
    /// <summary>
    /// JSONRequest class
    /// Contains JSONRequest Model Object
    /// </summary>
    public class JSONRequest
    {
        public object jsondata;
        public string sessionidentity;
        public int PracticeID;
    }
    /// <summary>
    /// JSONRequestGeneric class
    /// Contains JSONRequestGeneric Model Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JSONRequestGeneric<T>
    {
        public T jsondata;
        
        
    }
    /// <summary>
    /// JSONResponse class
    /// Contains JSONResponse Model Object
    /// </summary>
    public class JSONResponse
    {
        public bool status;
        public string sessionidentity;
        public string value;
        public object jsondata;
        public int rowcount;
        public string responseMsg;
        public JSONValidation validatonMsg = new JSONValidation();
        public string errorMsg;
        public string refreshtoken;
        public string accesstoken;
        

    }
    /// <summary>
    /// JSONValidation class
    /// Contains JSONValidation Model Object
    /// </summary>
    public class JSONValidation
    {
        public List<string> alertMessages = new List<string>();
        public string validatonType;//success,info,warning,error
    }
}

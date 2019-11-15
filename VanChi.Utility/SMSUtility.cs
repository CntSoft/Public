using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace VanChi.Utility
{
    public sealed class SMSUtility
    {
        string phone_from = "84919286129";
        string apiUrl = "";
        string authenticateToken = "";
        public SMSUtility(string AuthenticateToken, string SmsBrandName)
        {
            phone_from = SmsBrandName;
            apiUrl = "http://api-01.worldsms.vn/webapi";
            authenticateToken = AuthenticateToken; // ex: "bGFjdmlldDoyMGQyNWU4YQ==";
        }
        public ResultSms Send(string phone_to, string sms_message)
        {
            //only support message length max = 612 char.
            if (sms_message.Length > 612) sms_message = sms_message.Substring(0, 612);
            string result = "";
            string package =
                @"
                  ""from"": ""{0}"",
                  ""to"": ""{1}"",
                  ""text"": ""{2}"",
                  ""unicode"": ""0""
                 ";
            package = "{" + string.Format(package, phone_from, phone_to, sms_message) + "}";
            WebRequest request = WebRequest.Create(apiUrl + "/sendSMS");
            request.Headers.Add("Authorization", "Basic " + authenticateToken);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            //post to server
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(package);
                streamWriter.Flush();
                streamWriter.Close();
            }

            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            ResultSms ret = JsonConvert.DeserializeObject<ResultSms>(result);

            return ret;// result.Contains("{\"status\":1}");
        }
    }
    public class ResultSms
    {
        public int status;
        public int errorcode;
        public string description;
    }
}

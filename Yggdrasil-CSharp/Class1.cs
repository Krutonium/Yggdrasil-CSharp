using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Yggdrasil_CSharp
{
    public class Yggdrasil
    {
        static readonly string APIBase = "https://authserver.mojang.com/";
        private static readonly string AuthServer = APIBase + "/authenticate";
        public string Login(string Username, string Password)
        {
            Payload payload = new Payload();
            payload.username = Username;
            payload.password = Password;

            return (SendRequest(new Uri(AuthServer), JsonConvert.SerializeObject(payload)));
        }
        
        private string SendRequest(Uri uri, string JSONData)
        {
            var JsonDataBytes = Encoding.UTF8.GetBytes(JSONData);
            try
            {
                var Client = new WebClient();
                Client.Headers.Add("Content-Type", "application/json");
                byte[] Response = Client.UploadData(uri, "POST", JsonDataBytes);
                var ReturnedData = Encoding.UTF8.GetString(Response);
                return ReturnedData;
            }
            catch (WebException ex)
            {
                return null;
            }
        }
        public class Agent {
            public string name { get; set; } = "Minecraft";
            public int version { get; set; } = 1;
        }

        public class Payload
        {
            public Agent agent { get; set; }
            public string username { get; set; } 
            public string password { get; set; }
            public string clientToken { get; set; } = "Yggdrasil-CSharp";
            public bool requestUser { get; set; } = true;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class User:BaseNotify
    {
        private string userName;

        [JsonProperty("Username")]
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        private string password;
        [JsonProperty("Password")]
        public string Password
        {
            get { return password; }
            set {SetProperty(ref password ,value); }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp
{
    public static class Main
    {
        private static string _server = "http://192.168.1.15/";


        public static AuthenticationToken Token { get; set; }
        public static string Server
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
            }
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp
{
    public class Helper
    {
        public static string Token
        {
            get
            {
                var data = SecureStorage.GetAsync("token").Result;
                return data;
            }
            set
            {
                SecureStorage.SetAsync("token", value);
            }
        }


        public static Dosen Dosen
        {
            get {
                var dataString = SecureStorage.GetAsync("dosen").Result;
                if (string.IsNullOrEmpty(dataString))
                    return null;
                var data = JsonConvert.DeserializeObject<Dosen>(dataString);
                return data;
            }
            set {
                var data = JsonConvert.SerializeObject(value);
                SecureStorage.SetAsync("dosen", data); }
        }


        public static async Task<App> GetMainPageAsync()
        {
            var x = await Task.FromResult(Application.Current);
            return x as App;
        }

        public static string GetDayName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "Senin";
                case DayOfWeek.Tuesday:
                    return "Selasa";

                case DayOfWeek.Wednesday:
                    return "Rabu";
                case DayOfWeek.Thursday:
                    return "Kamis";
                case DayOfWeek.Friday:
                    return "Jumat";
              
                case DayOfWeek.Saturday:
                    return "Sabtu";
                case DayOfWeek.Sunday:
                    return "Minggu";
              
              
                default:
                    return "Minggu";
            }
        }

        internal static string ResponseErrorHandler(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var main =  Helper.GetMainPageAsync().Result;
                    main.ChangeScreen(new AuthView());
                }
                return response.StatusCode.ToString();
            }
            catch 
            {
                return "On Error";
            }
        }

        public static Clock CurrentClock { get; set; }
        public static string Url { get; set; } = "https://restsimak.stimiksepnop.ac.id/";
    }
}

using System;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;

namespace MobileApp
{
    public class Helper
    {
        public static string Token { get; internal set; }
        public static Dosen Dosen { get; internal set; }


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
    }
}

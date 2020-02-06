
using Android.App;
using Android.Content;
using MobileApp.Droid.Renderes;
using MobileApp.Models;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using Util = Android.Icu.Util;

[assembly: Xamarin.Forms.Dependency(typeof(MyAlaramService))]
namespace MobileApp.Droid.Renderes
{
    public class MyAlaramService : IAlarmService
    {
        System.Globalization.CultureInfo cultureinfo =
           new System.Globalization.CultureInfo("id-ID");
        public void SetAlarm(List<Jadwal> jadwal)
        {
            var currentContext = Android.App.Application.Context;
            AlarmManager alarmManager = currentContext.GetSystemService(Context.AlarmService) as AlarmManager;
            foreach (var item in jadwal)
            {
                var Now = DateTime.Now;
                TimeSpan interval = Now.AddDays(7)-Now;
                var start = GetStart(item.Hari, item.Selesai.ToShortTimeString());
                var alarmIntent = new Intent(currentContext, typeof(AlarmReciever));
                alarmIntent.PutExtra("waktu", $"Jam {item.Mulai.ToShortTimeString()}");
                alarmIntent.PutExtra("matakuliah", $"{item.NamaMataKuliah}");
                alarmIntent.PutExtra("jadwalId", $"{item.JadwalId}");

                var pending = PendingIntent.GetBroadcast(currentContext, item.JadwalId, alarmIntent, PendingIntentFlags.UpdateCurrent);
                var currentime=DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                alarmManager.SetRepeating(AlarmType.RtcWakeup, currentime+ (long)start.TotalMilliseconds, (long)interval.TotalMilliseconds, pending);
            }
        }

        private int GetDayOfWeek(string hari)
        {
            switch (hari.ToLower())
            {
                case "senin":
                    return (int)DayOfWeek.Monday;
                case "selasa":
                    return (int)DayOfWeek.Tuesday;
                case "rabu":
                    return (int)DayOfWeek.Wednesday;
                case "kamis":
                    return (int)DayOfWeek.Thursday;
                case "jumat":
                    return (int)DayOfWeek.Friday;
                case "sabtu":
                    return (int)DayOfWeek.Saturday;
                default:
                   return (int)DayOfWeek.Sunday;
            }
        }

        private TimeSpan GetStart(string hari , string jam)
        {
            System.Globalization.CultureInfo cultureinfo =
             new System.Globalization.CultureInfo("id-ID");

            DateTime tanggalKuliah = new DateTime();
            DateTime.TryParse(jam, out tanggalKuliah);
            DateTime now = DateTime.Now;

            DateTime realDate = new DateTime();

            int start = 0;
            if (tanggalKuliah <= now)
            {
                start = 1;
            }

            for (int i = start; i <= 7; i++)
            {
                realDate = tanggalKuliah.AddDays(i);
                if (cultureinfo.DateTimeFormat.GetDayName(realDate.DayOfWeek) == hari)
                    break;
            }
            TimeSpan startTime = realDate - now;
            return startTime;
        }
    }
}
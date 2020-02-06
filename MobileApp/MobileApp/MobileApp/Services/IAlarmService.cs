using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Services
{
   public interface IAlarmService
    {
        void SetAlarm(List<Jadwal> jadwal);
    }
}

using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
   public interface IJadwalService<T>
    {
        Task<List<T>> Get();
        Task<List<T>> GetJadwalToday();
    }
}

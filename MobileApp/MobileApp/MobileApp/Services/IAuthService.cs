using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IAuthService
    {
        Task Login(string userName, string password);
        Task<Dosen> GetProfile(int id);
        Task<bool> Logout();
    }
}

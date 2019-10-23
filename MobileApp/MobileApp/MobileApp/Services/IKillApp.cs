using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IKillApp
    {
         Task CloseAppAsync();
    }
}

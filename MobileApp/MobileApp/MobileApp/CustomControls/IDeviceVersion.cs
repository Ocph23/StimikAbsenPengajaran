using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.CustomControls
{
    public interface IDeviceVersion
    {
        string GetVersion();
        int GetBuild();
    }
}

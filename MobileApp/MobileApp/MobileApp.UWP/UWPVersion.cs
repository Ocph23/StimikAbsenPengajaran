using MobileApp.CustomControls;
using MobileApp.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;


[assembly: Xamarin.Forms.Dependency(typeof(UWPVersion))]
namespace MobileApp.UWP
{
    public class UWPVersion : IDeviceVersion
    {
        public int GetBuild()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return Convert.ToInt32(version.Build);
        }

        public string GetVersion()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return string.Format("{0}.{1}.{2}", version.Major, version.Minor,version.Revision);

        }
    }
}

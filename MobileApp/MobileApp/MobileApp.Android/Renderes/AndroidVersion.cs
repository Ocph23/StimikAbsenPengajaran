using Android.Content.PM;
using MobileApp.CustomControls;
using MobileApp.Droid.Renderes;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidVersion))]
namespace MobileApp.Droid.Renderes
{
    public class AndroidVersion:IDeviceVersion
    {

        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionName;
        }

        public int GetBuild()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionCode;
        }
    }
}
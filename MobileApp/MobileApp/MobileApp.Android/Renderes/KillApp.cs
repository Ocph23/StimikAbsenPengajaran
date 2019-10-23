using Android.App;
using MobileApp.Droid.Renderes;
using MobileApp.Services;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(KillApp))]
namespace MobileApp.Droid.Renderes
{
    public class KillApp : IKillApp
    {
        public async Task CloseAppAsync()
        {
            await Task.Delay(500);
            (Xamarin.Forms.Forms.Context as Activity).Finish();
        }
    }
}
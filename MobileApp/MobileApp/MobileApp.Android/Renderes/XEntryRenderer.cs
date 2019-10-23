using Android.Graphics.Drawables;
using MobileApp.CustomControls;
using MobileApp.Droid.Renderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace MobileApp.Droid.Renderes
{
    [System.Obsolete]
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}
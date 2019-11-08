using MobileApp.CustomControls;
using MobileApp.UWP;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace MobileApp.UWP
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.UWP.FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            var radius = ((CustomFrame)this.Element).CornerRadius;
            Control.CornerRadius = new Windows.UI.Xaml.CornerRadius(radius.TopLeft, radius.TopRight, radius.BottomRight, radius.BottomLeft);
        }
    }
}

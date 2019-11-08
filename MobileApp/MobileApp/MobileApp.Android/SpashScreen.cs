using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Airbnb.Lottie;
using Microsoft.AppCenter.Push;
using MobileApp.Droid;

namespace MobileApp.Droid
{
    [Activity(Theme = "@style/Theme.Splash", Label ="BA Mengajar",
      MainLauncher = true,
      NoHistory = true)]
    public class SpashScreen : Activity, Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Spash_Screen);
            LottieAnimationView animationView =(LottieAnimationView)FindViewById(Resource.Id.animation_sreen);
            animationView.AddAnimatorListener(this);
        }
        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);
        
        }
        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            var intent = new Intent(this, typeof(MainActivity));
            if (Intent.Extras != null)
                intent.PutExtras(Intent.Extras); // copy push info from splash to main
            Push.CheckLaunchedFromNotification(this, intent);
            StartActivity(intent);

        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
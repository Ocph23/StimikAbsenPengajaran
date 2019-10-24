using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Airbnb.Lottie;
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

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
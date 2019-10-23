using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Services;
using MobileApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });
            DependencyService.Register<AuthService>();
            DependencyService.Register<JadwalService>();
            DependencyService.Register<BeritaAcaraService>();
            ChangeScreen(new AuthView());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=ac38d1a7-ffc0-477e-b1cb-ac50b9bede6c;" +
                   "uwp={cb9aee59-a2e1-4d07-beaa-57877e1e9cd9};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("android=ac38d1a7-ffc0-477e-b1cb-ac50b9bede6c;" +
                              "uwp={Your UWP App secret here};" +
                              "ios={Your iOS App secret here}",
                              typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }



        public void ChangeScreen(Page page)
        {
            Current.MainPage = new NavigationPage(page);
        }
    }
}

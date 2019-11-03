using Lottie.Forms;
using MobileApp.CustomControls;
using MobileApp.Models;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
   public class AuthViewModel:BaseViewModel
    {
        public User Model { get; set; } = new User();

        public AuthViewModel(Lottie.Forms.AnimationView animationView)
        {
            animation = animationView;
            LoginCommand = new Command(LoginAction);
            var version = DependencyService.Get<IDeviceVersion>();
            AppBuild = version.GetBuild();
            AppVersion = version.GetVersion();

        }

        private AnimationView animation;

        public Command LoginCommand { get; }

        private int appbuild;

        public int AppBuild
        {
            get { return appbuild; }
            set { SetProperty(ref appbuild ,value); }
        }

        private string appVersion;

        public string AppVersion
        {
            get { return appVersion; }
            set { SetProperty(ref appVersion ,value); }
        }



        private async void LoginAction(object obj)
        {
            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    await this.UserStore.Login(Model.UserName, Model.Password);
                    var main = await Helper.GetMainPageAsync();
                    await Task.Delay(1000);
                    main.ChangeScreen(new ItemsPage());
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

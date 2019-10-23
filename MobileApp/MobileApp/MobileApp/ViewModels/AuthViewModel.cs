using Lottie.Forms;
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
        }

        private AnimationView animation;

        public Command LoginCommand { get; }

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

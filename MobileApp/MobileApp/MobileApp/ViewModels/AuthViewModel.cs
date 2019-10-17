using MobileApp.Models;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
   public class AuthViewModel:BaseViewModel
    {
        public User Model { get; set; } = new User();

        public AuthViewModel()
        {
            LoginCommand = new Command(LoginAction);
        }

        public Command LoginCommand { get; }

        private async void LoginAction(object obj)
        {
            try
            {
                await this.UserStore.Login(Model.UserName, Model.Password);
                var main = await Helper.GetMainPageAsync();
                main.ChangeScreen(new ItemsPage());
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
        }
    }
}

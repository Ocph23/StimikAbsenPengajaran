﻿using System;
using Xamarin.Forms;
using MobileApp.Services;
using MobileApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Globalization;
using Microsoft.AppCenter.Push;
using Xamarin.Essentials;
using Newtonsoft.Json;
using MobileApp.Models;

namespace MobileApp
{
    public partial class App : Application
    {

        public App()    
        {
            InitializeComponent();

            CultureInfo requestCulture;
            try
            {
                // Request top UserLanguage from user agent and create CultureInfo object.
                requestCulture = CultureInfo.CreateSpecificCulture("id-ID");
            }
            catch
            {
                // Return server Culture if none available in HttpHeaders.
                requestCulture = CultureInfo.CurrentCulture;
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = requestCulture;

            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });
            DependencyService.Register<AuthService>();
            DependencyService.Register<JadwalService>();
            DependencyService.Register<BeritaAcaraService>();

            if(string.IsNullOrEmpty(SecureStorage.GetAsync("token").Result))
                 ChangeScreen(new AuthView());
            else
            {
                ChangeScreen(new ItemsPage());
            }
        } 

        protected override void OnStart()
        {
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {

                    try
                    {
                        MessagingCenter.Send(new MessagingCenterAlert
                        {
                            Title = e.Title,
                            Message = e.Message,
                            Cancel = "OK"
                        }, "message");
                        // Add the notification message and title to t
                        if (e.CustomData != null)
                        {
                            var summary = "\n\tCustom data:\n";
                            foreach (var key in e.CustomData.Keys)
                            {
                                summary += $"\t\t{key} : {e.CustomData[key]}\n";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Crashes.TrackError(ex);
                    }
                   
                };
            }
            AppCenter.Start("ac38d1a7-ffc0-477e-b1cb-ac50b9bede6c", typeof(Push));
            AppCenter.Start("android=ac38d1a7-ffc0-477e-b1cb-ac50b9bede6c;" +
                   "uwp={cb9aee59-a2e1-4d07-beaa-57877e1e9cd9};" +
                   "ios={aa239d3c-28bc-49f5-a922-1a1eec1aca74}",
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

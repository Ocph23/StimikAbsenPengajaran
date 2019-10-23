using System.ComponentModel;
using Xamarin.Forms;
using MobileApp.ViewModels;
using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as Jadwal;
            var main = await Helper.GetMainPageAsync();
           await main.MainPage.Navigation.PushAsync(new HistoryView(item));
        }

        [System.Obsolete]
        protected override bool OnBackButtonPressed()
        {
            if(Device.OS == TargetPlatform.Android)
            {
                DependencyService.Get<IKillApp>().CloseAppAsync();
            }
          
            return base.OnBackButtonPressed();
        }
    }
}

using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthView : ContentPage
	{
		public AuthView ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModels.AuthViewModel(animationView);
            Task.Factory.StartNew(()=>  LoadAsync());
		}

        private async Task LoadAsync()
        {
            await Task.Delay(500);
            await logo.TranslateTo(0, 0, 1000, Easing.BounceOut);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = Color.Transparent;
        }
    }
}
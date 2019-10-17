using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.BindingContext = new ViewModels.AuthViewModel();
		}
	}
}
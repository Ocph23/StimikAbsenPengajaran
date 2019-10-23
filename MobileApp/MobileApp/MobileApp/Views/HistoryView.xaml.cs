using MobileApp.Models;
using MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryView : ContentPage
    {
        public HistoryView(Jadwal item)
        {
            InitializeComponent();
            this.BindingContext = new HistoryViewModel(item);
        }
    }
}
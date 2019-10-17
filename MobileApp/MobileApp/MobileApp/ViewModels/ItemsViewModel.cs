using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobileApp.Models;
using MobileApp.Views;
using System.Linq;

namespace MobileApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Jadwal> Items { get; set; }
        public Dosen Dosen {get;set;}
        public DateTime Today { get; set; } = DateTime.Now;
        public Command LoadItemsCommand { get; set; }
        private int jumlah;

        public int Jumlah
        {
            get { return jumlah; }
            set { SetProperty(ref jumlah ,value); }
        }


        public ItemsViewModel()
        {
            Items = new ObservableCollection<Jadwal>();
            Dosen = Helper.Dosen;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

       
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await JadwalStore.Get();

                string hari = Helper.GetDayName(Today.DayOfWeek);
                if(items!=null)
                {
                    Jumlah = items.Count;
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
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
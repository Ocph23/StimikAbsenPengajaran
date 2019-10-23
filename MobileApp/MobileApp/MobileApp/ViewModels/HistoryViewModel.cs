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
    public class HistoryViewModel : BaseViewModel
    {
        public Jadwal Jadwal { get; }
        public ObservableCollection<BeritaAcara> Items { get; set; }
        public Dosen Dosen {get;set;}
        public DateTime Today { get; set; } = DateTime.Now;
        public Command LoadItemsCommand { get; set; }
        private int jumlah;

        public int Jumlah
        {
            get { return jumlah; }
            set { SetProperty(ref jumlah ,value); }
        }


        public HistoryViewModel(Jadwal jadwal)
        {
            Jadwal = jadwal;
            Items = new ObservableCollection<BeritaAcara>();
            Dosen = Helper.Dosen;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

       
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await BeritaAcaraStore.Get(Jadwal.JadwalId);

                string hari = Helper.GetDayName(Today.DayOfWeek);
                if(items!=null)
                {
                    Jumlah = items.Count;
                    foreach (var item in items.Where(x=>x.JadwalId==Jadwal.JadwalId))
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
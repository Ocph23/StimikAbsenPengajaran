using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileApp.Models;
using MobileApp.Views;
using System.Linq;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Jadwal> Items { get; set; }
        public Dosen Dosen {get;set;}
        public DateTime Today { get; set; } = DateTime.Now;
        public Command LoadItemsCommand { get; set; }
        private int jumlah;

        private Clock clock;

        public Clock Clock
        {
            get { return clock; }
            set {SetProperty(ref clock ,value); }
        }


        public int Jumlah
        {
            get { return jumlah; }
            set { SetProperty(ref jumlah ,value); }
        }


        public ItemsViewModel()
        {
            Items = new ObservableCollection<Jadwal>();
            Dosen = Helper.Dosen;
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
         //   LoadItemsCommand.Execute(null);
        }


        async void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await Task.Delay(500);
                Items.Clear();

                var now = await JadwalStore.GetDateTimeNow();
                if (now == null)
                    Today = DateTime.Now;
                else
                    Today = now.DateTime;

                if (Helper.CurrentClock == null)
                    Helper.CurrentClock =  new Clock(Today);

                Clock = Helper.CurrentClock;
                var items = await JadwalStore.Get();
                string hariini = Helper.GetDayName(Today.DayOfWeek);
                string harikemarin = Helper.GetDayName(Today.AddDays(-1).DayOfWeek);
                if (items!=null)
                {
                    foreach (var item in items.Where(x=>x.Hari.ToLower()==hariini.ToLower() || x.Hari.ToLower() == harikemarin.ToLower()))
                    {
                        var data = await BeritaAcaraStore.GetById(item.JadwalId, Today);
                        if (data != null)
                            item.Added = true;
                        //item.Selesai = DateTime.Now;
                        Items.Add(item);
                    }
                }

                var closer = DependencyService.Get<IAlarmService>();
                closer?.SetAlarm(items);
                Jumlah = Items.Count;

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
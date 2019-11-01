using System;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class AbsenViewModel:BaseViewModel
    {
        private BeritaAcara _model;

        public Jadwal Data { get; set; }
        public Dosen Dosen { get; set; }
     
        public DateTime Today { get; set; } = DateTime.Now;
        public INavigation Nav { get; }

        private Command saveCommand;

        public Command SaveCommand
        {
            get { return saveCommand; }
            set { SetProperty(ref saveCommand ,value); }
        }



        public BeritaAcara Model {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        } 

        public AbsenViewModel(Jadwal data, INavigation navigation)
        {
            Nav = navigation;
            Model = new BeritaAcara();
            this.Data = data;
            this.Dosen = Helper.Dosen;
            SaveCommand = new Command(SaveAction, x => true);
        }
        public AbsenViewModel(Jadwal data, BeritaAcara model, INavigation navigation)
        {
            Nav = navigation;
            this.Model = model;
            this.Data = data;
            this.Dosen = Helper.Dosen;
            SaveCommand = new Command(SaveAction, x=>true);
        }

        private async void SaveAction(object obj)
        {
           if(!IsBusy)
            {
                SaveCommand = new Command(SaveAction, x => false);
                IsBusy = true;
                if (Model.BeritaAcaraId == null)
                {
                    Model.Tanggal = Helper.CurrentClock.Current;
                    Model.JadwalId = Data.JadwalId;
                    Model.NIDN = Dosen.NIDN;
                    Model.MataKuliahId = Data.MatakuliahId;
                }

                try
                {
                    var result = await this.BeritaAcaraStore.Save(Model);
                    if (result != null && Model.BeritaAcaraId == null)
                    {
                        Model.BeritaAcaraId = result.BeritaAcaraId;
                    }
                    await Task.Delay(1000);
                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Info",
                        Message = "Data Tersimpan",
                        Cancel = "OK"
                    }, "message");
                }
                catch (Exception ex)
                {
                    SaveCommand = new Command(SaveAction, x => true);
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
                    await Nav.PopAsync();
                }
            }
        }
    }
}

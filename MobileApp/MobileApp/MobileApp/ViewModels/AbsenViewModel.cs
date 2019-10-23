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
        public Command SaveCommand { get; }
        public DateTime Today { get; set; } = DateTime.Now;

        public BeritaAcara Model {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        } 

        public AbsenViewModel(Jadwal data)
        {
            Model = new BeritaAcara();
            this.Data = data;
            this.Dosen = Helper.Dosen;
            SaveCommand = new Command(SaveAction);
        }
        public AbsenViewModel(Jadwal data, BeritaAcara model)
        {
            this.Model = model;
            this.Data = data;
            this.Dosen = Helper.Dosen;
            SaveCommand = new Command(SaveAction);
        }

        private async void SaveAction(object obj)
        {
           if(!IsBusy)
            {
                IsBusy = true;
                if (Model.BeritaAcaraId == null)
                {
                    Model.Tanggal = DateTime.Now;
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
}

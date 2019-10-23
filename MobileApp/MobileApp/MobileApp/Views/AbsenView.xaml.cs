using MobileApp.Models;
using MobileApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbsenView : ContentPage
    {
        private AbsenViewModel vm;

        public AbsenView(Models.Jadwal data)
        {
            InitializeComponent();
            this.BindingContext=vm= new AbsenViewModel(data);
            jumlah.onChangeValue += Jumlah_onChangeValue;
            hadir.onChangeValue += Hadir_onChangeValue; 
            alpa.onChangeValue += Alpa_onChangeValue;
            sakit.onChangeValue += Sakit_onChangeValue;
            izin.onChangeValue += Izin_onChangeValue;

          /*  var task=  vm.BeritaAcaraStore.GetById(data.JadwalId, DateTime.Now);
            task.ContinueWith(completeTaskAsync);*/
         
        }

        /* private async Task completeTaskAsync(Task<BeritaAcara> arg1)
         {
             var ba = await arg1;
             if(ba!=null)
             {
                 vm.Model = ba;
                 jumlah.Nilai = ba.Jumlah;
                 hadir.Nilai = ba.Hadir;
                 alpa.Nilai = ba.Alpa;
                 izin.Nilai = ba.Izin;
                 sakit.Nilai = ba.Sakit;
             }
         }*/
        public AbsenView(Models.Jadwal data, BeritaAcara ba)
        {
            InitializeComponent();
            this.BindingContext = vm = new AbsenViewModel(data,ba);
            jumlah.onChangeValue += Jumlah_onChangeValue;
            hadir.onChangeValue += Hadir_onChangeValue;
            alpa.onChangeValue += Alpa_onChangeValue;
            sakit.onChangeValue += Sakit_onChangeValue;
            izin.onChangeValue += Izin_onChangeValue;
            jumlah.Nilai = ba.Jumlah;
            hadir.Nilai = ba.Hadir;
            alpa.Nilai = ba.Alpa;
            izin.Nilai = ba.Izin;
            sakit.Nilai = ba.Sakit;
            /*  var task=  vm.BeritaAcaraStore.GetById(data.JadwalId, DateTime.Now);
              task.ContinueWith(completeTaskAsync);*/

        }
        private void Izin_onChangeValue(bool isAdd,int value)
        {
           
            if (!ValidateInput())
            {
                if (isAdd)
                    izin.Nilai--;
                else
                    izin.Nilai++;
            }
            else
            {
                vm.Model.Izin = value;
            }
        }

        private bool ValidateInput()
        {
           if(jumlah.Nilai-(alpa.Nilai+sakit.Nilai+izin.Nilai)>=0)
            {
                hadir.Nilai = jumlah.Nilai - (alpa.Nilai + sakit.Nilai + izin.Nilai);
                vm.Model.Hadir = hadir.Nilai;
                return true;
            }
            return false;
        }

        private void Sakit_onChangeValue(bool isAdd, int value)
        {
            if (!ValidateInput())
            {
                if (isAdd)
                    sakit.Nilai--;
                else
                    sakit.Nilai++;
            }
            else
            {
                vm.Model.Sakit = value;
            }
        }

        private void Alpa_onChangeValue(bool isAdd, int value)
        {
            if (!ValidateInput())
            {
                if (isAdd)
                    alpa.Nilai--;
                else
                    alpa.Nilai++;
            }
            else
            {
                vm.Model.Alpa= value;
            }
        }

        private void Hadir_onChangeValue(bool isAdd, int value)
        {
            vm.Model.Hadir = value;
          
        }

        private void Jumlah_onChangeValue(bool isAdd, int value)
        {
            if (!ValidateInput())
            {
                if (isAdd)
                    jumlah.Nilai--;
                else
                    jumlah.Nilai++;
            }
            else
            {
                vm.Model.Jumlah = value;
            }
        }

        private void save_click(object sender, EventArgs e)
        {
            vm.SaveCommand.Execute(null);
        }
    }
}
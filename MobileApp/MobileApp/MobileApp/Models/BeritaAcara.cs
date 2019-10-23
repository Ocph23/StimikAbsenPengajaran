using MobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Models
{
    public class BeritaAcara:BaseNotify
    {

        private int? beritaAcaraId;
        [JsonProperty("idbamengajardosen")]
        public int? BeritaAcaraId
        {
            get { return beritaAcaraId; }
            set { SetProperty(ref beritaAcaraId, value); }
        }

        private DateTime? tanggal;

        [JsonProperty("tanggal")]
        public DateTime? Tanggal
        {
            get { return tanggal; }
            set { SetProperty(ref tanggal, value); }
        }

        private string dosenId;

        [JsonProperty("nidn")]
        public string NIDN
        {
            get { return dosenId; }
            set { SetProperty(ref dosenId, value); }
        }

        private string mataKuliahId;

        [JsonProperty("kmk")]
        public string MataKuliahId
        {
            get { return mataKuliahId; }
            set { SetProperty(ref mataKuliahId, value); }
        }

        private int jadwalId;
        [JsonProperty("idjadwal")]
        public int JadwalId
        {
            get { return jadwalId; }
            set { SetProperty(ref jadwalId, value); }
        }

        [JsonProperty("jumlah")]
        public int Jumlah
        {
            get { return jumlah; }
            set { SetProperty(ref jumlah, value); }
        }


        private int hadir;

        [JsonProperty("hadir")]
        public int Hadir
        {
            get { return hadir; }
            set { SetProperty(ref hadir ,value); }
        }

        private int alpa;

        [JsonProperty("alpha")]
        public int Alpa
        {
            get { return alpa; }
            set { SetProperty(ref alpa, value); }
        }

        private int sakit;

        [JsonProperty("sakit")]
        public int Sakit
        {
            get { return sakit; }
            set { SetProperty(ref sakit, value); }
        }


        private int izin;

        [JsonProperty("izin")]
        public int Izin
        {
            get { return izin; }
            set { SetProperty(ref izin, value); }
        }

        private string materi;

        [JsonProperty("materi")]
        public string Materi
        {
            get { return materi; }
            set { SetProperty(ref materi, value); }
        }
        private string persetujuan1;

        [JsonProperty("persetujuan1")]
        public string Persetujuan1
        {
            get { return persetujuan1; }
            set { SetProperty(ref persetujuan1, value); }
        }

        private string persetujuan2;
        private int jumlah;

        [JsonProperty("persetujuan2")]
        public string Persetujauan2
        {
            get { return persetujuan2; }
            set { SetProperty(ref persetujuan2, value); }
        }


        [JsonIgnore]
        public string Prosentase
        {
            get {
                double data = Convert.ToDouble(Hadir)/Convert.ToDouble(Jumlah)* 100;
                return $"{data:N2}%"; }
        }

        [JsonIgnore]
        public Command SelectedCommand { get; }

        public BeritaAcara()
        {
            SelectedCommand = new Command(async (x) => await OnSelected(x));
        }

        private async Task OnSelected(object obj)
        {
            var data = obj as BeritaAcara;
            if (data != null)
            {
                var main = await Helper.GetMainPageAsync();
                var page = new AbsenView(new Jadwal { JadwalId = this.JadwalId },data);
                await main.MainPage.Navigation.PushAsync(page);
            }
        }


    }
}

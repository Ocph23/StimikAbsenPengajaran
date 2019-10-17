using MobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Models
{
   public class Jadwal
    {

        private int jadwalId;

        [JsonProperty("idjadwal")]
        public int JadwalId
        {
            get { return jadwalId; }
            set { jadwalId = value; }
        }

        private string  matakuliahId;

        [JsonProperty("kmk")]
        public string MatakuliahId
        {
            get { return matakuliahId; }
            set { matakuliahId = value; }
        }


        private string nmmk;
        [JsonProperty("nmmk")]
        public string NamaMataKuliah
        {
            get { return nmmk; }
            set { nmmk = value; }
        }

        private string kelas;
        [JsonProperty("kelas")]
        public string Kelas
        {
            get { return kelas; }
            set { kelas = value; }
        }



        private string hari;
        [JsonProperty("hari")]
        public string Hari
        {
            get { return hari; }
            set { hari = value; }
        }

        private DateTime mulai;

        [JsonProperty("wm")]
        public DateTime Mulai
        {
            get { return mulai; }
            set { mulai = value; }
        }

        private DateTime selesai;
        [JsonProperty("ws")]
        public DateTime Selesai
        {
            get { return selesai; }
            set { selesai = value; }
        }

        private string ruang;
        [JsonProperty("ruangan")]
        public string Ruang
        {
            get { return ruang; }
            set { ruang = value; }
        }

        private string thakademik;
        [JsonProperty("thakademik")]
        public string TahunAkademik
        {
            get { return thakademik; }
            set { thakademik = value; }
        }

        public string KelasRuang
        {
            get { return $"Kelas : {Kelas}  - Ruang : {Ruang}"; }
        }

        public Command SelectedCommand { get; }

        public Jadwal()
        {
            SelectedCommand = new Command(async (x) => await OnSelected(x));
        }

        private async Task OnSelected(object obj)
        {
            var data = obj as Jadwal;
            if (data != null)
            {
                var main = await Helper.GetMainPageAsync();
                main.ChangeScreen(new AbsenView(data));
            }
        }
    }
}

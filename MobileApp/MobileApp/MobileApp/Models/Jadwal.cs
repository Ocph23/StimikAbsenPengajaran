﻿using MobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Models
{
   public class Jadwal:BaseNotify
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
        private string dosenId;

        [JsonProperty("nidn")]
        public string NIDN
        {
            get { return dosenId; }
            set { SetProperty(ref dosenId, value); }
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


        private int jumlahmahasiswa;
        [JsonProperty("jumlahmahasiswa")]
        public int JumlahMahasiswa
        {
            get { return jumlahmahasiswa; }
            set { jumlahmahasiswa = value; }
        }

        public string KelasRuang
        {
            get { return $"Kelas : {Kelas}  - Ruang : {Ruang}"; }
        }

        public string Jam
        {
            get {
                TimeSpan selisih = Selesai.Subtract(Mulai);
                return $"{selisih.Hours} Jam"; }
        }

        public string Menit
        {
            get
            {
                TimeSpan selisih = Selesai.Subtract(Mulai);
                return $"{selisih.Minutes} Menit";
            }
        }

        private Command selectedCommand;

        public Command SelectedCommand
        {
            get { return selectedCommand; }
            set {SetProperty(ref  selectedCommand ,value); }
        }



        private bool added;

        public bool Added
        {
            get { return added; }
            set {
                SetProperty(ref added ,value);
                SelectedCommand = new Command(async (x) => await OnSelected(x), CanSelect); }
        }


        public Clock MyClock { get; set; }

        public Jadwal()
        {
           
            MyClock = Helper.CurrentClock;
            MyClock.OnTick += MyClock_OnTick;
        }

        private void MyClock_OnTick()
        {
            SelectedCommand = new Command(async (x) => await OnSelected(x), CanSelect);
        }

        private bool CanSelect(object arg)
        {
            if (Added)
                return false;
            return true;
            
            //var newDate = MyClock.Current;
            //var currentTimeStart = newDate.TimeOfDay;
            //var selisihx =Selesai.TimeOfDay.Subtract(currentTimeStart);
            //var nextDay = Selesai.AddDays(1);
            //var endDay = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day);
            //if (selisihx.TotalMinutes <=15 && newDate < endDay)
            //    return true;
            //else
            //    return false;
        }

        private async Task OnSelected(object obj)
        {
            var data = obj as Jadwal;
            if (data != null)
            {
                var main = await Helper.GetMainPageAsync();
                await main.MainPage.Navigation.PushAsync(new AbsenView(data));
            }
        }
    }
}

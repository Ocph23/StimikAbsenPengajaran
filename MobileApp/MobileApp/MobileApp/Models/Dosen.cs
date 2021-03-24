using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Models
{
    public class Dosen:BaseNotify
    {
        private int dosenId;

        public int DosenId
        {
            get { return dosenId; }
            set { dosenId = value; }
        }

        private string name;
        [JsonProperty("Nama")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string nidn;
        [JsonProperty("nidn")]
        public string NIDN
        {
            get { return nidn; }
            set { nidn = value; }
        }



        private string photo;
        [JsonProperty("photo")]
        public string Photo
        {
            get { return photo; }
            set { photo = value;}
        }


        public string PhotoView
        {
            get {
                if (string.IsNullOrEmpty(Photo))
                    return null;
                return $"{Helper.Url}assets/file/photo/{photo}"; }
        }

        private List<Jadwal> dataJadwal;

        public List<Jadwal> DataJadwal
        {
            get { return dataJadwal; }
            set { dataJadwal = value; }
        }


    }
}

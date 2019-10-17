using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Dosen
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


        private List<Jadwal> dataJadwal;

        public List<Jadwal> DataJadwal
        {
            get { return dataJadwal; }
            set { dataJadwal = value; }
        }


    }
}

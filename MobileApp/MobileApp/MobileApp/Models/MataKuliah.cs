using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
   public class MataKuliah
    {

        private int mataKuliahId;

        [JsonProperty("MatakuliahId")]
        public int MataKuliahId
        {
            get { return mataKuliahId; }
            set { mataKuliahId = value; }
        }

        private string namaMataKuliah;

        public string NamaMatakuliah
        {
            get { return namaMataKuliah; }
            set { namaMataKuliah = value; }
        }

    }
}

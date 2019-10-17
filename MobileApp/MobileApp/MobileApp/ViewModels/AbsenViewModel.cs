using System;
using System.Collections.Generic;
using System.Text;
using MobileApp.Models;

namespace MobileApp.ViewModels
{
    public class AbsenViewModel
    {
        public Jadwal Data { get; set; }
        public Dosen Dosen { get; set; }
        public DateTime Today { get; set; } = DateTime.Now;
        public AbsenViewModel(Jadwal data)
        {
            this.Data = data;
            this.Dosen = Helper.Dosen;
        }
    }
}

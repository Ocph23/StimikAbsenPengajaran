using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class BeritaAcara
    {

        private int beritaAcaraId;

        public int BeritaAcaraId
        {
            get { return beritaAcaraId; }
            set { beritaAcaraId = value; }
        }

        private DateTime tanggal;

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        private int dosenId;

        public int DosenId
        {
            get { return dosenId; }
            set { dosenId = value; }
        }

        private int mataKuliahId;

        public int MataKuliahId
        {
            get { return mataKuliahId; }
            set { mataKuliahId = value; }
        }

        private int jadwalId;

        public int JadwalId
        {
            get { return jadwalId; }
            set { jadwalId = value; }
        }

        private int hadir;

        public int Hadir
        {
            get { return hadir; }
            set { hadir = value; }
        }

        private int alpa;

        public int Alpa
        {
            get { return alpa; }
            set { alpa = value; }
        }

        private int sakit;

        public int Sakit
        {
            get { return sakit; }
            set { sakit = value; }
        }


        private int izin;

        public int Izin
        {
            get { return izin; }
            set { izin = value; }
        }

        private string materi;

        public string Materi
        {
            get { return materi; }
            set { materi = value; }
        }
        private string persetujuan1;

        public string Persetujuan1
        {
            get { return persetujuan1; }
            set { persetujuan1 = value; }
        }

        private string persetujuan2;

        public string Persetujauan2
        {
            get { return persetujuan2; }
            set { persetujuan2 = value; }
        }


    }
}

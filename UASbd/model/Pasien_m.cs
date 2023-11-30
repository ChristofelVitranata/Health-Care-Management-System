using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UASbd.model
{
    internal class Pasien_m
    {
        string nama, umur, penyakit, golongandarah;

        public Pasien_m() { }

        public Pasien_m(string nama, string umur, string penyakit, string golongandarah)
        {
            this.Nama = nama;
            this.Umur = umur;
            this.Penyakit = penyakit;
            this.Golongandarah = golongandarah;
        }

        public string Nama { get => nama; set => nama = value; }
        public string Umur { get => umur; set => umur = value; }
        public string Penyakit { get => penyakit; set => penyakit = value; }
        public string Golongandarah { get => golongandarah; set => golongandarah = value; }
    }
}

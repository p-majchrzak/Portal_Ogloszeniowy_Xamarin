using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Zapisane
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public int Ogloszenie { get; set; }
        public int Pracownik { get; set; }
        public Zapisane() { }
        public Zapisane(int ogloszenie, int pracownik)
        {
            Ogloszenie = ogloszenie;
            Pracownik = pracownik;
        }
    }
}

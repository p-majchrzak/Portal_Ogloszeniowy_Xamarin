using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Firma
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Zdjecie { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public bool Aktywne { get; set; }

        public Firma() { }
        public Firma(string nazwa, string zdjecie, string adres, string email, string haslo)
        {
            Nazwa = nazwa;
            Zdjecie = zdjecie;
            Adres = adres;
            Email = email;
            Haslo = haslo;
        }
        public Firma(string nazwa, string zdjecie, string adres, string email, string haslo, bool aktywne)
        {
            Nazwa = nazwa;
            Zdjecie = zdjecie;
            Adres = adres;
            Email = email;
            Haslo = haslo;
            Aktywne = aktywne;
        }
    }
}

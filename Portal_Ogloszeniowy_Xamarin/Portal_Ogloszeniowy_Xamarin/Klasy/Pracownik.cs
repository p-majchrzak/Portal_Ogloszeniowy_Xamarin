using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Pracownik
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Naziwsko { get; set; }
        public string Zdjecie { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Email { get; set; }
        public int Numer { get; set; }
        public string AdresZamieszkania { get; set; }
        public string NazwaStanowiska { get; set; }
        public string OpisStanowiska { get; set; }
        public string DoswiadczenieZawodowe { get; set; }
        public string Wyksztalcenie { get; set; }
        public string ZnajomoscJezykow { get; set; }
        public string DodatkoweUmiejetnosci { get; set; }
        public string Linki { get; set; }
        public string Opis { get; set; }
        public string Haslo { get; set; }

        public bool AktywneKonto { get; set; }

        public Pracownik() { }
        public Pracownik(string imie, string naziwsko, DateTime? dataUrodzenia, string email, int numer, string zdjecie, string adresZamieszkania,
        string nazwaStanowiska, string opisStanowiska, string doswiadczenieZawodowe, string wyksztalcenie, string znajomoscJezykow,
        string dodatkoweUmiejetnosci, string linki, string opis, string haslo, bool aktywneKonto)
        {
            Imie = imie;
            Naziwsko = naziwsko;
            DataUrodzenia = dataUrodzenia;
            Email = email;
            Numer = numer;
            AdresZamieszkania = adresZamieszkania;
            NazwaStanowiska = nazwaStanowiska;
            OpisStanowiska = opisStanowiska;
            DoswiadczenieZawodowe = doswiadczenieZawodowe;
            Wyksztalcenie = wyksztalcenie;
            ZnajomoscJezykow = znajomoscJezykow;
            DodatkoweUmiejetnosci = dodatkoweUmiejetnosci;
            Linki = linki;
            Opis = opis;
            Haslo = haslo;
            Zdjecie = zdjecie;
            AktywneKonto = aktywneKonto;
        }
    }
}

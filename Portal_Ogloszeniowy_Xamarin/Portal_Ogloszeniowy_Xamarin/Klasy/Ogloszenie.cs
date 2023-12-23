using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Ogloszenie
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public int Firma_ID { get; set; }
        public string NazwaStanowiska { get; set; }
        public string PoziomStanowiska { get; set; }
        public string RodzajUmowy { get; set; }
        public string WymiarZatrudnienia { get; set; }
        public string RodzajPracy { get; set; }
        public string WidelkiWynagrodzenia { get; set; }
        public string DniPracy { get; set; }
        public string GodzinyPracy { get; set; }
        public DateTime? DataWaznosci { get; set; }
        public int Kategoria_ID { get; set; }
        public string ZakresObowiazkow { get; set; }
        public string Benefity { get; set; }

        public Ogloszenie() { }
        public Ogloszenie(Firma nazwaFirmy, string nazwaStanowiska, string poziomStanowiska, string rodzajUmowy, string wymiarZatrudnienia,
        string rodzajPracy, string widelkiWynagrodzenia, string dniPracy, string godzinyPracy, DateTime? dataWaznosci,
        Kategorie kategoria, string zakresObowiazkow, string benefity)
        {
            Firma_ID = nazwaFirmy.ID;
            NazwaStanowiska = nazwaStanowiska;
            PoziomStanowiska = poziomStanowiska;
            RodzajUmowy = rodzajUmowy;
            WymiarZatrudnienia = wymiarZatrudnienia;
            RodzajPracy = rodzajPracy;
            WidelkiWynagrodzenia = widelkiWynagrodzenia;
            DniPracy = dniPracy;
            GodzinyPracy = godzinyPracy;
            DataWaznosci = dataWaznosci;
            Kategoria_ID = kategoria.ID;
            ZakresObowiazkow = zakresObowiazkow;
            Benefity = benefity;
        }
    }
}

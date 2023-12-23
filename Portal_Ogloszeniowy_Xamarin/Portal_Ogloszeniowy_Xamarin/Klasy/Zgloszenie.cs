using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Zgloszenie
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public int Ogloszenie_ID { get; set; }
        public int Pracownik_ID { get; set; }
        public Zgloszenie() { }
        public Zgloszenie(Ogloszenie ogloszenie, PracownikKlasa pracownik)
        {
            Ogloszenie_ID = ogloszenie.ID;
            Pracownik_ID = pracownik.ID;
        }
    }
}

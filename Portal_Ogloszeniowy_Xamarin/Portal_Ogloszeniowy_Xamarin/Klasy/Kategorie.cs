using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Kategorie
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Kategoria { get; set; }
        public Kategorie() { }
        public Kategorie(string kategoria)
        {
            Kategoria = kategoria;
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Administrator
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }

        public Administrator() { }
        public Administrator(string email, string haslo)
        {
            Email = email;
            Haslo = haslo;
        }
    }
}

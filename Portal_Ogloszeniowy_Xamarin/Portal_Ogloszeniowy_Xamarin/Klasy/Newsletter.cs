using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class Newsletter
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Email { get; set; }
        public Newsletter() { }
        public Newsletter(string email)
        {
            Email = email;
        }
    }
}

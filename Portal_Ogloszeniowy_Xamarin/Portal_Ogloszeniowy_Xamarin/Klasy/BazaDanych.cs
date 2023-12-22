using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Portal_Ogloszeniowy_Xamarin.Klasy
{
    public class BazaDanych
    {
        private readonly SQLiteConnection bazaDanych;
        public BazaDanych(string sciezka)
        {
            bazaDanych = new SQLiteConnection(sciezka);
            bazaDanych.CreateTable<Administrator>();
            bazaDanych.CreateTable<Firma>();
            bazaDanych.CreateTable<Kategorie>();
            bazaDanych.CreateTable<Ogloszenie>();
            bazaDanych.CreateTable<Pracownik>();
            bazaDanych.CreateTable<Zgloszenie>();
            bazaDanych.CreateTable<Newsletter>();
        }
        public int Zapisz<T>(T objekt)
        {
            return bazaDanych.Insert(objekt);
        }
        public int Usun<T>(T objekt)
        {
            return bazaDanych.Delete(objekt);
        }
        public int Edytuj<T>(T objekt)
        {
            return bazaDanych.Update(objekt);
        }
        public List<T> Wypisz<T>() where T : new()
        {
            return bazaDanych.Table<T>().ToList();
        }
    }
}

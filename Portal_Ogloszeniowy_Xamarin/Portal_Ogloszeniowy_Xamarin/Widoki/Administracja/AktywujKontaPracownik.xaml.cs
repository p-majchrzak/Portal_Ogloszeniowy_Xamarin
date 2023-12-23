using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Administracja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AktywujKontaPracownik : ContentPage
    {
        public AktywujKontaPracownik()
        {
            InitializeComponent();
            lista.ItemsSource = OdswiezListe();
        }
        public static List<PracownikKlasa> OdswiezListe()
        {
            List<PracownikKlasa> listaPracownikow = new List<PracownikKlasa>();
            List<PracownikKlasa> listaZBazy = App.BazaDanych.Wypisz<PracownikKlasa>();
            foreach (PracownikKlasa pracownik in listaZBazy)
            {
                if (pracownik.AktywneKonto == false)
                {
                    listaPracownikow.Add(pracownik);
                }
            }
            return listaPracownikow;
        }

        private void Akceptuj_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                PracownikKlasa pracownik = lista.SelectedItem as PracownikKlasa;
                pracownik.AktywneKonto = true;
                App.BazaDanych.Edytuj(pracownik);
                DisplayAlert("Informacja", "Aktywowano konto.", "Ok");
                lista.ItemsSource = OdswiezListe();
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać element z listy.", "Ok");
            }
        }

        private void Odrzuć_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                PracownikKlasa pracownik = lista.SelectedItem as PracownikKlasa;
                App.BazaDanych.Usun(pracownik);
                DisplayAlert("Informacja", "Usunięto konto.", "Ok");
                lista.ItemsSource = OdswiezListe();
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać element z listy.", "Ok");
            }
        }
    }
}
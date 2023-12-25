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
    public partial class ZarzadzajKategoriami : ContentPage
    {
        public ZarzadzajKategoriami()
        {
            InitializeComponent();
            OdsiwezKategorie();
        }
        public void OdsiwezKategorie()
        {
            List<Kategorie> listaKategorii = App.BazaDanych.Wypisz<Kategorie>();
            List<string> nazwyKategorii = new List<string>();
            foreach (Kategorie kategorie in listaKategorii)
            {
                nazwyKategorii.Add(kategorie.Kategoria);
            }
            lista.ItemsSource = nazwyKategorii;
            lista.SelectedIndex = 1;
        }
        private async void Usuń_Clicked(object sender, EventArgs e)
        {
            int indeksKategorii = lista.SelectedIndex;
            List<Kategorie> listaKategorii = App.BazaDanych.Wypisz<Kategorie>();
            if (listaKategorii.Count > 2)
            {
                Kategorie kategoria = listaKategorii[indeksKategorii];
                var wynik = await DisplayAlert("Informacja", "Czy aby napewno chcesz usunąć " + kategoria.Kategoria + "?\nUsunięcie kategorii spowoduje usunięcie połączonch z nią\nogłoszeń, oraz zgłoszeń.", "Tak", "Nie");
                if (wynik)
                {
                    List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
                    List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
                    foreach (Ogloszenie ogloszenie in listaOgloszen)
                    {
                        if (ogloszenie.Kategoria_ID == indeksKategorii)
                        {
                            foreach (Zgloszenie zgloszenie in listaZgloszen)
                            {
                                if (zgloszenie.Ogloszenie_ID == ogloszenie.ID)
                                {
                                    App.BazaDanych.Usun(zgloszenie);
                                }
                            }
                            App.BazaDanych.Usun(ogloszenie);
                        }
                    }
                    App.BazaDanych.Usun(kategoria);
                    OdsiwezKategorie();
                    _ = DisplayAlert("Informacja", "Usunięto " + kategoria.Kategoria + ".", "Ok");
                }
            }
            else
            {
                _ = DisplayAlert("Muszą być minimum 2 kategorie, nie jesteś w stanie \nusunąć żadnej z kategorii w tym momencie.", "", "Ok");
            }
        }
    }
}
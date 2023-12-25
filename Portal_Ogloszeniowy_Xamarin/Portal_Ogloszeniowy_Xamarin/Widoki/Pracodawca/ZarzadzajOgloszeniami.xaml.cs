using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZarzadzajOgloszeniami : ContentPage
    {
        public ZarzadzajOgloszeniami()
        {
            InitializeComponent();
            Odswiez();
        }

        public void Odswiez()
        {
            List<Ogloszenie> ogloszenia = new List<Ogloszenie>();
            List<Ogloszenie> dostepneOgloszenia = App.BazaDanych.Wypisz<Ogloszenie>();
            for (int i = 0; i < dostepneOgloszenia.Count; i++)
            {
                if (dostepneOgloszenia[i].Firma_ID == App.GlobalnaFirma.ID)
                {
                    ogloszenia.Add(dostepneOgloszenia[i]);
                }
            }
            listaMoichOgloszen.ItemsSource = ogloszenia;
        }
        private async void Usun_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = listaMoichOgloszen.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                bool wynik = await DisplayAlert("Informacja", "Czy aby napewno chcesz usunąć ofertę pracy " + ogloszenie.NazwaStanowiska + "?", "Tak", "Nie");
                if (wynik)
                {
                    List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
                    foreach (Zgloszenie zgloszenie in listaZgloszen)
                    {
                        if (zgloszenie.Ogloszenie_ID == ogloszenie.ID)
                        {
                            App.BazaDanych.Usun(zgloszenie);
                        }
                    }
                    List<Zapisane> listaZapisanych = App.BazaDanych.Wypisz<Zapisane>();
                    foreach (Zapisane zapisane in listaZapisanych)
                    {
                        if (zapisane.Ogloszenie == ogloszenie.ID)
                        {
                            App.BazaDanych.Usun(zapisane);
                        }
                    }
                    App.BazaDanych.Usun(ogloszenie);
                    _ = DisplayAlert("Informacja", "Usunięto " + ogloszenie.NazwaStanowiska + ".", "Ok");
                    Odswiez();
                }
            }
            else
            {
                _ = DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }

        private async void Edytuj_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = listaMoichOgloszen.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                await Navigation.PushAsync(new DodajOgloszenie(ogloszenie));
                Odswiez();
            }
            else
            {
                _= DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }

        private void OdswiezBTN_Clicked(object sender, EventArgs e)
        {
            Odswiez();
        }
    }
}
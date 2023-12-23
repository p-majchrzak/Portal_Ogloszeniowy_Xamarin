using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik;
using Portal_Ogloszeniowy_Xamarin.Widoki.Administracja;
using Portal_Ogloszeniowy_Xamarin.Klasy;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StronaLogowania : ContentPage
    {
        public StronaLogowania()
        {
            InitializeComponent();
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void LogowanieBTN_Clicked(object sender, EventArgs e)
        {
            List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
            List<Firma> listaFirm = App.BazaDanych.Wypisz<Firma>();
            List<Administrator> listaAdministracja = App.BazaDanych.Wypisz<Administrator>();
            bool weryfikacja = false;
            for (int i = 0; i < listaPracownikow.Count; i++)
            {
                if (email.Text == listaPracownikow[i].Email && haslo.Text == listaPracownikow[i].Haslo)
                {
                    if (listaPracownikow[i].AktywneKonto)
                    {
                        weryfikacja = true;
                        App.GlobalnyPracownik = listaPracownikow[i];
                        Navigation.PushAsync(new MenuPracownik());
                    }
                    else
                    {
                        weryfikacja = true;
                        DisplayAlert("Informacja", "Konto nie zostało jeszcze aktywowane przez administratora.", "Ok");
                    }
                }
            }

            for (int i = 0; i < listaFirm.Count; i++)
            {
                if (email.Text == listaFirm[i].Email && haslo.Text == listaFirm[i].Haslo)
                {
                    if (listaFirm[i].Aktywne)
                    {
                        weryfikacja = true;
                        App.GlobalnaFirma = listaFirm[i];
                        Navigation.PushAsync(new MenuPracodawca());
                    }
                    else
                    {
                        weryfikacja = true;
                        DisplayAlert("Informacja", "Konto nie zostało jeszcze aktywowane przez administratora.", "Ok");
                    }
                }
            }

            for (int i = 0; i < listaAdministracja.Count; i++)
            {
                if (email.Text == listaAdministracja[i].Email && haslo.Text == listaAdministracja[i].Haslo)
                {
                    weryfikacja = true;
                    App.GlobalnyAdministrator = listaAdministracja[i];
                    Navigation.PushAsync(new MenuAdmin());
                }
            }
            if (weryfikacja == false)
            {
                DisplayAlert("Informacja", "Błędne dane do logowania!", "Ok");
            }
        }
    }
}
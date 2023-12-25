using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using Portal_Ogloszeniowy_Xamarin.Klasy;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RejestracjaPracodawca : ContentPage
    {
        public RejestracjaPracodawca()
        {
            InitializeComponent();
        }

        private void ZakonczBTN_Clicked(object sender, EventArgs e)
        {
            bool weryfikacja = true;
            if (
                App.WalidacjaTekst(nazwa.Text) &&
                App.WalidacjaDlugosc(zdjecie.Text, 1, 200) &&
                App.WalidacjaDlugosc(lokalizacja.Text, 1, 20) &&
                App.WalidacjaDlugosc(haslo.Text, 1, 20) &&
                App.WalidacjaMail(email.Text))
            {
                List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
                foreach (PracownikKlasa przeszukiwany in listaPracownikow)
                {
                    if (email.Text == przeszukiwany.Email)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                List<Firma> listaFirm = App.BazaDanych.Wypisz<Firma>();
                foreach (Firma przeszukiwana in listaFirm)
                {
                    if (email.Text == przeszukiwana.Email)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {
                    Firma firma = new Firma(nazwa.Text, zdjecie.Text, lokalizacja.Text, email.Text, haslo.Text, false);
                    App.BazaDanych.Zapisz(firma);
                    Navigation.PushAsync(new PodsumowanieRejestracji());
                }
                else
                {
                    DisplayAlert("Informacja!", "Użytkownik o takim adresie email został już zarejestrowany. \nUżyj innego adresu email.", "Ok");
                }

            }
            else
            {
                DisplayAlert("Informacja!", "Błędne dane!", "Ok");
            }
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
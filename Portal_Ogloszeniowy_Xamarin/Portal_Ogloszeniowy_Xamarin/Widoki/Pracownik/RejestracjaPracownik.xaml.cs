using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using Portal_Ogloszeniowy_Xamarin.Klasy;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RejestracjaPracownik : ContentPage
    {
        public RejestracjaPracownik()
        {
            InitializeComponent();
        }

        private void ZakonczBTN_Clicked(object sender, EventArgs e)
        {
            bool weryfikacja = true;
            if (
                App.WalidacjaTekst(imie.Text) &&
                App.WalidacjaTekst(nazwisko.Text) &&
                dataUrodzenia.Date != null &&
                App.WalidacjaMail(email.Text) &&
                App.WalidacjaNumer(numerTelefonu.Text) &&
                App.WalidacjaDlugosc(zdjecie.Text, 1, 200) &&
                App.WalidacjaDlugosc(adresZamieszkania.Text, 1, 20) &&
                App.WalidacjaTekst(nazwaStanowiska.Text) &&
                App.WalidacjaDlugosc(opisStanowiska.Text, 1, 100) &&
                App.WalidacjaDlugosc(doswiadczenieZawodowe.Text, 1, 100) &&
                App.WalidacjaDlugosc(edukacja.Text, 1, 100) &&
                App.WalidacjaDlugosc(jezyki.Text, 1, 100) &&
                App.WalidacjaDlugosc(umiejetnosci.Text, 1, 100) &&
                App.WalidacjaDlugosc(opis.Text, 1, 100) &&
                App.WalidacjaDlugosc(haslo.Text, 1, 20) &&
                App.WalidacjaDlugosc(linki.Text, 1, 100)
                )
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
                foreach (Firma firma in listaFirm)
                {
                    if (email.Text == firma.Email)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {

                    DateTime? dataPodana = dataUrodzenia.Date;
                    TimeSpan roznica = (TimeSpan)(dataPodana - DateTime.Now);
                    int wiek = (int)(roznica.TotalDays / 365.25);
                    if (wiek * -1 >= 18 && wiek * -1 <= 150)
                    {
                        PracownikKlasa pracownik = new PracownikKlasa(imie.Text, nazwisko.Text, dataUrodzenia.Date, email.Text, int.Parse(numerTelefonu.Text), zdjecie.Text, adresZamieszkania.Text,nazwaStanowiska.Text,opisStanowiska.Text,doswiadczenieZawodowe.Text
                            ,edukacja.Text,jezyki.Text,umiejetnosci.Text,linki.Text,opis.Text,haslo.Text,false);
                        App.BazaDanych.Zapisz(pracownik);
                        Navigation.PushAsync(new PodsumowanieRejestracji());
                    }
                    else
                    {
                        DisplayAlert("Informacja!", "Błędny wiek!", "Ok");
                    }
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
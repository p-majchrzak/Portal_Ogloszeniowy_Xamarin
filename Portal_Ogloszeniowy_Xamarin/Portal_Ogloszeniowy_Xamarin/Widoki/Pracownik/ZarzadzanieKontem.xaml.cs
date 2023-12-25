using Portal_Ogloszeniowy_Xamarin.Klasy;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZarzadzanieKontem : ContentPage
    {
        public ZarzadzanieKontem()
        {
            InitializeComponent();
            Aktualizuj();
        }

        private void ZapiszBTN_Clicked(object sender, EventArgs e)
        {
            if (
                App.WalidacjaDlugosc(zdjecie.Text, 1, 200) &&
                App.WalidacjaTekst(imie.Text) &&
                App.WalidacjaTekst(nazwisko.Text) &&
                App.WalidacjaDlugosc(opis.Text, 1, 100) &&
                App.WalidacjaMail(email.Text) &&
                App.WalidacjaNumer(numerTelefonu.Text) &&
                App.WalidacjaDlugosc(adresZamieszkania.Text, 1, 20) &&
                App.WalidacjaTekst(aktualneStanowisko.Text) &&
                App.WalidacjaDlugosc(opisStanowiska.Text, 1, 100) &&
                App.WalidacjaDlugosc(podsumowanieZawodoweOpis.Text, 1, 100) &&
                App.WalidacjaDlugosc(wyksztalcenie.Text, 1, 100) &&
                App.WalidacjaDlugosc(jezyk.Text, 1, 100) &&
                App.WalidacjaDlugosc(umiejetnosci.Text, 1, 100) &&
                App.WalidacjaDlugosc(linki.Text, 1, 100)
            )
            {
                App.GlobalnyPracownik.Zdjecie = zdjecie.Text;

                App.GlobalnyPracownik.Imie = imie.Text;
                App.GlobalnyPracownik.Naziwsko = nazwisko.Text;
                App.GlobalnyPracownik.DataUrodzenia = dataUrodzenia.Date;
                App.GlobalnyPracownik.Opis = opis.Text;
                App.GlobalnyPracownik.Email = email.Text;
                App.GlobalnyPracownik.Numer = int.Parse(numerTelefonu.Text);
                App.GlobalnyPracownik.AdresZamieszkania = adresZamieszkania.Text;
                App.GlobalnyPracownik.NazwaStanowiska = aktualneStanowisko.Text;
                App.GlobalnyPracownik.OpisStanowiska = opisStanowiska.Text;
                App.GlobalnyPracownik.DoswiadczenieZawodowe = podsumowanieZawodoweOpis.Text;
                App.GlobalnyPracownik.Wyksztalcenie = wyksztalcenie.Text;
                App.GlobalnyPracownik.ZnajomoscJezykow = jezyk.Text;
                App.GlobalnyPracownik.DodatkoweUmiejetnosci = umiejetnosci.Text;
                App.GlobalnyPracownik.Linki = linki.Text;

                DateTime? dataPodana = dataUrodzenia.Date;
                TimeSpan roznica = (TimeSpan)(dataPodana - DateTime.Now);
                int wiek = (int)(roznica.TotalDays / 365.25);
                if (wiek * -1 >= 18 && wiek * -1 <= 150)
                {
                    App.BazaDanych.Edytuj(App.GlobalnyPracownik);
                    DisplayAlert("Informacja", "Zmieniono dane!", "Ok");
                    Aktualizuj();
                }
                else
                {
                    DisplayAlert("Informacja", "Błędny wiek!", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Błędne dane!", "Ok");
            }
        }
        public void Aktualizuj()
        {
            zdjecie.Text = App.GlobalnyPracownik.Zdjecie;
            imie.Text = App.GlobalnyPracownik.Imie;
            nazwisko.Text = App.GlobalnyPracownik.Naziwsko;
            dataUrodzenia.Date = App.GlobalnyPracownik.DataUrodzenia.Value;
            opis.Text = App.GlobalnyPracownik.Opis;
            email.Text = App.GlobalnyPracownik.Email;
            numerTelefonu.Text = App.GlobalnyPracownik.Numer.ToString();
            adresZamieszkania.Text = App.GlobalnyPracownik.AdresZamieszkania;
            aktualneStanowisko.Text = App.GlobalnyPracownik.NazwaStanowiska;
            opisStanowiska.Text = App.GlobalnyPracownik.OpisStanowiska;
            podsumowanieZawodoweOpis.Text = App.GlobalnyPracownik.DoswiadczenieZawodowe;
            wyksztalcenie.Text = App.GlobalnyPracownik.Wyksztalcenie;
            jezyk.Text = App.GlobalnyPracownik.ZnajomoscJezykow;
            umiejetnosci.Text = App.GlobalnyPracownik.DodatkoweUmiejetnosci;
            linki.Text = App.GlobalnyPracownik.Linki;
        }
        private async void ZmienHasloBTN_Clicked(object sender, EventArgs e)
        {
            string wynik = await DisplayPromptAsync("Informacja", "Podaj obecne hasło: ", "Potwierdź", "Odrzuć", "obecne hasło", 20, Keyboard.Text);
            if (wynik == App.GlobalnyPracownik.Haslo)
            {
                string noweHaslo = await DisplayPromptAsync("Informacja", "Podaj nowe hasło: ", "Potwierdź", "Odrzuć", "nowe hasło", 20, Keyboard.Text);
                if (App.WalidacjaDlugosc(noweHaslo, 1, 20))
                {
                    App.GlobalnyPracownik.Haslo = noweHaslo;
                    App.BazaDanych.Edytuj(App.GlobalnyPracownik);
                    DisplayAlert("Informacja", "Zmieniono hasło!", "Ok");
                    Aktualizuj();
                }
                else
                {
                    DisplayAlert("Informacja", "Błędne dane!", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Błędne hasło!", "Ok");
            }
        }

        private async void UsunKontoBTN_Clicked(object sender, EventArgs e)
        {
            var wynik = await DisplayAlert("Informacja", "Czy aby napewno chcesz usunąć konto i połączone z nimi zgłoszenia?", "Tak", "Nie");
            if (wynik)
            {
                List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
                foreach (Zgloszenie zgloszenie in listaZgloszen)
                {
                    if (App.GlobalnyPracownik.ID == zgloszenie.Pracownik_ID)
                    {
                        App.BazaDanych.Usun(zgloszenie);
                    }
                }
                App.BazaDanych.Usun(App.GlobalnyPracownik);
                _ = DisplayAlert("Informacja", "Usunięto konto!", "Ok");
                await Navigation.PushAsync(new StronaWyboruRejestracjiLubLogowania());
            }
        }
    }
}
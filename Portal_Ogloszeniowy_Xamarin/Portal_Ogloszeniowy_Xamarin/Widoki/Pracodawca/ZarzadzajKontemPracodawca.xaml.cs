using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using System.Globalization;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZarzadzajKontemPracodawca : ContentPage
    {
        public ZarzadzajKontemPracodawca()
        {
            InitializeComponent();
            Aktualizuj();
        }

        public void Aktualizuj()
        {
            zdjecie.Text = App.GlobalnaFirma.Zdjecie;
            adresFirmy.Text = App.GlobalnaFirma.Adres;
            emailFirmy.Text = App.GlobalnaFirma.Email;
            nazwaFirmy.Text = App.GlobalnaFirma.Nazwa;
        }
        private void ZapiszBTN_Clicked(object sender, EventArgs e)
        {
            bool weryfikacja = true;
            if (
                App.WalidacjaTekst(nazwaFirmy.Text) &&
                App.WalidacjaDlugosc(zdjecie.Text, 1, 200) &&
                App.WalidacjaDlugosc(adresFirmy.Text, 1, 20) &&
                App.WalidacjaMail(emailFirmy.Text))
            {
                List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
                foreach (PracownikKlasa przeszukiwany in listaPracownikow)
                {
                    if (emailFirmy.Text == przeszukiwany.Email && emailFirmy.Text != App.GlobalnaFirma.Email)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                List<Firma> listaFirm = App.BazaDanych.Wypisz<Firma>();
                foreach (Firma przeszukiwana in listaFirm)
                {
                    if (emailFirmy.Text == przeszukiwana.Email && emailFirmy.Text != App.GlobalnaFirma.Email)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {
                    App.GlobalnaFirma.Zdjecie = zdjecie.Text;
                    App.GlobalnaFirma.Adres = adresFirmy.Text;
                    App.GlobalnaFirma.Email = emailFirmy.Text;
                    App.GlobalnaFirma.Nazwa = nazwaFirmy.Text;
                    App.BazaDanych.Edytuj(App.GlobalnaFirma);
                    DisplayAlert("Informacja!", "Zmieniono dane!", "Ok");
                    Aktualizuj();
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

        private async void ZmienHasloBTN_Clicked(object sender, EventArgs e)
        {
            string wynik = await DisplayPromptAsync("Informacja", "Podaj obecne hasło: ", "Potwierdź", "Odrzuć", "obecne hasło", 20, Keyboard.Text);
            if(wynik == App.GlobalnaFirma.Haslo)
            {
                string noweHaslo = await DisplayPromptAsync("Informacja", "Podaj nowe hasło: ", "Potwierdź", "Odrzuć", "nowe hasło", 20, Keyboard.Text);
                if(App.WalidacjaDlugosc(noweHaslo,1,20))
                {
                    App.GlobalnaFirma.Haslo = noweHaslo;
                    App.BazaDanych.Edytuj(App.GlobalnaFirma);
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
            var wynik = await DisplayAlert("Informacja", "Czy aby napewno chcesz usunąć konto i połączone z nimi oferty?", "Tak", "Nie");
            if(wynik)
            {
                List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
                List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
                foreach (Ogloszenie ogloszenie in listaOgloszen)
                {
                    if (ogloszenie.Firma_ID == App.GlobalnaFirma.ID)
                    {
                        int id = ogloszenie.ID;
                        App.BazaDanych.Usun(ogloszenie);
                        foreach (Zgloszenie zgloszenie in listaZgloszen)
                        {
                            if (id == zgloszenie.Ogloszenie_ID)
                            {
                                App.BazaDanych.Usun(zgloszenie);
                            }
                        }
                    }
                }
                App.BazaDanych.Usun(App.GlobalnaFirma);
                _ = DisplayAlert("Informacja", "Usunięto konto!", "Ok");
                await Navigation.PushAsync(new StronaWyboruRejestracjiLubLogowania());
            }
        }
    }
}
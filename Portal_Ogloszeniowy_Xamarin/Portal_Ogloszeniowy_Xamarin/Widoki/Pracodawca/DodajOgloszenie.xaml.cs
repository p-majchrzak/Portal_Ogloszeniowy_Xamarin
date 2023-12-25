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
    public partial class DodajOgloszenie : ContentPage
    {
        public DodajOgloszenie()
        {
            InitializeComponent(); 
            List<Kategorie> lista = App.BazaDanych.Wypisz<Kategorie>();
            List<string> listaKategorii = new List<string>();
            for (int i = 0; i < lista.Count; i++)
            {
                listaKategorii.Add(lista[i].Kategoria);
            }
            kategoria.ItemsSource = listaKategorii;
            Edytuj.IsVisible = false;
            Dodaj.IsVisible = true;
        }

        Ogloszenie ogloszenieGlobalne;
        public DodajOgloszenie(Ogloszenie ogloszenie)
        {
            InitializeComponent();
            List<Kategorie> lista = App.BazaDanych.Wypisz<Kategorie>();
            List<string> listaKategorii = new List<string>();
            for (int i = 0; i < lista.Count; i++)
            {
                listaKategorii.Add(lista[i].Kategoria);
            }
            kategoria.ItemsSource = listaKategorii;
            kategoria.SelectedIndex = 1;
            Title = "Edytuj ogłoszenie";
            nazwaStanowisko.Text = ogloszenie.NazwaStanowiska;
            poziomStanowiska.Text = ogloszenie.PoziomStanowiska;
            rodzajUmowy.Text = ogloszenie.RodzajUmowy;
            wymiarZatrudnienia.Text = ogloszenie.WymiarZatrudnienia;
            rodzajPracy.Text = ogloszenie.RodzajPracy;
            widelkiWynagrodzenia.Text = ogloszenie.WidelkiWynagrodzenia;
            dniPracy.Text = ogloszenie.DniPracy;
            godzinyPracy.Text = ogloszenie.GodzinyPracy;
            dataWaznosci.Date = ogloszenie.DataWaznosci.Value;
            obowiazki.Text = ogloszenie.ZakresObowiazkow;
            benefity.Text = ogloszenie.Benefity;
            Edytuj.IsVisible = true;
            Dodaj.IsVisible = false;
            ogloszenieGlobalne = ogloszenie;
        }
        private void Dodaj_Clicked(object sender, EventArgs e)
        {

            string kategoriaWybrana = kategoria.SelectedItem.ToString();
            List<Kategorie> lista = App.BazaDanych.Wypisz<Kategorie>();
            Kategorie kategorie = new Kategorie();
            for (int i = 0; i < lista.Count; i++)
            {
                if (kategoriaWybrana == lista[i].Kategoria)
                {
                    kategorie = lista[i];
                    break;
                }
            }

            Ogloszenie ogloszenie = new Ogloszenie(App.GlobalnaFirma, nazwaStanowisko.Text, poziomStanowiska.Text,
            rodzajUmowy.Text, wymiarZatrudnienia.Text, rodzajPracy.Text, widelkiWynagrodzenia.Text, dniPracy.Text, godzinyPracy.Text,
            dataWaznosci.Date, kategorie, obowiazki.Text, benefity.Text);
            if (
                App.WalidacjaDlugosc(nazwaStanowisko.Text, 1, 100) &&
                App.WalidacjaDlugosc(poziomStanowiska.Text, 1, 100) &&
                App.WalidacjaDlugosc(rodzajUmowy.Text, 1, 100) &&
                App.WalidacjaDlugosc(wymiarZatrudnienia.Text, 1, 100) &&
                App.WalidacjaDlugosc(rodzajPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(widelkiWynagrodzenia.Text, 1, 100) &&
                App.WalidacjaDlugosc(dniPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(godzinyPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(obowiazki.Text, 1, 100) &&
                App.WalidacjaDlugosc(benefity.Text, 1, 100) &&
                kategorie != null && App.GlobalnaFirma != null && dataWaznosci.Date != null && dataWaznosci.Date > DateTime.Now)
            {
                App.BazaDanych.Zapisz(ogloszenie);
                DisplayAlert("Informacja", "Dodano ogłoszenie!", "Ok");
                List<Newsletter> listaOsob = App.BazaDanych.Wypisz<Newsletter>();
                for (int i = 0; i < listaOsob.Count; i++)
                {
                    App.WyslijEmail(listaOsob[i].Email, "Dodano nowe ogłoszenie o pracę!", "Wyszukaj go pod frazą '" + ogloszenie.NazwaStanowiska + "'.\nPozdrawiamy zespół Poszukujemy!");
                }
                nazwaStanowisko.Text = ""; poziomStanowiska.Text = "";
                rodzajUmowy.Text = ""; wymiarZatrudnienia.Text = ""; 
                rodzajPracy.Text = ""; widelkiWynagrodzenia.Text = ""; 
                dniPracy.Text = ""; godzinyPracy.Text = "";
                obowiazki.Text = ""; benefity.Text = "";
            }
            else
            {
                DisplayAlert("Informacja", "Błędne dane!", "Ok");
            }
        }

        private void Edytuj_Clicked(object sender, EventArgs e)
        {
            ogloszenieGlobalne.NazwaStanowiska = nazwaStanowisko.Text;
            ogloszenieGlobalne.PoziomStanowiska = poziomStanowiska.Text;
            ogloszenieGlobalne.RodzajUmowy = rodzajUmowy.Text;
            ogloszenieGlobalne.WymiarZatrudnienia = wymiarZatrudnienia.Text;
            ogloszenieGlobalne.RodzajPracy = rodzajPracy.Text;
            ogloszenieGlobalne.WidelkiWynagrodzenia = widelkiWynagrodzenia.Text;
            ogloszenieGlobalne.DniPracy = dniPracy.Text;
            ogloszenieGlobalne.GodzinyPracy = godzinyPracy.Text;
            ogloszenieGlobalne.DataWaznosci = dataWaznosci.Date;
            ogloszenieGlobalne.ZakresObowiazkow = obowiazki.Text;
            ogloszenieGlobalne.Benefity = benefity.Text;
            if (
                App.WalidacjaDlugosc(nazwaStanowisko.Text, 1, 100) &&
                App.WalidacjaDlugosc(poziomStanowiska.Text, 1, 100) &&
                App.WalidacjaDlugosc(rodzajUmowy.Text, 1, 100) &&
                App.WalidacjaDlugosc(wymiarZatrudnienia.Text, 1, 100) &&
                App.WalidacjaDlugosc(rodzajPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(widelkiWynagrodzenia.Text, 1, 100) &&
                App.WalidacjaDlugosc(dniPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(godzinyPracy.Text, 1, 100) &&
                App.WalidacjaDlugosc(obowiazki.Text, 1, 100) &&
                App.WalidacjaDlugosc(benefity.Text, 1, 100) &&
                App.GlobalnaFirma != null && dataWaznosci.Date != null && dataWaznosci.Date > DateTime.Now)
            {
                App.BazaDanych.Edytuj(ogloszenieGlobalne);
                DisplayAlert("Informacja", "Zmodyfikowano ogłoszenie!", "Ok");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Informacja", "Błędne dane!", "Ok");
            }
        }
    }
}
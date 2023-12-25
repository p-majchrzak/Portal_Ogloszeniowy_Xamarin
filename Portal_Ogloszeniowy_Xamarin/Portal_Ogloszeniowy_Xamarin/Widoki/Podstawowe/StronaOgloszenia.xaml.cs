using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StronaOgloszenia : ContentPage
	{
        Ogloszenie globalneOgloszenie = new Ogloszenie();

        public StronaOgloszenia (Ogloszenie ogloszenie)
		{
			InitializeComponent();
            zglosSieBTN.IsVisible = true;
            Title = ogloszenie.NazwaStanowiska;
            globalneOgloszenie = ogloszenie;
            NazwaStanowiska.Text = "Nazwa stanowiska: " + ogloszenie.NazwaStanowiska;
            PoziomStanowiska.Text = "Poziom stanowiska: " + ogloszenie.PoziomStanowiska;
            RodzajUmowy.Text = "Rodzaj umowy: " + ogloszenie.RodzajUmowy;
            WymiarZatrudnienia.Text = "Wymiar zatrudnienia: " + ogloszenie.WymiarZatrudnienia;
            RodzajPracy.Text = "Rodzaj pracy: " + ogloszenie.RodzajPracy;
            WidelkiWynagrodzenia.Text = "Widełki wynagrodzenia: " + ogloszenie.WidelkiWynagrodzenia;
            DniPracy.Text = "Dni pracy: " + ogloszenie.DniPracy;
            GodzinyPracy.Text = "Godziny pracy: " + ogloszenie.GodzinyPracy;
            ZakresObowiazkow.Text = "Zakres obowiązków: " + ogloszenie.ZakresObowiazkow;
            Benefity.Text = "Benefity: " + ogloszenie.Benefity;
            List<Firma> listaFirm = App.BazaDanych.Wypisz<Firma>();
            Firma firma = new Firma();
            for (int i = 0; i < listaFirm.Count; i++)
            {
                if (ogloszenie.Firma_ID == listaFirm[i].ID)
                {
                    firma = listaFirm[i];
                    break;
                }
            }
            nazwaFirmy.Text = firma.Nazwa;
            adresFirmy.Text = firma.Adres;
            email.Text = "E-mail: " + firma.Email;
            Zdjecie.Source = firma.Zdjecie;
        }
        public StronaOgloszenia(Ogloszenie ogloszenie, bool wybor)
        {
            InitializeComponent();
            zglosSieBTN.IsVisible = false;
            Title = ogloszenie.NazwaStanowiska;
            globalneOgloszenie = ogloszenie;
            NazwaStanowiska.Text = "Nazwa stanowiska: " + ogloszenie.NazwaStanowiska;
            PoziomStanowiska.Text = "Poziom stanowiska: " + ogloszenie.PoziomStanowiska;
            RodzajUmowy.Text = "Rodzaj umowy: " + ogloszenie.RodzajUmowy;
            WymiarZatrudnienia.Text = "Wymiar zatrudnienia: " + ogloszenie.WymiarZatrudnienia;
            RodzajPracy.Text = "Rodzaj pracy: " + ogloszenie.RodzajPracy;
            WidelkiWynagrodzenia.Text = "Widełki wynagrodzenia: " + ogloszenie.WidelkiWynagrodzenia;
            DniPracy.Text = "Dni pracy: " + ogloszenie.DniPracy;
            GodzinyPracy.Text = "Godziny pracy: " + ogloszenie.GodzinyPracy;
            ZakresObowiazkow.Text = "Zakres obowiązków: " + ogloszenie.ZakresObowiazkow;
            Benefity.Text = "Benefity: " + ogloszenie.Benefity;
            List<Firma> listaFirm = App.BazaDanych.Wypisz<Firma>();
            Firma firma = new Firma();
            for (int i = 0; i < listaFirm.Count; i++)
            {
                if (ogloszenie.Firma_ID == listaFirm[i].ID)
                {
                    firma = listaFirm[i];
                    break;
                }
            }
            nazwaFirmy.Text = firma.Nazwa;
            adresFirmy.Text = firma.Adres;
            email.Text = "E-mail: " + firma.Email;
            Zdjecie.Source = firma.Zdjecie;
        }
        private void zglosSieBTN_Clicked(object sender, EventArgs e)
        {
            List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
            bool weryfikacja = true;
            for (int i = 0; i < listaZgloszen.Count; i++)
            {
                if (listaZgloszen[i].Ogloszenie_ID == globalneOgloszenie.ID && listaZgloszen[i].Pracownik_ID == App.GlobalnyPracownik.ID)
                {
                    weryfikacja = false;
                    break;
                }
            }
            if (weryfikacja == true)
            {
                Zgloszenie zgloszenie = new Zgloszenie(globalneOgloszenie, App.GlobalnyPracownik);
                App.BazaDanych.Zapisz(zgloszenie);
                DisplayAlert("Informacja", "Wysłano zgłoszenie!", "Ok");
            }
            else
            {
                DisplayAlert("Informacja", "Już wysłałeś zgłoszenie do tej oferty!", "Ok");
            }
        }
    }
}
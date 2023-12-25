using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using Portal_Ogloszeniowy_Xamarin.Klasy;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StronaGlownaPracodawca : ContentPage
    {
        public StronaGlownaPracodawca()
        {
            InitializeComponent();
            Odswiez();
        }
        public void Odswiez()
        {
            List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
            List<Zgloszenie> przypisywaneZgloszenia = new List<Zgloszenie>();
            List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
            for (int i = 0; i < listaZgloszen.Count; i++)
            {
                for (int j = 0; j < listaOgloszen.Count; j++)
                {
                    if (listaZgloszen[i].Ogloszenie_ID == listaOgloszen[j].ID && listaOgloszen[j].Firma_ID == App.GlobalnaFirma.ID)
                    {
                        przypisywaneZgloszenia.Add(listaZgloszen[i]);
                    }
                }
            }
            listaMoichZgloszen.ItemsSource = przypisywaneZgloszenia;
        }
        private void ZobaczAplikujacegoBTN_Clicked(object sender, EventArgs e)
        {
            Zgloszenie zgloszenie = listaMoichZgloszen.SelectedItem as Zgloszenie;
            if (zgloszenie != null)
            {
                List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
                foreach(PracownikKlasa szukany in listaPracownikow)
                {
                    if(szukany.ID == zgloszenie.Pracownik_ID)
                    {
                        App.GlobalnyPracownik = szukany;
                        break;
                    }
                }
                Navigation.PushAsync(new WyswietlMojProfil());
                App.GlobalnyPracownik = null;
            }
            else
            {
                DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }

        private void ZobaczOgloszenieBTN_Clicked(object sender, EventArgs e)
        {
            Zgloszenie zgloszenie = listaMoichZgloszen.SelectedItem as Zgloszenie;
            if (zgloszenie != null)
            {
                List<Ogloszenie> ogloszenia = App.BazaDanych.Wypisz<Ogloszenie>();
                Ogloszenie ogloszenie = new Ogloszenie();
                foreach(Ogloszenie szukane in ogloszenia)
                {
                    if(zgloszenie.Ogloszenie_ID == szukane.ID)
                    {
                        ogloszenie = szukane;
                        break;
                    }
                }
                Navigation.PushAsync(new StronaOgloszenia(ogloszenie, true));
            }
            else
            {
                DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }

        private void OdrzucBTN_Clicked(object sender, EventArgs e)
        {
            Zgloszenie zgloszenie = listaMoichZgloszen.SelectedItem as Zgloszenie;
            if (zgloszenie != null)
            {
                List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
                List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
                PracownikKlasa pracownik = new PracownikKlasa();
                Ogloszenie ogloszenie = new Ogloszenie();
                for (int i = 0; i < listaPracownikow.Count; i++)
                {
                    if (zgloszenie.Pracownik_ID == listaPracownikow[i].ID)
                    {
                        pracownik = listaPracownikow[i];
                        break;
                    }
                }
                for (int i = 0; i < listaOgloszen.Count; i++)
                {
                    if (zgloszenie.Ogloszenie_ID == listaOgloszen[i].ID)
                    {
                        ogloszenie = listaOgloszen[i];
                        break;
                    }
                }
                App.WyslijEmail(pracownik.Email, "Informacja w sprawie rekrutacji!", "Twoja rekrutacja na stanowisko " + ogloszenie.NazwaStanowiska + " została odrzucona. \nDziękujemy za korzystanie z naszych usług,\nZespół Poszukujemy.");
                App.BazaDanych.Usun(zgloszenie);
                Odswiez();
            }
            else
            {
                DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }

        private void AkceptujBTN_Clicked(object sender, EventArgs e)
        {
            Zgloszenie zgloszenie = listaMoichZgloszen.SelectedItem as Zgloszenie;
            if (zgloszenie != null)
            {
                List<PracownikKlasa> listaPracownikow = App.BazaDanych.Wypisz<PracownikKlasa>();
                List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
                PracownikKlasa pracownik = new PracownikKlasa();
                Ogloszenie ogloszenie = new Ogloszenie();
                for (int i = 0; i < listaPracownikow.Count; i++)
                {
                    if (zgloszenie.Pracownik_ID == listaPracownikow[i].ID)
                    {
                        pracownik = listaPracownikow[i];
                        break;
                    }
                }
                for (int i = 0; i < listaOgloszen.Count; i++)
                {
                    if (zgloszenie.Ogloszenie_ID == listaOgloszen[i].ID)
                    {
                        ogloszenie = listaOgloszen[i];
                        break;
                    }
                }
                App.WyslijEmail(pracownik.Email, "Informacja w sprawie rekrutacji!", "Twoja rekrutacja na stanowisko " + ogloszenie.NazwaStanowiska + " została zaakceptowana. \nZapraszamy na rozmowę rekrutacyjną do siedziby " + App.GlobalnaFirma.Nazwa + " która znajduje się pod adresem " + App.GlobalnaFirma.Adres + ".\nW razie pytań prosimy o kontakt pod adresem mailowym: " + App.GlobalnaFirma.Email + " \nDziękujemy za korzystanie z naszych usług,\nZespół Poszukujemy.");
                App.BazaDanych.Usun(zgloszenie);
                Odswiez();
            }
            else
            {
                DisplayAlert("Informacja", "Należy zaznaczyć element na liście.", "Ok");
            }
        }
    }
}
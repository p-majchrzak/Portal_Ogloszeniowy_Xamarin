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
    public partial class ZapisaneOferty : ContentPage
    {
        public ZapisaneOferty()
        {
            InitializeComponent();
            OdswiezListe();
        }

        void OdswiezListe()
        {
            List<Zapisane> listaZapisanych = App.BazaDanych.Wypisz<Zapisane>();
            List<Zapisane> nowaLista = new List<Zapisane>();

            foreach (Zapisane zapisane in listaZapisanych)
            {
                if(zapisane.Pracownik == App.GlobalnyPracownik.ID)
                {
                    nowaLista.Add(zapisane);
                }
            }

            List<Ogloszenie> ogloszenia = App.BazaDanych.Wypisz<Ogloszenie>();
            List<Ogloszenie> ogloszeniaNowe = new List<Ogloszenie>();

            for(int i = 0; i<nowaLista.Count; i++)
            {
                for(int j = 0;  j < ogloszenia.Count; j++)
                {
                    if (ogloszenia[j].ID == nowaLista[i].Ogloszenie && nowaLista[i].Pracownik == App.GlobalnyPracownik.ID)
                    {
                        ogloszeniaNowe.Add(ogloszenia[j]);
                    }
                }
            }

            listaOgloszen.ItemsSource = ogloszeniaNowe;
        }
        private void Usun_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = listaOgloszen.SelectedItem as Ogloszenie;
            if(ogloszenie!=null)
            {
                List<Zapisane> zapisaneLista = App.BazaDanych.Wypisz<Zapisane>();
                foreach(Zapisane zapisane in zapisaneLista)
                {
                    if(zapisane.Ogloszenie == ogloszenie.ID && zapisane.Pracownik == App.GlobalnyPracownik.ID)
                    {
                        App.BazaDanych.Usun(zapisane);
                        OdswiezListe();
                    }
                }
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać ogłoszenie z listy!", "Ok");
            }
        }

        private void Zobacz_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = listaOgloszen.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                Navigation.PushAsync(new StronaOgloszenia(ogloszenie));
            }
            else
            {
                DisplayAlert("Informacja", "Należy nacisnąć na ogłoszenie!", "Ok");
            }
        }
    }
}
using Portal_Ogloszeniowy_Xamarin.Klasy;
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
    public partial class StronaGlownaPracownik : ContentPage
    {
        public StronaGlownaPracownik()
        {
            InitializeComponent();
            Odswiez();
        }
        public void Odswiez()
        {
            listaOgloszen.ItemsSource = App.BazaDanych.Wypisz<Ogloszenie>();
        }

        private void Zapisz_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = listaOgloszen.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                List<Zapisane> listaZapisanych = App.BazaDanych.Wypisz<Zapisane>();
                bool weryfikacja = true;
                foreach (Zapisane zapisane in listaZapisanych)
                {
                    if (zapisane.Pracownik == App.GlobalnyPracownik.ID && zapisane.Ogloszenie == ogloszenie.ID)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {
                    Zapisane zapisane = new Zapisane(ogloszenie.ID, App.GlobalnyPracownik.ID);
                    App.BazaDanych.Zapisz(zapisane);
                    DisplayAlert("Informacja", "Zapisano ogłoszenie.", "Ok");
                }
                else
                {
                    DisplayAlert("Informacja", "Zapisałeś już te ogłoszenie.", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Należy nacisnąć na ogłoszenie które chcesz zapisać!", "Ok");
            }
        }

        private void Zobacz_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
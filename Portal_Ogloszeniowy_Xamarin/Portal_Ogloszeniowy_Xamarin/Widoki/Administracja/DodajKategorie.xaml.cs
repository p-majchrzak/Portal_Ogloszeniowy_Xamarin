using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Administracja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DodajKategorie : ContentPage
    {
        public DodajKategorie()
        {
            InitializeComponent();
        }

        private void Dodaj_Clicked(object sender, EventArgs e)
        {
            if (App.WalidacjaTekst(dodawanaKategoria.Text))
            {
                bool weryfikacja = true;
                List<Kategorie> listaKategorii = App.BazaDanych.Wypisz<Kategorie>();
                foreach (Kategorie kategoriaSzukana in listaKategorii)
                {
                    if (kategoriaSzukana.Kategoria == dodawanaKategoria.Text)
                    {
                        DisplayAlert("Informacja", "Kategoria o takiej nazwie już istnieje.", "Ok");
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {
                    Kategorie kategorie = new Kategorie(dodawanaKategoria.Text);
                    App.BazaDanych.Zapisz(kategorie);
                    DisplayAlert("Informacja", "Dodano kategorie.", "Ok");
                    dodawanaKategoria.Text = "";
                }
            }
            else
            {
                DisplayAlert("Informacja", "Błędna nazwa kategorii.", "Ok");
            }
        }
    }
}
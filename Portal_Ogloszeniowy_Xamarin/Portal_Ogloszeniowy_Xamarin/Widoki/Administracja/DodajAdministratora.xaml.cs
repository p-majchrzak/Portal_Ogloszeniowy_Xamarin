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
    public partial class DodajAdministratora : ContentPage
    {
        public DodajAdministratora()
        {
            InitializeComponent();
        }

        private void Dodaj_Clicked(object sender, EventArgs e)
        {
            if (App.WalidacjaTekst(login.Text) && App.WalidacjaDlugosc(haslo.Text, 1, 20))
            {
                if (!App.WalidacjaMail(login.Text))
                {
                    bool weryfikacja = true;
                    List<Administrator> listaAdminow = App.BazaDanych.Wypisz<Administrator>();
                    foreach (Administrator administrator in listaAdminow)
                    {
                        if (administrator.Email == login.Text)
                        {
                            DisplayAlert("Informacja", "Administrator o takim loginie już istnieje.", "Ok");
                            weryfikacja = false;
                        }
                    }
                    if (weryfikacja)
                    {
                        Administrator administrator = new Administrator(login.Text, haslo.Text);
                        App.BazaDanych.Zapisz(administrator);
                        DisplayAlert("Informacja", "Dodano administratora.", "Ok");
                        login.Text = "";
                        haslo.Text = "";
                    }
                }
                else
                {
                    DisplayAlert("Informacja", "Administrator nie może się logować przez maila. \nMusi korzystać z loginu.", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Błędne dane!", "Ok");
            }
        }
    }
}
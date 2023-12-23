using Portal_Ogloszeniowy_Xamarin.Klasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Administracja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZarzadzajAdministratorami : ContentPage
    {
        public ZarzadzajAdministratorami()
        {
            InitializeComponent();
            OdsiwezListe();
        }

        public void OdsiwezListe()
        {
            List<Administrator> listaAdmin = App.BazaDanych.Wypisz<Administrator>();
            List<string> nowaListaAdmin = new List<string>();
            foreach (Administrator administrator in listaAdmin)
            {
                nowaListaAdmin.Add(administrator.Email);
            }
            listaAdminow.ItemsSource = nowaListaAdmin;
            listaAdminow.SelectedIndex = 0;
        }
        private void Usuń_Clicked(object sender, EventArgs e)
        {
            List<Administrator> listaAdministracja = App.BazaDanych.Wypisz<Administrator>();
            Administrator admin = listaAdministracja[listaAdminow.SelectedIndex];
            if (admin != null)
            {
                if (listaAdministracja.Count > 1)
                {
                    if (admin.Email != "admin")
                    {
                        if(App.GlobalnyAdministrator.Email == admin.Email)
                        {
                            App.BazaDanych.Usun(admin);
                            DisplayAlert("Informacja", "Usunąłeś swoje konto!", "Ok");
                            OdsiwezListe();
                            Navigation.PushAsync(new StronaWyboruRejestracjiLubLogowania());
                        }
                        else
                        {
                            App.BazaDanych.Usun(admin);
                            DisplayAlert("Informacja", "Usunięto " + admin.Email + "!", "Ok");
                            OdsiwezListe();
                        }
                    }
                    else
                    {
                        DisplayAlert("Informacja", "Nie wolno usunąć administratora głównego!", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Informacja", "Wymagane jest posiadanie minimum 1 administratorów.", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać element z listy!", "Ok");
            }
        }
    }
}
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
    public partial class StronaWyboruRejestracjiLubLogowania : ContentPage
    {
        public StronaWyboruRejestracjiLubLogowania()
        {
            InitializeComponent();
            App.GlobalnyPracownik = null;
            App.GlobalnyAdministrator = null;
            App.GlobalnaFirma = null;
            bool weryfikacja = true;
            List<Administrator> listaAdminow = App.BazaDanych.Wypisz<Administrator>();
            foreach(Administrator administrator in listaAdminow)
            {
                if(administrator.Email == "admin" && administrator.Haslo == "admin")
                {
                    weryfikacja = false;
                    break;
                }
            }
            if(weryfikacja)
            {
                App.BazaDanych.Zapisz(new Administrator("admin", "admin"));
            }
            List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
            List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
            List<Zapisane> listaZapisanych = App.BazaDanych.Wypisz<Zapisane>();
            foreach (Ogloszenie ogloszenie in listaOgloszen)
            {
                if (ogloszenie.DataWaznosci < DateTime.Now)
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
                    foreach (Zapisane zapisane in listaZapisanych)
                    {
                        if (id == zapisane.Ogloszenie)
                        {
                            App.BazaDanych.Usun(zapisane);
                        }
                    }
                }
            }
        }

        private void PolitykaPrywatnosciLink_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PolitykaPrywatnosci());
        }

        private void RejestracjaBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WyborTypuKontaPrzyRejestracji());
        }

        private void LogowanieBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StronaLogowania());
        }
    }
}
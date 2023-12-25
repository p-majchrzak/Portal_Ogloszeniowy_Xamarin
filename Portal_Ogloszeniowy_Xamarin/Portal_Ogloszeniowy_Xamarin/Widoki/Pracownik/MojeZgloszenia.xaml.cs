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
    public partial class MojeZgloszenia : ContentPage
    {
        public MojeZgloszenia()
        {
            InitializeComponent();
            Odswiez();
        }

        public void Odswiez()
        {
            List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
            List<Ogloszenie> listaOgloszen = App.BazaDanych.Wypisz<Ogloszenie>();
            List<Ogloszenie> listaNowychOgloszen = new List<Ogloszenie>();
            foreach (Zgloszenie zgloszenie in listaZgloszen)
            {
                if (zgloszenie.Pracownik_ID == App.GlobalnyPracownik.ID)
                {
                    foreach (Ogloszenie ogloszenie in listaOgloszen)
                    {
                        if (zgloszenie.Ogloszenie_ID == ogloszenie.ID)
                        {
                            listaNowychOgloszen.Add(ogloszenie);
                        }
                    }
                }
            }
            lista.ItemsSource = listaNowychOgloszen;
        }
        private void Zobacz_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = lista.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                Navigation.PushAsync(new StronaOgloszenia(ogloszenie));
            }
            else
            {
                DisplayAlert("Informacja", "Należy nacisnąć na ogłoszenie!", "Ok");
            }
        }

        private void Anuluj_Clicked(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = lista.SelectedItem as Ogloszenie;
            if (ogloszenie != null)
            {
                List<Zgloszenie> listaZgloszen = App.BazaDanych.Wypisz<Zgloszenie>();
                foreach(Zgloszenie zgloszenie in listaZgloszen)
                {
                    if(zgloszenie.Ogloszenie_ID == ogloszenie.ID && zgloszenie.Pracownik_ID == App.GlobalnyPracownik.ID)
                    {
                        App.BazaDanych.Usun(zgloszenie);
                        break;
                    }
                }
                DisplayAlert("Informacja", "Anulowano aplikację na stanowisko!", "Ok");
                Odswiez();
            }
            else
            {
                DisplayAlert("Informacja", "Należy nacisnąć na ogłoszenie!", "Ok");
            }
        }
    }
}
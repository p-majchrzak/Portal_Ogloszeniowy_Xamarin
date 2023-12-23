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
    public partial class AktywujKontaPracodawca : ContentPage
    {
        public AktywujKontaPracodawca()
        {
            InitializeComponent();
            lista.ItemsSource = OdswiezListe();
        }
        public static List<Firma> OdswiezListe()
        {
            List<Firma> listaFirm = new List<Firma>();
            List<Firma> listaZBazy = App.BazaDanych.Wypisz<Firma>();    
            foreach(Firma firma in listaZBazy)
            {
                if(firma.Aktywne == false)
                {
                    listaFirm.Add(firma);
                }
            }
            return listaFirm;
        }

        private void Akceptuj_Clicked(object sender, EventArgs e)
        {
            if(lista.SelectedItem != null)
            {
                Firma firma = lista.SelectedItem as Firma;
                firma.Aktywne = true;
                App.BazaDanych.Edytuj(firma);
                DisplayAlert("Informacja", "Aktywowano konto.", "Ok");
                lista.ItemsSource = OdswiezListe();
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać element z listy.", "Ok");
            }
        }

        private void Odrzuć_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                Firma firma = lista.SelectedItem as Firma;
                App.BazaDanych.Usun(firma);
                DisplayAlert("Informacja", "Usunięto konto.", "Ok");
                lista.ItemsSource = OdswiezListe();
            }
            else
            {
                DisplayAlert("Informacja", "Należy wybrać element z listy.", "Ok");
            }
        }
    }
}
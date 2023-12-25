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
    public partial class WyswietlMojProfil : ContentPage
    {
        public WyswietlMojProfil()
        {
            InitializeComponent();
            zdjecie.Source = App.GlobalnyPracownik.Zdjecie;
            imie.Text = App.GlobalnyPracownik.Imie;
            nazwisko.Text = App.GlobalnyPracownik.Naziwsko;
            dataUrodzenia.Text = App.GlobalnyPracownik.DataUrodzenia.Value.ToString("yyyy-MM-dd");
            opis.Text = App.GlobalnyPracownik.Opis;
            email.Text = "E-mail: " + App.GlobalnyPracownik.Email;
            numerTelefonu.Text = "Numer: " + App.GlobalnyPracownik.Numer;
            adresZamieszkania.Text = "Adres zamieszkania: " + App.GlobalnyPracownik.AdresZamieszkania;
            aktualneStanowisko.Text = "Aktualne stanowisko: " + App.GlobalnyPracownik.NazwaStanowiska;
            opisStanowiska.Text = "Opis: " + App.GlobalnyPracownik.OpisStanowiska;
            podsumowanieZawodoweOpis.Text = "Opis: " + App.GlobalnyPracownik.DoswiadczenieZawodowe;
            wyksztalcenie.Text = "Opis: " + App.GlobalnyPracownik.Wyksztalcenie;
            jezyk.Text = "Język-Poziom: " + App.GlobalnyPracownik.ZnajomoscJezykow;
            umiejetnosci.Text = "Opis: " + App.GlobalnyPracownik.DodatkoweUmiejetnosci;
            linki.Text = "Linki: " + App.GlobalnyPracownik.Linki;
        }
    }
}
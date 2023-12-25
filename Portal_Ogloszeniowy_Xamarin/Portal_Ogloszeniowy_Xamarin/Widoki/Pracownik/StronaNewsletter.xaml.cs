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
	public partial class StronaNewsletter : ContentPage
	{
		public StronaNewsletter ()
		{
			InitializeComponent ();
		}

        private void ZapiszSieBTN_Clicked(object sender, EventArgs e)
        {
            if (App.WalidacjaMail(email.Text))
            {
                bool weryfikacja = true;
                List<Newsletter> listaZapisanych = App.BazaDanych.Wypisz<Newsletter>();
                foreach (Newsletter zapisany in listaZapisanych)
                {
                    if (zapisany.Email == email.Text)
                    {
                        weryfikacja = false;
                        break;
                    }
                }
                if (weryfikacja)
                {
                    Newsletter newsletter = new Newsletter(email.Text);
                    App.BazaDanych.Zapisz(newsletter);
                    App.WyslijEmail(email.Text, "Zapisano do newslettera!", "Informujemy że zapisane do newslettera przebiegło pomyślnie! \nBędziesz otrzymywać wiadomości o nowych ofertach pracy.\nZespół Poszukujemy.");
                    DisplayAlert("Informacja", "Zapisałeś się do newslettera!", "Ok");
                    email.Text = "";
                }
                else
                {
                    DisplayAlert("Informacja", "Adres email został już wcześniej zarejestrowany do newslettera!", "Ok");
                }
            }
            else
            {
                DisplayAlert("Informacja", "Błędne dane!", "Ok");
            }
        }
    }
}
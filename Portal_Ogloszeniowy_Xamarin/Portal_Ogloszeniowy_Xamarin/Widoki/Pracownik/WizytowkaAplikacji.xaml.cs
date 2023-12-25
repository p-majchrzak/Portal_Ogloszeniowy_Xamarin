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
	public partial class WizytowkaAplikacji : ContentPage
	{
		public WizytowkaAplikacji ()
		{
			InitializeComponent ();
			iloscSzukajacychPracy.Text = "• Szukający pracy:" + App.BazaDanych.Wypisz<PracownikKlasa>().Count.ToString();
			iloscOgloszenOPrace.Text = "• Ogłoszenia: " + App.BazaDanych.Wypisz<Ogloszenie>().Count.ToString();
			iloscFirm.Text = "• Firmy: " + App.BazaDanych.Wypisz<Firma>().Count.ToString();
			daneOsobowe.Text = App.GlobalnyPracownik.Imie + " " + App.GlobalnyPracownik.Naziwsko;

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
            iloscZgloszen.Text = "• Zgłoszenia: " + listaNowychOgloszen.Count;

            List<Zapisane> listaZapisanych = App.BazaDanych.Wypisz<Zapisane>();
            List<Zapisane> nowaLista = new List<Zapisane>();

            foreach (Zapisane zapisane in listaZapisanych)
            {
                if (zapisane.Pracownik == App.GlobalnyPracownik.ID)
                {
                    nowaLista.Add(zapisane);
                }
            }

            List<Ogloszenie> ogloszenia = App.BazaDanych.Wypisz<Ogloszenie>();
            List<Ogloszenie> ogloszeniaNowe = new List<Ogloszenie>();

            for (int i = 0; i < nowaLista.Count; i++)
            {
                for (int j = 0; j < ogloszenia.Count; j++)
                {
                    if (ogloszenia[j].ID == nowaLista[i].Ogloszenie && nowaLista[i].Pracownik == App.GlobalnyPracownik.ID)
                    {
                        ogloszeniaNowe.Add(ogloszenia[j]);
                    }
                }
            }
            iloscZapisanychOfet.Text = "• Zapisane: " + ogloszeniaNowe.Count;
        }
	}
}
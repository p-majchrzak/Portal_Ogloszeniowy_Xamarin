using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WyborTypuKontaPrzyRejestracji : ContentPage
    {
        public WyborTypuKontaPrzyRejestracji()
        {
            InitializeComponent();
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void PracownikBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RejestracjaPracownik());
        }

        private void PracodawcaBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RejestracjaPracodawca());
        }
    }
}
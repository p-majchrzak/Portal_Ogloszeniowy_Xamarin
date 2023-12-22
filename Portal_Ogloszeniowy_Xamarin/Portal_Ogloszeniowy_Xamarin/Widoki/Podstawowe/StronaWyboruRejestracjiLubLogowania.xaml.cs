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
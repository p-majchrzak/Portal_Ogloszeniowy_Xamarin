using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StronaLogowania : ContentPage
    {
        public StronaLogowania()
        {
            InitializeComponent();
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void LogowanieBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPracownik());
        }
    }
}
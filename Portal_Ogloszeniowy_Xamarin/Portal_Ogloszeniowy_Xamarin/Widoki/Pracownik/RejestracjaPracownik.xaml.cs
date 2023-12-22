using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RejestracjaPracownik : ContentPage
    {
        public RejestracjaPracownik()
        {
            InitializeComponent();
        }

        private void ZakonczBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PodsumowanieRejestracji());
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
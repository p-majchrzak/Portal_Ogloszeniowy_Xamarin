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
    public partial class PodsumowanieRejestracji : ContentPage
    {
        public PodsumowanieRejestracji()
        {
            InitializeComponent();
        }

        private void Powrot_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StronaWyboruRejestracjiLubLogowania());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPracodawca : ContentPage
    {
        public ProfilPracodawca()
        {
            InitializeComponent();
            zdjecie.Source = App.GlobalnaFirma.Zdjecie;
            nazwaFirmy.Text = App.GlobalnaFirma.Nazwa;
            adresFirmy.Text = App.GlobalnaFirma.Adres;
            emailFirmy.Text = App.GlobalnaFirma.Email;
        }
    }
}
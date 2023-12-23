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
    public partial class EkranLadowania : ContentPage
    {
        public EkranLadowania()
        {
            InitializeComponent();
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PushAsync(new StronaWyboruRejestracjiLubLogowania());
                });
                return false;
            }) ;
        }
    }
}
using Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracodawca
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPracodawcaFlyout : ContentPage
    {
        public ListView ListView;

        public MenuPracodawcaFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuPracodawcaFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuPracodawcaFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuPracodawcaFlyoutMenuItem> MenuItems { get; set; }

            public MenuPracodawcaFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuPracodawcaFlyoutMenuItem>(new[]
                {
                    new MenuPracodawcaFlyoutMenuItem { Id = 0, Title = "Zgłoszenia", TargetType=typeof(StronaGlownaPracodawca) },
                    new MenuPracodawcaFlyoutMenuItem { Id = 1, Title = "Dodaj ogłoszenie",TargetType=typeof(DodajOgloszenie) },
                    new MenuPracodawcaFlyoutMenuItem { Id = 2, Title = "Zarządzaj ogłoszeniami",TargetType=typeof(ZarzadzajOgloszeniami) },
                    new MenuPracodawcaFlyoutMenuItem { Id = 3, Title = "Wyświetl mój profil",TargetType=typeof(ProfilPracodawca) },
                    new MenuPracodawcaFlyoutMenuItem { Id = 4, Title = "Zarządzaj kontem",TargetType=typeof(ZarzadzajKontemPracodawca) },
                    new MenuPracodawcaFlyoutMenuItem { Id = 5, Title = "Wyloguj",TargetType=typeof(StronaWyboruRejestracjiLubLogowania) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
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
namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPracownikFlyout : ContentPage
    {
        public ListView ListView;

        public MenuPracownikFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuPracownikFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuPracownikFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuPracownikFlyoutMenuItem> MenuItems { get; set; }

            public MenuPracownikFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuPracownikFlyoutMenuItem>(new[]
                {
                    new MenuPracownikFlyoutMenuItem { Id = 0, Title = "Strona główna", TargetType=typeof(StronaGlownaPracownik)},
                    new MenuPracownikFlyoutMenuItem { Id = 1, Title = "Wyświetl mój profil",TargetType = typeof(WyswietlMojProfil) },
                    new MenuPracownikFlyoutMenuItem { Id = 2, Title = "Zarządzanie kontem",TargetType = typeof(ZarzadzanieKontem) },
                    new MenuPracownikFlyoutMenuItem { Id = 3, Title = "Moje zgłoszenia",TargetType = typeof(MojeZgloszenia) },
                    new MenuPracownikFlyoutMenuItem { Id = 4, Title = "Zapisane oferty",TargetType = typeof(ZapisaneOferty) },
                    new MenuPracownikFlyoutMenuItem { Id = 5, Title = "Newsletter",TargetType = typeof(StronaNewsletter) },
                    new MenuPracownikFlyoutMenuItem { Id = 6, Title = "Wyloguj",TargetType= typeof(StronaWyboruRejestracjiLubLogowania) },
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
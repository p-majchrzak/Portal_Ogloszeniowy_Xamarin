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

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Administracja
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuAdminFlyout : ContentPage
    {
        public ListView ListView;

        public MenuAdminFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuAdminFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuAdminFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuAdminFlyoutMenuItem> MenuItems { get; set; }

            public MenuAdminFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuAdminFlyoutMenuItem>(new[]
                {
                    new MenuAdminFlyoutMenuItem { Id = 0, Title = "Aktywuj konta pracodawca",TargetType=typeof(AktywujKontaPracodawca) },
                    new MenuAdminFlyoutMenuItem { Id = 1, Title = "Aktywuj konta pracownik",TargetType=typeof(AktywujKontaPracownik) },
                    new MenuAdminFlyoutMenuItem { Id = 2, Title = "Dodaj administratora",TargetType=typeof(DodajAdministratora) },
                    new MenuAdminFlyoutMenuItem { Id = 3, Title = "Zarządzaj administratorami",TargetType=typeof(ZarzadzajAdministratorami) },
                    new MenuAdminFlyoutMenuItem { Id = 4, Title = "Dodaj kategorie",TargetType=typeof(DodajKategorie) },
                    new MenuAdminFlyoutMenuItem { Id = 5, Title = "Zarządzaj kategoriami",TargetType=typeof(ZarzadzajKategoriami) },
                    new MenuAdminFlyoutMenuItem { Id = 6, Title = "Wyloguj",TargetType=typeof(StronaWyboruRejestracjiLubLogowania) },
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
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
    public partial class PolitykaPrywatnosci : ContentPage
    {
        public PolitykaPrywatnosci()
        {
            InitializeComponent();
            var politykaLayout = new StackLayout();

            var politykaLabel = new Label
            {
                Text = "Polityka prywatności",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            politykaLayout.Children.Add(politykaLabel);

            var politykaText = new Label
            {
                Text = "Portal ogłoszeniowy \"Poszukujemy\" dba o ochronę prywatności swoich użytkowników. Niniejsza Polityka Prywatności określa zasady gromadzenia, przetwarzania " +
                       "i wykorzystywania danych osobowych użytkowników przez Portal.\n\n" +
                       "1. Dane osobowe\nDane osobowe to informacje o zidentyfikowanej lub możliwej do zidentyfikowania osobie fizycznej. Portal może gromadzić następujące dane osobowe użytkowników:\n" +
                       "- imię i nazwisko\n- adres e-mail\n- numer telefonu\n- dane dotyczące ogłoszeń, w tym treść ogłoszenia, dane kontaktowe, lokalizacja\n\n" +
                       "2. Gromadzenie danych osobowych\nPortal gromadzi dane osobowe użytkowników w następujących celach:\n" +
                       "- rejestracja i obsługa konta użytkownika\n- publikowanie i zarządzanie ogłoszeniami\n- kontakt z użytkownikami\n- ulepszanie usług Portalu\n- analiza statystyk\n\n" +
                       "3. Przetwarzanie danych osobowych\nPortal przetwarza dane osobowe użytkowników w sposób zgodny z obowiązującym prawem, w tym z Rozporządzeniem Parlamentu Europejskiego i Rady (UE) 2016/679 " +
                       "z dnia 27 kwietnia 2016 r. w sprawie ochrony osób fizycznych w związku z przetwarzaniem danych osobowych i w sprawie swobodnego przepływu takich danych " +
                       "oraz uchylenia dyrektywy 95/46/WE (ogólne rozporządzenie o ochronie danych).\n\n" +
                       "4. Udostępnianie danych osobowych\nPortal może udostępniać dane osobowe użytkowników następującym podmiotom:\n" +
                       "- podmiotom świadczącym usługi na rzecz Portalu, takim jak dostawcy hostingu, dostawcy usług analitycznych, dostawcy usług marketingowych\n" +
                       "- podmiotom uprawnionym do uzyskania danych osobowych na podstawie przepisów prawa, w tym organom państwowym\n\n" +
                       "5. Prawa użytkownika\n- Użytkownik ma prawo do:\n" +
                       "-- dostępu do swoich danych osobowych\n-- sprostowania swoich danych osobowych\n-- usunięcia swoich danych osobowych\n" +
                       "-- ograniczenia przetwarzania swoich danych osobowych\n-- przenoszenia swoich danych osobowych\n-- wniesienia sprzeciwu wobec przetwarzania swoich danych osobowych\n\n" +
                       "6. Bezpieczeństwo danych osobowych\nPortal stosuje odpowiednie środki techniczne i organizacyjne w celu ochrony danych osobowych użytkowników przed nieuprawnionym dostępem, wykorzystaniem czy ujawnieniem.\n\n" +
                       "7. Zmiany Polityki Prywatności\nPortal zastrzega sobie prawo do zmiany Polityki Prywatności.\n"
            };

            politykaLayout.Children.Add(politykaText);


            var warunkiLayout = new StackLayout();

            var warunkiLabel = new Label
            {
                Text = "Warunki świadczenia usług",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            warunkiLayout.Children.Add(warunkiLabel);
            var warunkiText = new Label
            {
                Text = "1. Postanowienia ogólne\nNiniejsze Warunki świadczenia usług określają zasady korzystania z portalu ogłoszeniowego \"Poszukujemy\".\n\n" +
                       "2. Rejestracja\nKorzystanie z niektórych usług Portalu wymaga rejestracji konta użytkownika. Rejestracja konta użytkownika jest bezpłatna.\n\n" +
                       "3. Publikowanie ogłoszeń\nUżytkownik może publikować ogłoszenia na Portalu. Ogłoszenia muszą być zgodne z obowiązującym prawem i zasadami Portalu.\n\n" +
                       "4. Kontakt z użytkownikami\nPortal może kontaktować się z użytkownikami w celu obsługi konta użytkownika, publikacji ogłoszeń, odpowiedzi na zapytania użytkowników, " +
                       "ulepszania usług Portalu, analizy statystyk.\n\n" +
                       "5. Rozwiązywanie sporów\nWszelkie spory powstałe na tle korzystania z Portalu będą rozstrzygane przez sąd powszechny właściwy dla siedziby Portalu.\n\n" +
                       "6. Zmiany Warunków świadczenia usług\nPortal zastrzega sobie prawo do zmiany Warunków świadczenia usług.\n\n" +
                       "7. Postanowienia końcowe\nNiniejsze Warunki świadczenia usług obowiązują od dnia 2023-11-04."
            };

            warunkiLayout.Children.Add(warunkiText);
            politykaStack.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        politykaLayout,
                        warunkiLayout
                    }
                }
            };
            
        }

        private void PowrotBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
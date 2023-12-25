using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portal_Ogloszeniowy_Xamarin.Widoki.Podstawowe;
using System.Net.Mail;
using System.Net;
using Portal_Ogloszeniowy_Xamarin.Klasy;
using System.Text.RegularExpressions;
using System.IO;

namespace Portal_Ogloszeniowy_Xamarin
{
    public partial class App : Application
    {
        public static PracownikKlasa GlobalnyPracownik = null;
        public static Firma GlobalnaFirma = null;
        public static Administrator GlobalnyAdministrator = null;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EkranLadowania());
            
        }
        private static BazaDanych bazaDanych;
        public static BazaDanych BazaDanych
        {
            get
            {
                if (bazaDanych == null)
                {
                    bazaDanych = new BazaDanych(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"BazaPortalOgloszeniowy.db3"));
                }
                return bazaDanych;
            }
        }
        public static bool WalidacjaTekst(string dane)
        {
            return Regex.IsMatch(dane, "^[a-zA-Z]{1,20}$");
        }
        public static bool WalidacjaDlugosc(string dane, int minimum, int maksimum)
        {
            return dane.Length >= minimum && dane.Length <= maksimum;
        }
        public static bool WalidacjaMail(string dane)
        {
            return Regex.IsMatch(dane, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
        }
        public static bool WalidacjaNumer(string dane)
        {
            return Regex.IsMatch(dane, "^[0-9]{9}$");
        }
        public static void WyslijEmail(string klient, string tytul, string trescwiadomosci)
        {
            try
            {
                string Serwersmtp = "smtp-mail.outlook.com";
                int port = 587;
                string email = "poszukujemy@outlook.com";
                string haslo = "Haslodokonta12";
                string adres = "poszukujemy@outlook.com";

                MailMessage wiadomosc = new MailMessage();
                wiadomosc.From = new MailAddress(adres);
                wiadomosc.To.Add(new MailAddress(klient));
                wiadomosc.Subject = tytul;
                wiadomosc.Body = trescwiadomosci;

                SmtpClient polonczenie = new SmtpClient(Serwersmtp, port);
                polonczenie.EnableSsl = true;
                polonczenie.UseDefaultCredentials = false;
                polonczenie.Credentials = new NetworkCredential(email, haslo);

                polonczenie.Send(wiadomosc);

            }
            catch
            {
                
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

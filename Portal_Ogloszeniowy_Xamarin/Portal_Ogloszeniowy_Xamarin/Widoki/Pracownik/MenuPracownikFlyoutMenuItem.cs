using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_Ogloszeniowy_Xamarin.Widoki.Pracownik
{
    public class MenuPracownikFlyoutMenuItem
    {
        public MenuPracownikFlyoutMenuItem()
        {
            TargetType = typeof(MenuPracownikFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
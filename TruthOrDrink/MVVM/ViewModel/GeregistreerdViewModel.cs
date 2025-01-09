using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class GeregistreerdViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand Geregistreerd { get; set; }

        public GeregistreerdViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Geregistreerd = new Command(async () =>
            {
                await Navigation.PushModalAsync(new MainPage());
            });
        }
    }
}

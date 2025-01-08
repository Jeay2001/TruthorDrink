using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using PropertyChanged;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.Repositories;

namespace TruthOrDrink.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class InstructieViewModel
    {
        private string statusMessage;
        public ICommand GotItCommand { get; set; }

        public InstructieViewModel()
        {

            GotItCommand = new Command(async () =>
            {
                UserSessionRepository userSessionRepository = new UserSessionRepository();
                if (userSessionRepository.IsUserLoggedIn())
                {
                    int userId = userSessionRepository.GetLoggedInUserId();
                    UserSession.Instance.SetUser(userId);
                    await Shell.Current.Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    await Shell.Current.Navigation.PushModalAsync(new LoginPage());
                }
            });
        }
    }
}

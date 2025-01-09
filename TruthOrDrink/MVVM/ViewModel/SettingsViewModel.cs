using PropertyChanged;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class SettingsViewModel : BindableObject
    {
        public List<User> User { get; set; }
        private string _name;
        private string _email;
        private readonly INavigation _navigation;
        private readonly MainPageViewModel _mainPageViewModel;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand ReturnCommand { get; }

        public SettingsViewModel(INavigation navigation, MainPageViewModel mainPageViewModel)
        {
            _navigation = navigation;
            _mainPageViewModel = mainPageViewModel; // Save reference to MainPageViewModel
            LoadUserDetails();

            SaveCommand = new Command(async () => await SaveUserDetails());
            ReturnCommand = new Command(async () => await Return());
        }

        private async void LoadUserDetails()
        {
            var email = await SecureStorage.GetAsync("email");
            var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                Name = user.Name;
                Email = user.Email;
            }
        }

        private async Task SaveUserDetails()
        {
            var existingUser = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == Email && u.Email != SecureStorage.GetAsync("email").Result);

            if (existingUser != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The email is already registered to another user.", "OK");
                return;
            }

            var currentUser = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == SecureStorage.GetAsync("email").Result);
            if (currentUser != null)
            {
                currentUser.Name = Name;
                currentUser.Email = Email;
                App.UserRepo?.SaveEntity(currentUser);

                await SecureStorage.SetAsync("email", Email);
                await Application.Current.MainPage.DisplayAlert("Success", "Details updated successfully", "OK");
            }
        }

        private async Task Return()
        {
            await _navigation.PopModalAsync();
        }
    }
}

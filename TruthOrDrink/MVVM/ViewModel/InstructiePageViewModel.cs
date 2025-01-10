using System;
using System.Linq;
using System.Windows.Input;
using TruthOrDrink.MVVM.Models;
using Microsoft.Maui.Storage;
using PropertyChanged;

namespace TruthOrDrink.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class InstructiepageViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand CheckLoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public InstructiepageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            CheckLoginCommand = new Command(async () =>
            {
                var storedEmail = await SecureStorage.GetAsync("email");
                var storedPassword = await SecureStorage.GetAsync("password");

                if (!string.IsNullOrEmpty(storedEmail) && !string.IsNullOrEmpty(storedPassword))
                {
                    var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == storedEmail && u.Password == storedPassword);

                    if (user != null)
                    {
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
                        await Navigation.PushModalAsync(new LoginPage());
                    }
                }
                else
                {
                    //await Application.Current.MainPage.DisplayAlert("Error", "No stored credentials found", "OK");
                    await Navigation.PushModalAsync(new LoginPage());
                }
            });

            LogoutCommand = new Command(async () =>
            {
                SecureStorage.Default.RemoveAll();

                await Application.Current.MainPage.DisplayAlert("Success", "Logged out successfully", "OK");
                await Navigation.PushModalAsync(new LoginPage());
            });
        }
    }
}

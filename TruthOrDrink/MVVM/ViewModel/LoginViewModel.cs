using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.MVVM.ViewModel
{
    class LoginViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand LoginUser { get; set; }
        public ICommand ReturnCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;

            LoginUser = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
                    return;
                }

                var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == Email);
                if (user == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid email", "Try Again");
                    return;
                }

                if (!user.Password.Equals(Password, StringComparison.Ordinal))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid password", "Try Again");
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("Success", "You are logged in!", "OK");

                SaveLoginDetails(Email, Password);

                await Navigation.PushModalAsync(new MainPage());
            });

            ReturnCommand = new Command(async () =>
            {
                await Navigation.PushModalAsync(new MainPage());
            });

            RegisterCommand = new Command(async () =>
            {
                await Navigation.PushModalAsync(new RegisterPage());
            });
        }

        private void SaveLoginDetails(string email, string password)
        {
            try
            {
                SecureStorage.SetAsync("email", email);
                SecureStorage.SetAsync("password", password);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"Error storing credentials: {ex.Message}", "OK");
            }
        }

        public void LoadLoginDetails()
        {
            try
            {
                var storedEmail = SecureStorage.GetAsync("email").Result;
                var storedPassword = SecureStorage.GetAsync("password").Result;

                if (!string.IsNullOrEmpty(storedEmail) && !string.IsNullOrEmpty(storedPassword))
                {
                    Email = storedEmail;
                    Password = storedPassword;

                    var user = App.UserRepo.GetEntities().FirstOrDefault(u => u.Email == storedEmail && u.Password == storedPassword);
                    if (user != null)
                    {
                        Navigation.PushModalAsync(new MainPage());
                    }
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"Error loading credentials: {ex.Message}", "OK");
            }
        }
    }
}

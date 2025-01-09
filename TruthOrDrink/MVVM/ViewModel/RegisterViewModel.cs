using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class RegisterViewModel
    {
        public INavigation Navigation { get; set; }

        public ICommand RegisterUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterViewModel(INavigation navigation)
        {
            Navigation = navigation;


            RegisterUser = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "OK");
                    return;
                }

                if (Password != ConfirmPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                    return;
                }

                var existingUser = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == Email);
                if (existingUser != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email is already registered", "OK");
                    return;
                }

                var newUser = new User
                {
                    Name = Name,
                    Email = Email,
                    Password = Password // Consider hashing the password before saving
                };

                App.UserRepo?.SaveEntity(newUser);
                await SaveLoginDetails(Email, Password);

                await Application.Current.MainPage.DisplayAlert("Success", "Registration successful", "OK");

                await Navigation.PushModalAsync(new GeregistreerdPage());
            });

        }
        private async Task SaveLoginDetails(string email, string password)
        {
            try
            {
                // Store email and password securely
                await SecureStorage.SetAsync("email", email);
                await SecureStorage.SetAsync("password", password);  // Note: For extra security, don't store raw passwords. Consider hashing them.
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., SecureStorage might fail if the device doesn't support it)
                await Application.Current.MainPage.DisplayAlert("Error", $"Error storing credentials: {ex.Message}", "OK");
            }
        }
    }
}

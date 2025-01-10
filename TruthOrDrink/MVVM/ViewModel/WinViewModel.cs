using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class WinViewModel : INotifyPropertyChanged
    {
        public string WinnerName { get; set; }
        public int Score { get; set; }
        public ICommand BackToDifficultyCommand { get; }

        public WinViewModel(int score)
        {
            LoadUserName();
            Score = score;
            BackToDifficultyCommand = new Command(BackToDifficulty);
        }

        private void LoadUserName()
        {
            try
            {
                var email = SecureStorage.GetAsync("email").Result;
                var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
                WinnerName = user != null ? user.Name : "Player";
            }
            catch (Exception ex)
            {
                WinnerName = "Player";
                Application.Current.MainPage.DisplayAlert("Error", $"Error loading user: {ex.Message}", "OK");
            }
        }

        private async void BackToDifficulty()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new DifficultyPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

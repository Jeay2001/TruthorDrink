using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using TruthOrDrink.Enum;
using System.Windows.Input;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class DifficultyPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryEnum> Categories { get; set; }
        private CategoryEnum selectedCategory;
        private int selectedDifficulty = 1; // Default to 1
        private string playerName;

        public CategoryEnum SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public int SelectedDifficulty
        {
            get => selectedDifficulty;
            set
            {
                selectedDifficulty = value;
                OnPropertyChanged();
            }
        }

        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartGameCommand { get; }

        public DifficultyPageViewModel()
        {
            Categories = new ObservableCollection<CategoryEnum>(System.Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>());
            LoadUserName();
            StartGameCommand = new Command(StartGame);
        }

        private void LoadUserName()
        {
            try
            {
                var email = SecureStorage.GetAsync("email").Result;
                var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
                PlayerName = user != null ? user.Name : "Player";
            }
            catch (Exception ex)
            {
                PlayerName = "Player";
                Application.Current.MainPage.DisplayAlert("Error", $"Error loading user: {ex.Message}", "OK");
            }
        }

        private async void StartGame()
        {
            if (SelectedCategory == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please select a category.", "OK");
                return;
            }

            // Navigate to the GamePage and pass the selected category and difficulty
            await App.Current.MainPage.Navigation.PushModalAsync(new GamePage(SelectedCategory, (DifficultyEnum)SelectedDifficulty));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

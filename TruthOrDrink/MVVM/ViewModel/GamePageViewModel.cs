using System.Collections.ObjectModel;
using System.Windows.Input;
using TruthOrDrink.Enum;
using TruthOrDrink.MVVM.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TruthOrDrink.MVVM.View;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        private int currentQuestionIndex;
        private ObservableCollection<Question> questions;
        private int score;
        private const int WinningScore = 10; // Set the winning score
        private bool isAnsweringEnabled = true;

        public string PlayerName { get; set; }
        public Question CurrentQuestion { get; set; }
        public ICommand AnswerQuestionCommand { get; }
        public ICommand TakeShotCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public INavigation Navigation { get; set; }

        public bool IsAnsweringEnabled
        {
            get => isAnsweringEnabled;
            set
            {
                isAnsweringEnabled = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged();
                CheckForWin();
            }
        }

        public GamePageViewModel(CategoryEnum selectedCategory, DifficultyEnum selectedDifficulty)
        {
            LoadUserName();
            questions = new ObservableCollection<Question>(DataInitializer.InitializeQuestions(selectedCategory, selectedDifficulty));
            currentQuestionIndex = 0;
            CurrentQuestion = questions[currentQuestionIndex];
            AnswerQuestionCommand = new Command(AnswerQuestion, () => IsAnsweringEnabled);
            TakeShotCommand = new Command(TakeShot);
            NextQuestionCommand = new Command(NextQuestion);
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

        private async void AnswerQuestion()
        {
            IsAnsweringEnabled = false;
            Score++;
            if (Navigation != null)
            {
                await Navigation.PushModalAsync(new NextRoundPage());
            }
        }

        private async void TakeShot()
        {
            if (Navigation != null)
            {
                await Navigation.PushModalAsync(new NextRoundPage());
            }
        }

        private async void CheckForWin()
        {
            if (Score >= WinningScore)
            {
                // Navigate to WinPage
                await Navigation.PushModalAsync(new WinPage(Score));
            }
        }

        public void NextQuestion()
        {
            currentQuestionIndex = (currentQuestionIndex + 1) % questions.Count;
            CurrentQuestion = questions[currentQuestionIndex];
            OnPropertyChanged(nameof(CurrentQuestion));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

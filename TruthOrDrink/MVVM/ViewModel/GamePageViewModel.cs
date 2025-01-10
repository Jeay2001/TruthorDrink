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

        public Question CurrentQuestion { get; set; }
        public ICommand AnswerQuestionCommand { get; }
        public ICommand TakeShotCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public INavigation Navigation { get; set; }

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
            questions = new ObservableCollection<Question>(DataInitializer.InitializeQuestions(selectedCategory, selectedDifficulty));
            currentQuestionIndex = 0;
            CurrentQuestion = questions[currentQuestionIndex];
            AnswerQuestionCommand = new Command(AnswerQuestion);
            TakeShotCommand = new Command(TakeShot);
            NextQuestionCommand = new Command(NextQuestion);
        }

        private async void AnswerQuestion()
        {
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
                await Navigation.PushModalAsync(new WinPage("Player", Score));
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

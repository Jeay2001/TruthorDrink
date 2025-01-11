using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.MVVM.View;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class ManageQuestionViewModel : BindableObject
    {
        private ObservableCollection<Question> _userQuestions;
        private List<Question> Questions { get; set; }
        private Question _selectedQuestion;
        private readonly INavigation _navigation;

        public ObservableCollection<Question> UserQuestions
        {
            get => _userQuestions;
            set
            {
                _userQuestions = value;
                OnPropertyChanged();
            }
        }

        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveQuestionCommand { get; }
        public ICommand DeleteQuestionCommand { get; }
        public ICommand ReturnCommand { get; }

        public ManageQuestionViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoadUserQuestions();

            ReturnCommand = new Command(async () =>
            {
                await navigation.PushModalAsync(new VragenlijstPage());
            });

            SaveQuestionCommand = new Command(async () => await SaveQuestion());
            DeleteQuestionCommand = new Command<Question>(async (question) => await DeleteQuestion(question));
        }

        private void LoadUserQuestions()
        {
            var email = SecureStorage.GetAsync("email").Result;
            var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                UserQuestions = new ObservableCollection<Question>(App.QuestionRepo?.GetEntities().Where(q => q.UserId == user.Id));
            }
        }

        private async Task SaveQuestion()
        {
            if (SelectedQuestion != null)
            {
                App.QuestionRepo?.SaveEntity(SelectedQuestion);
                await Application.Current.MainPage.DisplayAlert("Success", "Question updated successfully", "OK");
                LoadUserQuestions();
            }
        }

        private async Task DeleteQuestion(Question question)
        {
            var confirm = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to delete this question?", "Yes", "No");
            if (confirm)
            {
                App.QuestionRepo?.DeleteEnity(question);
                UserQuestions.Remove(question);
                LoadUserQuestions();
            }
        }

        

    }
}

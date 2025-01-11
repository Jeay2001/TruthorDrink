using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TruthOrDrink.Enum;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class VragenlijstViewModel : BindableObject
    {
        private string _questionText;
        private string _selectedCategory;
        private DifficultyEnum _selectedDifficulty;
        private string _selectedType;
        private readonly INavigation _navigation;

        public string QuestionText
        {
            get => _questionText;
            set
            {
                _questionText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public DifficultyEnum SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged();
            }
        }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<DifficultyEnum> Difficulties { get; set; }
        public ObservableCollection<string> Types { get; set; }
        private ObservableCollection<Question> _userQuestions;

        public ICommand AddQuestionCommand { get; }
        public ICommand ReturnCommand { get; set; }
        public ICommand ManageQuestionPageCommand { get; set; }

        public VragenlijstViewModel(INavigation navigation)
        {
            ReturnCommand = new Command(() =>
            {
                navigation.PushModalAsync(new MainPage());
            });

            ManageQuestionPageCommand = new Command(() =>
            {
                navigation.PushModalAsync(new ManageQuestionPage());
                LoadUserQuestions();
            });
            _navigation = navigation;

            Categories = new ObservableCollection<string>
                {
                    "Party",
                    "Friends",
                    "Family"
                };

            Difficulties = new ObservableCollection<DifficultyEnum>
                {
                    DifficultyEnum.Easy,
                    DifficultyEnum.Medium,
                    DifficultyEnum.Hard,
                    DifficultyEnum.VeryHard,
                    DifficultyEnum.Extreme
                };

            Types = new ObservableCollection<string>
                {
                    "Truth",
                    "Dare"
                };


            AddQuestionCommand = new Command(async () => await AddQuestion());
        }
        public ObservableCollection<Question> UserQuestions
        {
            get => _userQuestions;
            set
            {
                _userQuestions = value;
                OnPropertyChanged();
            }
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

        private async Task AddQuestion()
        {
            // Validate that the question text is not empty
            if (string.IsNullOrWhiteSpace(QuestionText))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Question text cannot be empty", "OK");
                return;
            }

            // Implement the logic to add the question to the database
            var email = SecureStorage.GetAsync("email").Result;
            var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
            if (user != null && System.Enum.TryParse(SelectedCategory, out CategoryEnum categoryEnum))
            {
                var category = App.CategoryRepo?.GetEntities().FirstOrDefault(c => c.Name == categoryEnum);
                if (category != null)
                {
                    var newQuestion = new Question
                    {
                        QuestionText = QuestionText,
                        Type = SelectedType,
                        Difficulty = SelectedDifficulty,
                        UserId = user.Id,
                        CategoryId = category.Id
                    };

                    App.QuestionRepo?.SaveEntity(newQuestion);







                    await Application.Current.MainPage.DisplayAlert("Success", "Question added successfully", "OK");
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Category not found", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Diificulty or Category not found", "OK");
            }
        }
    }
}

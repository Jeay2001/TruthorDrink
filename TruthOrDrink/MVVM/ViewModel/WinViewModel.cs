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

        public WinViewModel(string winnerName, int score)
        {
            WinnerName = winnerName;
            Score = score;
            BackToDifficultyCommand = new Command(BackToDifficulty);
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

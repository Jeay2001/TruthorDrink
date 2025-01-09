using System.Threading.Tasks;
using System.Windows.Input;
using TruthOrDrink.Abstractions;
using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class NextRoundViewModel : INotifyPropertyChanged
    {
        private string memeUrl;

        public string MemeUrl
        {
            get => memeUrl;
            set
            {
                memeUrl = value;
                OnPropertyChanged();
            }
        }

        public ICommand FetchMemeCommand { get; }

        //public NextRoundViewModel()
        //{
        //    FetchMemeCommand = new Command(FetchMemeCommand_Executed);
        //}

        //private void FetchMemeCommand_Executed()
        //{
        //    // This will be handled in the code-behind
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

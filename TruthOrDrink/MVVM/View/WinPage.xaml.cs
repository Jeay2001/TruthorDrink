using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink.MVVM.View;

public partial class WinPage : ContentPage
{
    public WinPage(string winnerName, int score)
    {
        InitializeComponent();
        BindingContext = new WinViewModel(winnerName, score);
    }
}

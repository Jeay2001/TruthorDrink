using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink.MVVM.View;

public partial class WinPage : ContentPage
{
    public WinPage(int score)
    {
        InitializeComponent();
        BindingContext = new WinViewModel(score);
    }
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }
}

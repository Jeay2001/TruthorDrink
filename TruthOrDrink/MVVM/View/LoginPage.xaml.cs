using TruthOrDrink.MVVM.Models;
using Microsoft.Maui.Storage;
using TruthOrDrink.MVVM.ViewModel;


namespace TruthOrDrink;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }

    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }
}

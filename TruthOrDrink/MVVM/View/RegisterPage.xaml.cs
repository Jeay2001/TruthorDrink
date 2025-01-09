using TruthOrDrink.MVVM.Models;
using Microsoft.Maui.Storage;
using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }

    
}

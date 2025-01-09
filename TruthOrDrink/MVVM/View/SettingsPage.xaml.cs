using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        BindingContext = new SettingsViewModel(Navigation, mainPageViewModel);
    }
}

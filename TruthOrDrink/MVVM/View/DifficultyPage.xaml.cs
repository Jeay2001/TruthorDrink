using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class DifficultyPage : ContentPage
{
    public DifficultyPage()
    {
        InitializeComponent();
        BindingContext = new DifficultyPageViewModel();
    }

    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private void Begin_Clicked(object sender, EventArgs e)
    {
        // Logic to start the game
        var viewModel = BindingContext as DifficultyPageViewModel;
        viewModel?.StartGameCommand.Execute(null);
    }
}

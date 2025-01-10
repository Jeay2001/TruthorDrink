
using TruthOrDrink.Enum;
using TruthOrDrink.MVVM.View;
using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class GamePage : ContentPage
{
    public GamePage(CategoryEnum selectedCategory, DifficultyEnum selectedDifficulty)
    {
        InitializeComponent();
        var viewModel = new GamePageViewModel(selectedCategory, selectedDifficulty);
        viewModel.Navigation = this.Navigation;
        BindingContext = viewModel;
    }
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NextRoundPage());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NextRoundPage());
    }
}
namespace TruthOrDrink;

public partial class DifficultyPage : ContentPage
{
	public DifficultyPage()
	{
		InitializeComponent();
	}
    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
    private async void Begin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new GamePage());
    }
}
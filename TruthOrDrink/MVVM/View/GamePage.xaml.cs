
namespace TruthOrDrink;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
    }
}
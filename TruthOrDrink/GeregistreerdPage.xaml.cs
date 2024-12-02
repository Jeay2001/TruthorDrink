namespace TruthOrDrink;

public partial class GeregistreerdPage : ContentPage
{
	public GeregistreerdPage()
	{
		InitializeComponent();
	}

    private async void Homepage_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new MainPage());
    }
}
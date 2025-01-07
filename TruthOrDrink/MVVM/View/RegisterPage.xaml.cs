namespace TruthOrDrink;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void Return_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new LoginPage());
    }

    private async void Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new GeregistreerdPage());
    }
}
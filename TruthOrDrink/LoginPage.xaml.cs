namespace TruthOrDrink;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }

}
using TruthOrDrink.MVVM.Models;
using Microsoft.Maui.Storage;


namespace TruthOrDrink;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }

    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new MainPage());
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        User? user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
        if (user != null && user.Password == password)
        {
            // Successful login
            await DisplayAlert("Success", "You are logged in!", "OK");

            // Navigate to the main page or the next page after login
            await Navigation.PushModalAsync(new MainPage());
        }
        else
        {
            // Invalid login
            await DisplayAlert("Error", "Invalid email or password", "Try Again");
        }

    }
    private async void Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
}
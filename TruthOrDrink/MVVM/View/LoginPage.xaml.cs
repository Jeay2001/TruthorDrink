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
            await SaveLoginDetails(email, password);
            await Navigation.PushModalAsync(new MainPage());
        }
        else
        {
            // Invalid login
            await DisplayAlert("Error", "Invalid email or password", "Try Again");
        }

    }
    

        // Store login details securely in SecureStorage
        private async Task SaveLoginDetails(string email, string password)
        {
            try
            {
                // Store email and password securely
                await SecureStorage.SetAsync("email", email);
                await SecureStorage.SetAsync("password", password);  // Note: For extra security, don't store raw passwords. Consider hashing them.
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., SecureStorage might fail if the device doesn't support it)
                await DisplayAlert("Error", $"Error storing credentials: {ex.Message}", "OK");
            }
        }


private async void Register_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Load login details when the page appears
        await LoadLoginDetails();
    }
    private async Task LoadLoginDetails()
    {
        try
        {
            var storedEmail = await SecureStorage.GetAsync("email");
            var storedPassword = await SecureStorage.GetAsync("password");

            if (!string.IsNullOrEmpty(storedEmail) && !string.IsNullOrEmpty(storedPassword))
            {
                // Auto-login user
                EmailEntry.Text = storedEmail;
                PasswordEntry.Text = storedPassword;

                // You can also directly log the user in here by validating the credentials against the database
                var user = App.UserRepo.GetEntities().FirstOrDefault(u => u.Email == storedEmail && u.Password == storedPassword);
                if (user != null)
                {
                    // Navigate to the main page if the user exists
                    await Navigation.PushModalAsync(new MainPage());
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., SecureStorage might fail)
            await DisplayAlert("Error", $"Error loading credentials: {ex.Message}", "OK");
        }
    }
}
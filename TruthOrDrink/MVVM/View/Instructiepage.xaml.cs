namespace TruthOrDrink;

public partial class Instructiepage : ContentPage
{
    public Instructiepage()
    {
        InitializeComponent();
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Check if credentials are stored in SecureStorage
        var storedEmail = await SecureStorage.GetAsync("email");
        var storedPassword = await SecureStorage.GetAsync("password");

        // If credentials exist in SecureStorage, navigate to the main page
        if (!string.IsNullOrEmpty(storedEmail) && !string.IsNullOrEmpty(storedPassword))
        {
            // Optionally: Validate credentials against the database if needed
            var user = App.UserRepo.GetEntities().FirstOrDefault(u => u.Email == storedEmail && u.Password == storedPassword);
            if (user != null)
            {
                // If user exists, navigate to the main page
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                // If user is not valid, send them to login
                await Navigation.PushModalAsync(new LoginPage());
            }
        }
        else
        {
            // If no credentials are stored, navigate to the login page
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}

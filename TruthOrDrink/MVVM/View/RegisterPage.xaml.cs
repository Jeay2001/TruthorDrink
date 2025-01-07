using TruthOrDrink.MVVM.Models;
using Microsoft.Maui.Storage;

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

    private bool IsPasswordValid(string password)
    {
        // Minimum 8 characters
        if (password.Length < 8)
        {
            DisplayAlert("Error", "Password must be at least 8 characters long.", "OK");
            return false;
        }

        // Must contain at least one uppercase letter
        if (!password.Any(char.IsUpper))
        {
            DisplayAlert("Error", "Password must contain at least one uppercase letter.", "OK");
            return false;
        }

        // Must contain at least one number
        if (!password.Any(char.IsDigit))
        {
            DisplayAlert("Error", "Password must contain at least one number.", "OK");
            return false;
        }

        // Must contain at least one special character
        if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            DisplayAlert("Error", "Password must contain at least one special character.", "OK");
            return false;
        }

        return true;
    }
    private async void Register_Clicked(object sender, EventArgs e)
    {

        // Get input values
        string email = EmailEntry.Text?.ToLower();  // Convert email to lowercase
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        // Validate input
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            await DisplayAlert("Error", "All fields are required", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }

        // Validate the password
        if (!IsPasswordValid(password))
        {
            return; // Prevent registration if password is not valid
        }

        // Create the new user
        var newUser = new User
        {
            Name = email, // You can store the email as the name or add a separate Name field if needed
            Email = email,
            Password = password,
            QrCode = "",  // You can leave this empty for now, or generate a QR code if needed
            FriendId = 0  // Default to 0 for now, can be updated later
        };

        // Save the new user to the database
        try
        {
            App.UserRepo.SaveEntity(newUser);
            await DisplayAlert("Success", "User registered successfully", "OK");

            // Optionally navigate to the login page or other page
            // Save login details after successful registration
            await SaveLoginDetails(email, password);
            await Navigation.PushModalAsync(new LoginPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
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
}
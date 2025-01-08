using TruthOrDrink.MVVM.Models;
using TruthOrDrink.Repositories;

namespace TruthOrDrink;

public partial class Instructiepage : ContentPage
{
    public Instructiepage()
    {
        InitializeComponent();
        

    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Initialize UserSessionRepository to check if the user is logged in
            UserSessionRepository userSessionRepository = new UserSessionRepository();

            System.Diagnostics.Debug.WriteLine("UserSessionRepository initialized.");

            // Check if the user is logged in
            if (userSessionRepository.IsUserLoggedIn())
            {
                System.Diagnostics.Debug.WriteLine("User is already logged in.");

                // Get the logged-in user ID
                int userId = userSessionRepository.GetLoggedInUserId();

                System.Diagnostics.Debug.WriteLine($"Retrieved logged-in userId: {userId}");

                // Log the user in using UserSession
                try
                {
                    UserSession.Instance.SetUser(userId);
                    System.Diagnostics.Debug.WriteLine($"User with ID {userId} successfully logged in.");
                }
                catch (InvalidOperationException ex)
                {
                    // This exception is thrown if the user is not found
                    System.Diagnostics.Debug.WriteLine($"Error in SetUser: {ex.Message}");
                    // Optionally, show an alert to the user or handle the error gracefully
                    return;
                }

                // Navigate to the main page
                await Navigation.PushModalAsync(new MainPage());
                System.Diagnostics.Debug.WriteLine("Navigation to MainPage initiated.");
            }
            else
            {
                // If the user is not logged in, navigate to the login page
                System.Diagnostics.Debug.WriteLine("User is not logged in, navigating to LoginPage.");
                
                await Navigation.PushModalAsync(new LoginPage());
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the entire process
            System.Diagnostics.Debug.WriteLine($"Error during login process: {ex.Message}");
            // Optionally, show an alert to the user or take other actions
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}

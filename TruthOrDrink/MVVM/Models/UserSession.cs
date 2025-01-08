using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Repositories;

namespace TruthOrDrink.MVVM.Models
{
    [Table("UserSession")]
    public class UserSession
    {
        private static UserSession? _instance;
        [Ignore]
        public static UserSession Instance => _instance ??= new UserSession();
        public int UserId { get; set; }
        public bool IsLoggedIn { get; set; }
        [Ignore]
        public User? LoggedInUser { get; set; }
        [Ignore]
        public string? AuthToken { get; private set; }

        public UserSession() { }

        public void Initialize()
        {
            try
            {
                int loggedInUserId = GetLoggedInUserId();
                System.Diagnostics.Debug.WriteLine($"Initialize: loggedInUserId = {loggedInUserId}");

                if (loggedInUserId != 0)
                {
                    SetUser(loggedInUserId);
                }
                //else
                //{
                //    ClearUser(); // Ensure no lingering session exists.
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during UserSession initialization: {ex.Message}");
            }
        }

        public void SetUser(int userId)
        {
            System.Diagnostics.Debug.WriteLine($"SetUser userId: {userId}");

            // Clear the previous user session first
            ClearUser();

            UserId = userId;
            IsLoggedIn = true;

            // Assuming BaseRepository is a generic repository to interact with your entities
            BaseRepository<User> userRepository = new BaseRepository<User>();

            // Fetch the user from the database using the userId
            LoggedInUser = userRepository.GetEntities().FirstOrDefault(u => u.Id == userId);

            // Debugging to check the fetched user
            System.Diagnostics.Debug.WriteLine("Test 8");

            // Check if LoggedInUser is null (user not found in the database)
            if (LoggedInUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Initialize UserSessionRepository to manage user session
            UserSessionRepository userSessionRepository = new UserSessionRepository();

            // Check if userSessionRepository is null
            if (userSessionRepository == null)
            {
                throw new InvalidOperationException("User session repository is not initialized.");
            }

            System.Diagnostics.Debug.WriteLine("Test 9");

            // Log the user in by calling LogInUser on the session repository
            userSessionRepository.LogInUser(this);
        }


        public int GetLoggedInUserId()
        {
            UserSessionRepository userSessionRepository = new UserSessionRepository();
            return userSessionRepository.GetLoggedInUserId();
        }
        public void ClearUser()
        {
            System.Diagnostics.Debug.WriteLine("ClearUser start");
            UserId = 0;
            IsLoggedIn = false;
            LoggedInUser = null;

            UserSessionRepository userSessionRepository = new UserSessionRepository();
            userSessionRepository.LogOutUser();
            System.Diagnostics.Debug.WriteLine("ClearUser end");

        }

        //public bool IsLoggedIn => !string.IsNullOrEmpty(AuthToken);
    }
}

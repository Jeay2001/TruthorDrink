using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.Abstractions;

namespace TruthOrDrink.Repositories
{
    public class UserSessionRepository
    {
        public SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public UserSessionRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.Flags);
            connection.CreateTable<UserSession>();
        }

        public void LogInUser(UserSession userSession)
        {
            int result = connection.Insert(userSession);
            statusMessage = string.Format("{0} record(s) added [UserId: {1}] [IsLoggedIn: {2}]", result, userSession.UserId, userSession.IsLoggedIn);
            System.Diagnostics.Debug.WriteLine(statusMessage);
            System.Diagnostics.Debug.WriteLine("Test 10");
            //try
            //{
            //    // Delete all existing session records first
            //    connection.DeleteAll<UserSession>();

            //    // Create a new session record for the logged-in user
            //    var userSession = new UserSession
            //    {
            //        UserId = userId,
            //        IsLoggedIn = true
            //    };
            //    int result = connection.Insert(userSession);
            //    statusMessage = string.Format("{0} record(s) added [UserId: {1}] [IsLoggedIn: {2}]", result, userSession.UserId, userSession.IsLoggedIn);
            //    System.Diagnostics.Debug.WriteLine(statusMessage);
            //}
            //catch (Exception ex)
            //{
            //    statusMessage = $"Error during login: {ex.Message}";
            //    System.Diagnostics.Debug.WriteLine(statusMessage);
            //}
        }


        public void LogOutUser()
        {
            connection.DeleteAll<UserSession>();
            statusMessage = "User logged out. All session records deleted.";
        }

        // Check if a user is logged in
        public bool IsUserLoggedIn()
        {
            var session = connection.Table<UserSession>().FirstOrDefault(s => s.IsLoggedIn);
            return session != null;
        }

        // Get the logged-in user Id
        public int GetLoggedInUserId()
        {
            var session = connection.Table<UserSession>().FirstOrDefault(s => s.IsLoggedIn);
            return session?.UserId ?? 0;
        }
        
    }
}

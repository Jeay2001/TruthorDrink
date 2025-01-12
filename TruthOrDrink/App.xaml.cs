using Microsoft.Maui.Graphics;
using TruthOrDrink.Abstractions;
using TruthOrDrink.Logic;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.Repositories;

namespace TruthOrDrink
{
    public partial class App : Application
    {
        public static BaseRepository<User>? UserRepo { get; private set; }
        public static BaseRepository<Game>? GameRepo { get; private set; }
        public static BaseRepository<Question>? QuestionRepo { get; private set; }
        public static BaseRepository<Category>? CategoryRepo { get; private set; }
        public App(BaseRepository<User> userRepo, BaseRepository<Game> gameRepo, BaseRepository<Question> questionRepo, BaseRepository<Category> categoryRepo)
        {
            InitializeComponent();
            DatabaseInitializer.Initialize();
            DependencyService.Register<IMemeService, MemeService>();

            UserRepo = userRepo;
            GameRepo = gameRepo;
            QuestionRepo = questionRepo;
            CategoryRepo = categoryRepo;
            //// Create a hardcoded user (only done once for testing purposes)
            //User hardcodedUser = new User
            //{
            //    Name = "TestUser",
            //    Email = "test",
            //    Password = "test"
            //};
            //App.UserRepo?.SaveEntity(hardcodedUser);
            // Set the MainPage to Instructiepage directly
            MainPage = new Instructiepage();
        
        }
        protected override async void OnStart()
        {
            base.OnStart();
            await RequestStoragePermission();
        }
        private async Task RequestStoragePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            if (status != PermissionStatus.Granted)
            {
                if (MainPage != null)
                {
                    await MainPage.DisplayAlert("Permission Denied", "Storage permission is required to save the QR code.", "OK");
                }
            }
        }
    }
}

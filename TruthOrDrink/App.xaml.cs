﻿using TruthOrDrink.MVVM.Models;
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

            UserRepo = userRepo;
            GameRepo = gameRepo;
            QuestionRepo = questionRepo;
            CategoryRepo = categoryRepo;

            // Set the MainPage to Instructiepage directly
            MainPage = new Instructiepage();
        }
    }
}

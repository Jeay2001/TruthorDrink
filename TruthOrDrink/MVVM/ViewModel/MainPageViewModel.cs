﻿using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class MainPageViewModel : BindableObject
    {
        private string _welcomeText;
        private readonly INavigation _navigation;

        public string WelcomeText
        {
            get => _welcomeText;
            set
            {
                _welcomeText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SettingsCommand { get; set; }
        public ICommand VriendelijstCommand { get; set; }
        public ICommand VragenlijstCommand { get; set; }
        public ICommand DifficultyCommand { get; set; }

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            LoadUserName();

            SettingsCommand = new Command(() =>
            {
                NavigateToSettings();
            });

            VriendelijstCommand = new Command(() =>
            {
                NavigateToVriendelijst();
            });

            VragenlijstCommand = new Command(() =>
            {
                NavigateToVragenlijst();
            });

            DifficultyCommand = new Command(() =>
            {
                NavigateToDifficulty();
            });
        }

        private void LoadUserName()
        {
            try
            {
                var email = SecureStorage.GetAsync("email").Result;
                var user = App.UserRepo?.GetEntities().FirstOrDefault(u => u.Email == email);
                WelcomeText = user != null ? $"Welkom, {user.Name}!" : "Welkom!";
            }
            catch (Exception ex)
            {
                WelcomeText = "Welkom!";
                Application.Current.MainPage.DisplayAlert("Error", $"Error loading user: {ex.Message}", "OK");
            }
        }

        private void NavigateToSettings()
        {
            _navigation.PushModalAsync(new SettingsPage());
        }

        private void NavigateToVriendelijst()
        {
            _navigation.PushModalAsync(new Vriendelijst());
        }

        private void NavigateToVragenlijst()
        {
            _navigation.PushModalAsync(new VragenlijstPage());
        }

        private void NavigateToDifficulty()
        {
            _navigation.PushModalAsync(new DifficultyPage());
        }
    }
}

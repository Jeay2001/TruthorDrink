using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TruthOrDrink.Abstractions;
using TruthOrDrink.Logic;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink.MVVM.View;


public partial class NextRoundPage : ContentPage
{
    private readonly IMemeService _memeService;

    public NextRoundPage()
    {
        InitializeComponent();
        _memeService = new MemeService();
    }
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }
    private async void NextQuestion_Clicked(object sender, EventArgs e)
    {
        // Navigate back to the GamePage and trigger the next question
        var gamePage = Navigation.NavigationStack.LastOrDefault() as GamePage;
        if (gamePage != null)
        {
            var viewModel = gamePage.BindingContext as GamePageViewModel;
            if (viewModel != null)
            {
                // Directly call NextQuestion instead of executing the command
                viewModel.NextQuestion();
                await Task.Delay(100); // Ensure the next question is set
                                       // Explicitly notify the UI to update
                viewModel.OnPropertyChanged(nameof(viewModel.CurrentQuestion));
            }
        }
        await Navigation.PopModalAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var meme = await _memeService.GetRandomMemeAsync();
            MemeImage.Source = meme.Url;
            MemeName.Text = meme.Name;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message); // Debug statement
            await DisplayAlert("Error", "Fout bij het ophalen van memes: " + ex.Message, "OK");
        }
    }
}


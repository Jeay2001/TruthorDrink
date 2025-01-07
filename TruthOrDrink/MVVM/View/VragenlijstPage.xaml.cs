namespace TruthOrDrink;

public partial class VragenlijstPage : ContentPage
{
    public Slider DifficultySlider { get; set; }
    public Label DifficultyLabel { get; set; }

    public VragenlijstPage()
    {
        InitializeComponent();
    }

    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    private async void Toevoegen_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}

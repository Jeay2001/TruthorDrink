namespace TruthOrDrink;

public partial class Instructiepage : ContentPage
{
    public Instructiepage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}

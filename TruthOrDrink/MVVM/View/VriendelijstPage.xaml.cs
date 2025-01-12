namespace TruthOrDrink;

public partial class Vriendelijst : ContentPage
{
    public Vriendelijst()
    {
        InitializeComponent();
    }
    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
    private async void QRCode_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new QrPage());
    }
    private async void VoegVriendToe_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendenzoeken());
    }
    private async void Verwijder_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendenzoeken());
    }
}

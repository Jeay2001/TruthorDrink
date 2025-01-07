namespace TruthOrDrink;

public partial class Qrcode : ContentPage
{
	public Qrcode()
	{
		InitializeComponent();
	}
    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendelijst());
    }
}
namespace TruthOrDrink;

public partial class Vriendenzoeken : ContentPage
{
	public Vriendenzoeken()
	{
		InitializeComponent();
	}
    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendelijst());
    }

    private async void Zoek_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendengezocht());
    }
}
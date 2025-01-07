namespace TruthOrDrink;

public partial class Vriendengezocht : ContentPage
{
	public Vriendengezocht()
	{
		InitializeComponent();
	}
    private async void Return_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Vriendenzoeken());
    }
    
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}
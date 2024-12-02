namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        
        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }

        private async void Vriendelijst_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Vriendelijst());
        }

        
        private async void Vragenlijst_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VragenlijstPage());
        }
    }

}

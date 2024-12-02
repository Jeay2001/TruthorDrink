namespace TruthOrDrink
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the MainPage to Instructiepage directly
            MainPage = new Instructiepage();
        }
    }
}

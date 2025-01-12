using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MainPageViewModel(Navigation);
        }
        protected override bool OnBackButtonPressed()
        {
            // Prevent going back to InstructiePage
            return true;
        }
    }

}

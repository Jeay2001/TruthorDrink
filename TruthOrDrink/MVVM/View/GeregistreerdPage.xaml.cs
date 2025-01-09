using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class GeregistreerdPage : ContentPage
{
	public GeregistreerdPage()
	{
		InitializeComponent();
        BindingContext = new GeregistreerdViewModel(Navigation);
    }

    
}
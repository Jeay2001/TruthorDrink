using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class VragenlijstPage : ContentPage
{
    public VragenlijstPage()
    {
        InitializeComponent();
        BindingContext = new VragenlijstViewModel(Navigation);
    }


    
}

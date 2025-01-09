using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class Instructiepage : ContentPage
{
    public Instructiepage()
    {
        InitializeComponent();
        BindingContext = new InstructiepageViewModel(Navigation);
    }
}

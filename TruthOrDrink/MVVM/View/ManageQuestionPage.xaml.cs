using TruthOrDrink.MVVM.ViewModel;

namespace TruthOrDrink;

public partial class ManageQuestionPage : ContentPage
{
    public ManageQuestionPage()
    {
        InitializeComponent();
        BindingContext = new ManageQuestionViewModel(Navigation);
    }
}
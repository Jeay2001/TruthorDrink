using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TruthOrDrink.MVVM.ViewModel
{
    public partial class UserViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        public static UserViewModel TestUser => new UserViewModel
        {
            Email = "test@example.com",
            Password = "TestPassword123"
        };
    }
    
}

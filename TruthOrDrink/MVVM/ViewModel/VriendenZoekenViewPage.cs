using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TruthOrDrink.MVVM.ViewModel
{
    public class VriendenZoekenViewPage
    {
        public INavigation? Navigation { get; set; }

        public ICommand ScanQRCommand { get; set; }

        public VriendenZoekenViewPage(INavigation? navigation)
        {
            Navigation = navigation;

            ScanQRCommand = new Command(async () =>
            {
               
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    // Process the captured photo
                    var stream = await result.OpenReadAsync();
                    // Add your QR code scanning logic here
                }
            });
        }
        
    }
}

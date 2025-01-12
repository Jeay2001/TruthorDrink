using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace TruthOrDrink
{
    public partial class QrPage : ContentPage
    {
        public QrPage()
        {
            InitializeComponent();
        }

        private async void Return_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Vriendelijst());
        }

        private async void OnSaveQrCodeTapped(object sender, EventArgs e)
        {
            try
            {
                // Check permissions before proceeding
                var permissionStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                if (permissionStatus != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permission Denied", "Storage permission is required to save the QR code.", "OK");
                    return;
                }

                // Get the QR code image source
                var qrCodeImage = QrCodeImage.Source;
                if (qrCodeImage == null)
                {
                    await DisplayAlert("Error", "QR code image not found.", "OK");
                    return;
                }

                // If it's a FileImageSource, get the file path
                if (qrCodeImage is FileImageSource fileImageSource)
                {
                    var qrCodeFilePath = GetFilePath(fileImageSource.File);
                    if (string.IsNullOrEmpty(qrCodeFilePath))
                    {
                        await DisplayAlert("Error", "QR code file path not found.", "OK");
                        return;
                    }

                    var qrCodeBytes = File.ReadAllBytes(qrCodeFilePath);

                    // Save the image to the phone's storage
                    await SaveFileAsync(qrCodeBytes);
                    await DisplayAlert("Success", "QR code saved successfully.", "OK");
                }
                else if (qrCodeImage is StreamImageSource streamImageSource)
                {
                    // Handle StreamImageSource
                    var stream = await streamImageSource.Stream(CancellationToken.None);
                    if (stream == null)
                    {
                        await DisplayAlert("Error", "Failed to load the image stream.", "OK");
                        return;
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        var qrCodeBytes = memoryStream.ToArray();
                        await SaveFileAsync(qrCodeBytes);
                        await DisplayAlert("Success", "QR code saved successfully.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Unsupported image source type.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while saving the QR code: {ex.Message}", "OK");
            }
        }

        private string GetFilePath(string fileName)
        {
            try
            {
#if ANDROID
                    return Path.Combine(FileSystem.AppDataDirectory, fileName);
#elif IOS
                    return Path.Combine(FileSystem.AppDataDirectory, fileName);
#elif WINDOWS
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
#else
                    throw new PlatformNotSupportedException("Platform not supported");
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting file path: {ex.Message}");
                return string.Empty;
            }
        }

        private async Task<string> SaveFileAsync(byte[] fileBytes)
        {
            try
            {
                string fileName = $"{DateTime.Now.Ticks}.jpeg";
                string filePath = GetOutputFilePath(fileName);
                await File.WriteAllBytesAsync(filePath, fileBytes);
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                throw;
            }
        }

        private string GetOutputFilePath(string fileName)
        {
            try
            {
#if ANDROID || IOS
                    return Path.Combine(FileSystem.AppDataDirectory, fileName);
#elif WINDOWS
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
#else
                    throw new PlatformNotSupportedException("Platform not supported");
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting output path: {ex.Message}");
                throw;
            }
        }
    }
}
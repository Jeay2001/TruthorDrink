using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace TruthOrDrink
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("jersey25.ttf", "Jersey25");
                    fonts.AddFont("Jersey10.ttf", "Jersey10");
                    fonts.AddFont("Bangers.ttf", "Bangers");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Instructiepage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

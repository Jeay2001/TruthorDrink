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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("jersey25.ttf", "Jersey25");
                    fonts.AddFont("Jersey10.ttf", "Jersey10");
                    fonts.AddFont("Bangers.ttf", "Bangers");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

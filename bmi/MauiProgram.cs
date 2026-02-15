using BMICalc.Views;
using BMICalc.ViewModels;


namespace BMICalc
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<FormPage>();
            builder.Services.AddSingleton<FormViewModel>();

            builder.Services.AddTransient<ResultPage>();
            builder.Services.AddTransient<ResultViewModel>();

            return builder.Build();
        }
    }
}

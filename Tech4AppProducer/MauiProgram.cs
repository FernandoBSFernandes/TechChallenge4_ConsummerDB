using MassTransit;

namespace Tech4AppProducer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		var connectionString = ""; //new AzureKeyVaultConfigurationOptions();
        builder.Services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(connectionString.ToString());
                cfg.ConfigureEndpoints(context);
            });
        });

        // TODO: Add App Center secrets
        AppCenter.Start(
			"windowsdesktop={Your Windows App secret here};" +
			"android={Your Android App secret here};" +
			"ios={Your iOS App secret here};" +
			"macos={Your macOS App secret here};",
			typeof(Analytics), typeof(Crashes));

		return builder.Build();
	}
}

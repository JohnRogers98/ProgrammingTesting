using Microsoft.Extensions.Logging;
using ProgrammingTesting.Features.ScoreNotification;
using ProgrammingTesting.Models;
using ProgrammingTesting.Pages;
using ProgrammingTesting.ViewModels;
using SimpleProgrammingTests.Features.Inky;

namespace ProgrammingTesting;

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

		builder.Services.AddTransient<TestPlay>();
		builder.Services.AddTransient<TestUnitworkRepository>();

        builder.Services.AddSingleton<ConsoleScoreJsonResultPrintService>();
        builder.Services.AddSingleton<ScoreSingletonUpdateService>();

        builder.Services.AddSingleton<IScoreNotificationService>(c => 
		new ScoreNotificationAgragationService(
			new IScoreNotificationService[]
			{
				c.GetRequiredService<ConsoleScoreJsonResultPrintService>(),
				c.GetRequiredService<ScoreSingletonUpdateService>(),
			}
		));

        builder.Services.AddTransient<TestUnitworkViewModel>();
		builder.Services.AddTransient<TestUnitworkPage>();
		builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

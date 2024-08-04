﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CurlEz.Data;
using CurlEz.ViewModels;
using CurlEz.Views;
using CurlEz.Infrastructure;

namespace CurlEz;

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
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IAppDbContext, AppDbContext>();
        builder.Services.AddTransient<ITestService, TestService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IRouteRegistrar, RouteRegistrar>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<SecondPageViewModel>();
        builder.Services.AddTransient<TestViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<SecondPage>();
        builder.Services.AddTransient<TestView>();

        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

using Uniation.ViewModels;
using Uniation.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Uniation.Helpers;

namespace Uniation.HostBuilders
{
    public static class BuildMainNavigationExtension
    {
        public static IHostBuilder BuildMainNavigation(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddUtilityNavigationServices<NavigationStore>();
                services.AddNavigationService<MainPageViewModel, NavigationStore>();
                services.AddNavigationService<ProjectsPageViewModel, NavigationStore>();
                services.AddNavigationService<ProjectCardViewModel, NavigationStore>();
                services.AddNavigationService<DonationPageViewModel, NavigationStore>();


            });

            return builder;
        }
    }
}
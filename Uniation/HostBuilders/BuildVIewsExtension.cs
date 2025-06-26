using CommunityToolkit.Mvvm.Messaging;
using Uniation.Models;
using Uniation.ViewModels;
using Uniation.ViewModels.Pages;
using Uniation.ViewModels.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Uniation.ViewModels.Popups;

namespace Uniation.HostBuilders
{
    public static class BuildViewsExtension
    {
        public static IHostBuilder BuildViews(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                var inactivityConfig = context.Configuration.GetValue<InactivityConfig>("inactivity");
                services.AddSingleton<IMessenger>(_ => new WeakReferenceMessenger());

                services.AddSingleton<InactivityManager<MainPageViewModel>>(s=>new InactivityManager<MainPageViewModel>(
                    inactivityConfig??new InactivityConfig(60,10),
                    s.GetRequiredService<NavigationStore>(),
                    s.GetRequiredService<NavigationService<MainPageViewModel>>(),
                    s.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));
                services.AddTransient<PaymentsMethodsViewModel>();

                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<ProjectsPageViewModel>();
                services.AddTransient<ProjectCardViewModel>();
                services.AddSingleton<DonationPageViewModel>();
               
                services.AddSingleton(s => new Views.Windows.MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                });
                
            });
            return builder;
        }
    }
}

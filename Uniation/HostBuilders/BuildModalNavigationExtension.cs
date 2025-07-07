using Uniation.ViewModels.Popups;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Uniation.Helpers;
using Uniation.ViewModels.Pages;
using Uniation.Models;

namespace Uniation.HostBuilders
{
    public static class BuildModalNavigationExtension
    {
        public static IHostBuilder BuildModalNavigation(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ModalNavigationStore>();
                services.AddUtilityNavigationServices<ModalNavigationStore>();

                services.AddNavigationService<PasswordPopupViewModel, ModalNavigationStore>(s => new PasswordPopupViewModel(
                    s.GetRequiredService<CloseNavigationService<ModalNavigationStore>>(),
                    context.Configuration.GetValue<string>("exitPassword") ?? "1234"));
                services.AddParameterNavigationService<PaymentsMethodsViewModel, ModalNavigationStore, DonatedProject>(provider => param => ActivatorUtilities.CreateInstance<PaymentsMethodsViewModel>(provider,param));
                services.AddParameterNavigationService<CardMethodPopupViewModel, ModalNavigationStore,DonatedProject>(provider => param => ActivatorUtilities.CreateInstance<CardMethodPopupViewModel>(provider,param));
                services.AddParameterNavigationService<QRMethodPopupViewModel, ModalNavigationStore,DonatedProject>(provider => param => ActivatorUtilities.CreateInstance<QRMethodPopupViewModel>(provider,param));
                services.AddParameterNavigationService<WaitingPopupViewModal, ModalNavigationStore,DonatedProject>(provider => param => ActivatorUtilities.CreateInstance<WaitingPopupViewModal>(provider,param));
                services.AddParameterNavigationService<SuccsessfulDonationViewModel, ModalNavigationStore,DonatedProject>(provider => param => ActivatorUtilities.CreateInstance<SuccsessfulDonationViewModel>(provider,param));
            });
                

                

            return builder;
        }
    }
}

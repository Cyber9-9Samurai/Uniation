using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;

namespace Uniation.ViewModels.Pages;

public partial class MainPageViewModel:ObservableObject
{
    private readonly NavigationService<ProjectsPageViewModel> _projNavService;
    private readonly NavigationService<DonationPageViewModel> _donationNav;

    public MainPageViewModel(NavigationService<ProjectsPageViewModel> navigation, NavigationService<DonationPageViewModel> donationNav)
    {
        _projNavService = navigation;
        _donationNav = donationNav;
    }

    [RelayCommand]
    private void ToProjects()
    {
        _projNavService.Navigate();
    }

    [RelayCommand]
    private void ToDonatioons()
    {
        _donationNav.Navigate();
    }
}
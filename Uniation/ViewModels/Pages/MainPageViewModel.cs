using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;

namespace Uniation.ViewModels.Pages;

public partial class MainPageViewModel:ObservableObject
{
    private readonly NavigationService<ProjectsPageViewModel> _projNavService;
    private readonly NavigationService<DonationPageViewModel> _donationNav;
    private readonly NavigationService<AboutPageViewModel> _abouNav;


    public MainPageViewModel(NavigationService<ProjectsPageViewModel> navigation, NavigationService<DonationPageViewModel> donationNav,NavigationService<AboutPageViewModel> abouNav)
    {
        _projNavService = navigation;
        _donationNav = donationNav;
        _abouNav = abouNav;
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

    [RelayCommand]
    private void ToAbout()
    {
        _abouNav.Navigate();
    }
}
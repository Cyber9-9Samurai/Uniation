using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;

namespace Uniation.ViewModels.Pages;

public partial class MainPageViewModel:ObservableObject
{
    private readonly NavigationService<ProjectsPageViewModel> _projNavService;

    public MainPageViewModel(NavigationService<ProjectsPageViewModel> navigation)
    {
        _projNavService = navigation;
    }

    [RelayCommand]
    private void ToProjects()
    {
        _projNavService.Navigate();
    }
}
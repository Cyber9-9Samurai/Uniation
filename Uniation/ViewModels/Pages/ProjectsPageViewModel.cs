using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows.Navigation;
using Uniation.Helpers;
using Uniation.Models;
using MvvmNavigationLib.Services;

namespace Uniation.ViewModels.Pages
{
    public partial class ProjectsPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainPage;
        private readonly NavigationService<ProjectCardViewModel> _projCart;

        [ObservableProperty]
        public List<ProjectsData> projects = new();

        [ObservableProperty]
        public int selectedItem;

        private readonly ApiService _apiService;
        private readonly NavigationHelper _navHelper;
        public ProjectsPageViewModel(ApiService apiService,NavigationService<MainPageViewModel> mainNavigation,NavigationService<ProjectCardViewModel> cartNavigation,NavigationHelper helper)
        {
            _apiService = apiService;
            _mainPage = mainNavigation;
            _projCart = cartNavigation;
            _navHelper = helper;
            LoadData();
        }

        private void LoadData()
        {
            
            foreach(var p in _apiService.projects)
            {
                Projects.Add(new ProjectsData()
                {
                    id = p.id,
                    title = p.title,
                    description = p.description.Split('.')[0].Remove(0,5) + ".",
                    image = "http://api-sdr.itlabs.top" + p.image
                });
            }
        }

        [RelayCommand]
        private void Return()
        {
            _mainPage.Navigate();
        }

        [RelayCommand]
        private void OpenInfo(int id)
        {
            Debug.WriteLine(id);
            _navHelper.Parameter = id;
            _projCart.Navigate();  
        }
    }
}

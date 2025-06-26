using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Uniation.Helpers;
using Uniation.Models;

namespace Uniation.ViewModels.Pages
{
    public partial class ProjectCardViewModel: ObservableObject
    {
        
        [ObservableProperty]
        public ProjectsData project;

        [ObservableProperty]
        public string image;

        [ObservableProperty]
        public int id;

        private readonly ApiService _apiService;
        private readonly NavigationService<ProjectsPageViewModel> _projNavigation;
       

        
        public ProjectCardViewModel(NavigationHelper helper, ApiService apiService,NavigationService<ProjectsPageViewModel> projNavigation)
        {
            if (helper.Parameter is int id)
            {
                Id = id;
            }

            _apiService = apiService;
            _projNavigation = projNavigation;
            LoadData();
        }

        private void LoadData()
        {
            Project = _apiService.projects.FirstOrDefault(p=> p.id==Id);
            Image = "http://api-sdr.itlabs.top" + Project.image;
            Debug.WriteLine(Project.title);
            Debug.WriteLine(Project.image);
            Debug.WriteLine(Project.description);
        }

        [RelayCommand]
        private void Return()
        {
            _projNavigation.Navigate();
        }
    }
}

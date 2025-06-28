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
        private readonly NavigationService<DonationPageViewModel> _donatNav;




        public ProjectCardViewModel(NavigationHelper helper, ApiService apiService,NavigationService<ProjectsPageViewModel> projNavigation,NavigationService<DonationPageViewModel> donatNav)
        {
            if (helper.Parameter is int id)
            {
                Id = id;
            }

            _apiService = apiService;
            _projNavigation = projNavigation;
            _donatNav = donatNav;
            LoadData();
        }

        private void LoadData()
        {
            var project = _apiService.projects.FirstOrDefault(p=> p.id==Id);
            Project = new ProjectsData()
            {
                id = project.id,
                title = project.title,
                description = project.description,
                image = project.image
            };
            Project.description = Project.description.Replace("<div>","");
            Project.description = Project.description.Replace("</div>", "");
            Project.description = Project.description.Replace("<br><br>", "\n");
            Project.description = Project.description.Replace("<br>", "\n");
            Project.description = Project.description.Replace("&nbsp;", "");
            Project.description = Project.description.Replace("<strong>", "");
            Project.description = Project.description.Replace("</strong>", "");
            Project.description = Project.description.Replace("<blockquote>", "");
            Project.description = Project.description.Replace("</blockquote>", "");
            Project.description = Project.description.Replace("<em>", "");
            Project.description = Project.description.Replace("</em>", "");
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

        [RelayCommand]
        private void ToDonation()
        {
            _donatNav.Navigate();
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Uniation.Helpers;
using Uniation.ViewModels.Pages;
using Uniation.HostBuilders;
using System.Timers;
using Uniation.Models;

namespace Uniation.ViewModels.Popups
{
    public partial class QRMethodPopupViewModel: ObservableObject
    {
        [ObservableProperty]
        private string sum;

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NavigationService<MainPageViewModel>  _mainNav;
        private readonly ParameterNavigationService<WaitingPopupViewModal, DonatedProject> _waitNav;
        private readonly DonatedProject _project;
        private System.Threading.Timer _timer;


        public QRMethodPopupViewModel(DonatedProject project, ModalNavigationStore modalNavigationStore,NavigationService<MainPageViewModel> mainNav,ParameterNavigationService<WaitingPopupViewModal,DonatedProject> waitNav)
        {
            _modalNavigationStore = modalNavigationStore;
            _mainNav = mainNav;
            _waitNav = waitNav;
            _project = project;
            if (_project != null)
            {
                Sum = project.sum.ToString() + " ₽";
            }
            _timer = new System.Threading.Timer(TimerCallback, null, 5000, Timeout.Infinite);
           

        }

        [RelayCommand]
        private void Cancel()
        {
            _timer.Dispose();
            _modalNavigationStore.CurrentViewModel = null;
        }

        [RelayCommand]
        private void ToMain()
        {
            _timer.Dispose();
            _mainNav.Navigate();
            Cancel();
        }

        private void TimerCallback(object? obj)
        {
            if (_project != null)
            {
                _waitNav.Navigate(_project);
            }
        }
       
    }
}

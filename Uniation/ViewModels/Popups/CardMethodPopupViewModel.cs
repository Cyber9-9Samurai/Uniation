using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniation.Helpers;
using Uniation.HostBuilders;

namespace Uniation.ViewModels.Popups
{
    public partial class CardMethodPopupViewModel: ObservableObject
    {
        [ObservableProperty]
        private string sum;

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NavigationService<WaitingPopupViewModal> _waitNav;
        private System.Threading.Timer _timer;

        public CardMethodPopupViewModel(NavigationHelper navigationHelper,ModalNavigationStore modalNavigationStore, NavigationService<WaitingPopupViewModal> waitNav)
        {
            _modalNavigationStore = modalNavigationStore;
            _waitNav = waitNav;
            if (navigationHelper.Parameter is string s)
            {
                Sum = "К оплате: " + s;
            }
            _timer = new System.Threading.Timer(TimerCallback, waitNav, 5000, Timeout.Infinite);
        }

        [RelayCommand]
        private void Cancel()
        {
            _timer.Dispose();
            _modalNavigationStore.CurrentViewModel = null;
        }
        private void TimerCallback(object? obj)
        {
            if (obj is NavigationService<WaitingPopupViewModal>)
            {
                _waitNav.Navigate();
            }
        }
    }
}

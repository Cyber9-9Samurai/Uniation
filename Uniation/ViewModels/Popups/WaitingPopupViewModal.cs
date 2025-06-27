using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Services;
using Uniation.HostBuilders;

namespace Uniation.ViewModels.Popups
{
    public partial class WaitingPopupViewModal : ObservableObject
    {
        [ObservableProperty]
        private int angle;

        private readonly NavigationService<SuccsessfulDonationViewModel> _succNav;
        private Timer _timer;

        public WaitingPopupViewModal(NavigationService<SuccsessfulDonationViewModel> succNav)
        {
            _succNav = succNav;
            Animate();
            _timer = new Timer(TimerCallback,succNav,5000,Timeout.Infinite);
        }

        private async void Animate()
        {
            while (true)
            {
                Angle = (Angle + 1) % 360;
                await Task.Delay(25);
            }
        }

        private void TimerCallback(object? obj)
        {
            if (obj is NavigationService<SuccsessfulDonationViewModel>)
            {
                _succNav.Navigate();
                
            }

        }

    }
}

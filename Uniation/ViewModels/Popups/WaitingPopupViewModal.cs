using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Services;
using Uniation.HostBuilders;
using Uniation.Models;

namespace Uniation.ViewModels.Popups
{
    public partial class WaitingPopupViewModal : ObservableObject
    {
        [ObservableProperty]
        private int angle;

        private readonly ParameterNavigationService<SuccsessfulDonationViewModel, DonatedProject> _succNav;
        private readonly DonatedProject _project;
        private Timer _timer;

        public WaitingPopupViewModal(DonatedProject project,ParameterNavigationService<SuccsessfulDonationViewModel,DonatedProject> succNav)
        {
            _succNav = succNav;
            _project = project;
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
            if (_project != null)
            {
                _succNav.Navigate(_project);
                
            }

        }

    }
}

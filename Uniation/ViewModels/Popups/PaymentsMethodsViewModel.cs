using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Uniation.Models;

namespace Uniation.ViewModels.Popups
{
    public partial class PaymentsMethodsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sum;


        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ParameterNavigationService<CardMethodPopupViewModel, DonatedProject> _cardMethodPopup;
        private readonly ParameterNavigationService<QRMethodPopupViewModel, DonatedProject> _qrMethodPopup;
        private readonly DonatedProject _project;

        public PaymentsMethodsViewModel(DonatedProject project, ModalNavigationStore modalNavigationStore, ParameterNavigationService<CardMethodPopupViewModel, DonatedProject> cardMethodPopup, ParameterNavigationService<QRMethodPopupViewModel, DonatedProject> qrMethodPopup)
        {

            _modalNavigationStore = modalNavigationStore;
            _cardMethodPopup = cardMethodPopup;
            _qrMethodPopup = qrMethodPopup;
            _project = project;
            SetData();

        }

        private void SetData()
        {
            if (_project != null)
            {
                Sum = _project.sum.ToString() + " ₽";
            }
        }

        [RelayCommand]
        private void Choose(string method)
        {
            switch (method)
            {
                case "card":
                    {
                        _cardMethodPopup.Navigate(_project);
                    }
                    break;
                case "QR":
                    {
                        _qrMethodPopup.Navigate(_project);
                    }
                    break;
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            _modalNavigationStore.CurrentViewModel = null;

        }
    }
}

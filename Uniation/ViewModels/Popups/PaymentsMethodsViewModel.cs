using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniation.Helpers;
using Uniation.Models;
using Uniation.ViewModels.Pages;

namespace Uniation.ViewModels.Popups
{
    public partial class PaymentsMethodsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sum;

        private readonly NavigationService<DonationPageViewModel> _donationNav;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NavigationService<CardMethodPopupViewModel> _cardMethodPopup;
        private readonly NavigationService<QRMethodPopupViewModel> _qrMethodPopup;

        public PaymentsMethodsViewModel(NavigationHelper navigationHelper,NavigationService<DonationPageViewModel> donationNav,ModalNavigationStore modalNavigationStore,NavigationService<CardMethodPopupViewModel> cardMethodPopup,NavigationService<QRMethodPopupViewModel> qrMethodPopup)
        {
            _donationNav = donationNav;
            _modalNavigationStore = modalNavigationStore;
            _cardMethodPopup = cardMethodPopup;
            _qrMethodPopup = qrMethodPopup;
            if(navigationHelper.Parameter is DonatedProject p)
            {
                Sum = p.sum.ToString() + " ₽";
            }
            Debug.WriteLine(Sum);
        }

        [RelayCommand]
        private void Choose(string method)
        {
            switch (method)
            {
                case "card":
                    {
                        _cardMethodPopup.Navigate();
                    }
                    break;
                case "QR":
                    {
                        _qrMethodPopup.Navigate();
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

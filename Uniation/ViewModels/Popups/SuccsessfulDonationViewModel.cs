using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniation.ViewModels.Popups
{
    public partial class SuccsessfulDonationViewModel: ObservableObject
    {
        private ModalNavigationStore _modalNavigationStore;
        public SuccsessfulDonationViewModel(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        [RelayCommand]
        private void Close()
        {
            _modalNavigationStore.CurrentViewModel = null;
        }
    }
}

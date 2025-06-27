using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Windows;
using Uniation.Helpers;
using Uniation.Models;
using Uniation.ViewModels.Popups;

namespace Uniation.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<ProjectsData> projects;

        [ObservableProperty]
        private int selectedIndex = 0;

        [ObservableProperty]
        private bool isOneHundredChecked;
        [ObservableProperty]
        private bool isFiveHundredChecked;
        [ObservableProperty]
        private bool isOneThousendChecked;
        [ObservableProperty]
        private bool isFiveThousandsChecked;

        [ObservableProperty]
        private string sum;

        [ObservableProperty]
        private Visibility placeholderVis;

        private readonly NavigationService<MainPageViewModel> _mainNav;
        private readonly NavigationService<PaymentsMethodsViewModel> _popup;
        private readonly NavigationHelper _navigationHelper;
        private ProjectsData zeroProj = new();
        private string choosenRadioBtn;

       
        public DonationPageViewModel(NavigationService<MainPageViewModel> mainNav,ApiService apiService,NavigationService<PaymentsMethodsViewModel> popup,NavigationHelper navigationHelper)
        {
            _mainNav = mainNav;
            SetDefaultSettings();
            Projects = apiService.projects;
            _popup = popup;
            _navigationHelper = navigationHelper;
            Projects.Insert(0,zeroProj);
        }

        private void SetDefaultSettings()
        {
            zeroProj.id = -1;
            zeroProj.title = "Без проекта";
            zeroProj.description = "";
            zeroProj.image = "";
            Cancel();
        }


        [RelayCommand]
        private void Return()
        {
            _mainNav.Navigate();
        }

        [RelayCommand]
        private void Cancel()
        {
            PlaceholderVis = Visibility.Visible;
            SelectedIndex = 0;
            IsOneHundredChecked = true;
            Sum = "";
            choosenRadioBtn = "100P";
        }

        [RelayCommand]
        private void Donate()
        {
            if (SelectedIndex !=0 && (isChoose() || (Sum.Length > 0 && int.TryParse(Sum,out int a) && a > 10)))
            {
                if (isChoose())
                {
                    _navigationHelper.Parameter = choosenRadioBtn;
                }
                else
                {
                    _navigationHelper.Parameter = Sum;
                }
                    _popup.Navigate();
            }
        }

        private bool isChoose()
        {
            
            return IsOneHundredChecked || IsFiveHundredChecked || IsOneThousendChecked || IsFiveThousandsChecked;
        }

        private void Input()
        {
            CustomChoice();
            PlaceholderVis = Visibility.Hidden;
        }
        private void SetDefault()
        {
            if (Sum.Length == 0 && !isChoose())
            {
                IsOneHundredChecked = true;
                PlaceholderVis = Visibility.Visible;
            }
        }
        private void CustomChoice()
        {
            IsOneHundredChecked = false;
            IsFiveHundredChecked = false;
            IsOneThousendChecked = false;
            IsFiveThousandsChecked = false;
        }

        [RelayCommand]
        private void UserChoose(string cont)
        {
            Sum = "";
            PlaceholderVis = Visibility.Visible;
            choosenRadioBtn = cont;
        }

        [RelayCommand]
        private void InputSum(string num)
        {
            if (int.TryParse(num, out int number))
            {
                
                
                switch (number)
                {
                    case 1:
                        {
                            Sum += "1";
                            Input();
                        }
                        break;
                    case 2:
                        {
                            Sum += "2";
                            Input();
                        }
                        break;

                    case 3:
                        {
                            Sum += "3";
                            Input();
                        }
                        break;

                    case 4:
                        {
                            Sum += "4";
                            Input();
                        }
                        break;
                    case 5:
                        {
                            Sum += "5";
                            Input();
                        }
                        break;
                    case 6:
                        {
                            Sum += "6";
                            Input();
                        }
                        break;
                    case 7:
                        {
                            Sum += "7";
                            Input();
                        }
                        break;
                    case 8:
                        {
                            Sum += "8";
                            Input();
                        }
                        break;
                    case 9:
                        {
                            Sum += "9";
                            Input();
                        }
                        break;
                    case 0:
                        {
                            if (Sum.Length > 0)
                            {
                                Sum += "0";
                                Input();
                            }
                            SetDefault();
                        }
                        break;
                    case -1:
                        {
                            if (Sum.Length > 0)
                            {
                                Sum = Sum.Remove(Sum.Length - 1, 1);
                                
                            }
                            SetDefault();
                        }
                        break;
                }
            }
        }
    }
}

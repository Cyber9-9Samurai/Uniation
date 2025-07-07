using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Collections.ObjectModel;
using System.Windows;
using Uniation.Helpers;
using Uniation.Models;
using Uniation.ViewModels.Popups;

namespace Uniation.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<ProjectsData> projects = new();

        [ObservableProperty]
        public ObservableCollection<RadioButtons> radios = new ObservableCollection<RadioButtons>
        {
            new RadioButtons {Content = "100₽",ComParameter = "100 ₽",IsChecked = false},
            new RadioButtons {Content = "500₽",ComParameter = "500 ₽",IsChecked = false},
            new RadioButtons {Content = "1000₽",ComParameter = "1000 ₽",IsChecked = false},
            new RadioButtons {Content = "5000₽",ComParameter = "5000 ₽",IsChecked = false}
        };



        [ObservableProperty]
        private int _selectedIndex = 0;


        [ObservableProperty]
        private string sum;

        [ObservableProperty]
        private bool placeholderVis;

        private readonly NavigationService<MainPageViewModel> _mainNav;
        private readonly ApiService _apiService;
        private readonly ParameterNavigationService<PaymentsMethodsViewModel, DonatedProject> _PaymentNavigation;

        private string choosenRadioBtn;

       
        public DonationPageViewModel(NavigationService<MainPageViewModel> mainNav,ApiService apiService,ParameterNavigationService<PaymentsMethodsViewModel,DonatedProject> parameterNavigation)
        {
            _mainNav = mainNav;
            _apiService = apiService;
            _PaymentNavigation = parameterNavigation;
            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            
            Projects.Add(new ProjectsData()
            {
                id = -1,
                title = "Без проекта",
                description = "",
                image = ""
            });
            foreach(var p in _apiService.projects)
            {
                Projects.Add(new ProjectsData()
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    image = p.image
                });
            }
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
            PlaceholderVis = true;
            SelectedIndex = 0;
            Radios[0].IsChecked = true;
            Sum = "";
            choosenRadioBtn = "100 ₽";
        }

        [RelayCommand]
        private void Donate()
        {
            if (SelectedIndex !=0 && (isChoose() || (Sum.Length > 0 && int.TryParse(Sum,out int a) && a >= 10)))
            {
                DonatedProject proj = new();
                proj.id = SelectedIndex;
                proj.title = Projects.FirstOrDefault(i => i.id == SelectedIndex).title;
                if (isChoose())
                {
                    proj.sum = int.Parse(choosenRadioBtn.Remove(choosenRadioBtn.Length - 1,1));
                }
                else
                {
                    proj.sum = int.Parse(Sum);
                }
                
                _PaymentNavigation.Navigate(proj);
               
            }
        }

        private bool isChoose()
        {

            return Radios[0].IsChecked || Radios[1].IsChecked || Radios[2].IsChecked || Radios[3].IsChecked;
        }

        private void Input()
        {
            CustomChoice();
            PlaceholderVis = false;
        }
        private void SetDefault()
        {
            if (Sum.Length == 0 && !isChoose())
            {
                Radios[0].IsChecked = true;
                PlaceholderVis = true;
            }
        }
        private void CustomChoice()
        {
            Radios[0].IsChecked = false;
            Radios[1].IsChecked = false;
            Radios[2].IsChecked = false;
            Radios[3].IsChecked = false;
        }

        [RelayCommand]
        private void UserChoose(string cont)
        {
            
            Sum = "";
            PlaceholderVis = true;
            choosenRadioBtn = cont;
        }

        [RelayCommand]
        private void InputSum(string num)
        {
            if (int.TryParse(num, out int number))
            {
                
                
                switch (number)
                {
                    case >=1 and <=9:
                        {
                            Sum += number.ToString();
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

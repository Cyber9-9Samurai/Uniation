using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Uniation.ViewModels.Pages
{
    public partial class AboutPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private string imagePath = "/Resources/Images";

        [ObservableProperty]
        private bool isRigthButtonEnabled = false;
        [ObservableProperty]
        private bool isLeftButtonEnabled = true;

        private List<string> slides = new();
        private int index = 0;
        private readonly NavigationService<MainPageViewModel> _mainNav;

        public AboutPageViewModel(NavigationService<MainPageViewModel> mainNav)
        {
            _mainNav = mainNav;
            LoadData();
            SetImage();
        }

        private void LoadData()
        {
            
            //string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,ImagePath.TrimStart('/'));
            string fullPath = @"E:\MVS projects\Uniation\Uniation\Resources\Images\";
            if (Directory.Exists(fullPath))
            {
                string[] files = Directory.GetFiles(fullPath);
                foreach(var file in files)
                {
                    if (Regex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(file),"^[a-zA-Z0-9+=/?!_.,-]{1,}.*Slide$"))
                    {
                        slides.Add(System.IO.Path.GetFileName(file));
                    }
                }
            }
        }

        private void SetImage()
        {
            if(slides.Count > 0)
            {
                ImagePath = "/Resources/Images/" + slides[index];
            }
            
        }

        [RelayCommand]
        private void Swipe(string button)
        {
            switch (button)
            {
                case "+":
                    {
                        if(index < slides.Count - 1)
                        {
                            index++;
                        }
                    }
                    break;
                case "-":
                    {
                        if (index > 0)
                        {
                            index--;
                        }
                    }
                    break;
            }
            if(index == 0)
            {
                IsRigthButtonEnabled = false;
                IsLeftButtonEnabled = true;
            }
            else if(index > 0 && index < slides.Count - 1)
            {
                IsRigthButtonEnabled = true;
                IsLeftButtonEnabled = true;
            }
            else if(index == slides.Count - 1)
            {
                IsRigthButtonEnabled = true;
                IsLeftButtonEnabled = false;
            }
                SetImage();
        }

        [RelayCommand]
        private void Return()
        {
            _mainNav.Navigate();
        }
    }
}

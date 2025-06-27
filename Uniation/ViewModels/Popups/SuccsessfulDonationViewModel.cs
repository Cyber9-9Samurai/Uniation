using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Uniation.Helpers;
using Uniation.Models;

namespace Uniation.ViewModels.Popups
{
    public partial class SuccsessfulDonationViewModel: ObservableObject
    {
        private ModalNavigationStore _modalNavigationStore;
        private NavigationHelper _navigationHelper;
        public SuccsessfulDonationViewModel(ModalNavigationStore modalNavigationStore,NavigationHelper navigationHelper)
        {
            _modalNavigationStore = modalNavigationStore;
            _navigationHelper = navigationHelper;
            CreateLog();
        }

        [RelayCommand]
        private void Close()
        {
            _modalNavigationStore.CurrentViewModel = null;
        }

        private async void CreateLog()
        {
            if (_navigationHelper.Parameter is DonatedProject p)
            {
                
                string path = @"E:\MVS projects\Uniation\Uniation\donations.json";
                if (File.Exists(path))
                {
                    string jsonData = await File.ReadAllTextAsync(path);
                    List<DonatedProject> donates = JsonConvert.DeserializeObject<List<DonatedProject>>(jsonData) ?? new();
                    var repDonate = donates.FirstOrDefault( d => d.id == p.id);
                    if(repDonate != null)
                    {
                        repDonate.sum += p.sum;
                    }
                    else
                    {
                        donates.Add(p);
                    }
                    string updJson = JsonConvert.SerializeObject(donates,Formatting.Indented);
                    await File.WriteAllTextAsync(path,updJson);
                }
                else
                {
                    string jsonstr = JsonConvert.SerializeObject(p, Formatting.Indented);
                    File.Create(path);
                    await File.WriteAllTextAsync(path,jsonstr);
                }
            }
        }
    }
}
